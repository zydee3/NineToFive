using System;
using System.IO;
using log4net;
using Microsoft.ClearScript.V8;
using NineToFive.Constants;
using NineToFive.Game;
using NineToFive.Game.Entity;
using NineToFive.Net;
using NineToFive.Scripting;

namespace NineToFive.Event {
    public class TalkToNpcEvent : PacketEvent {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TalkToNpcEvent));

        private int _objectId;
        
        public TalkToNpcEvent(Client client) : base(client) { }

        public override bool OnProcess(Packet p) {
            
            _objectId = p.ReadInt();
            
            p.ReadShort(); // user x location
            p.ReadShort(); // user y location
            
            return true;    
        }

        public override void OnHandle() {
            User user = Client.User;
            
            if (user.ScriptEngine != null) {
                user.ScriptEngine.Dispose();
                user.ScriptEngine = null;
            }
            
            if (user.NpcScriptInstance != null) {
                user.NpcScriptInstance.Dispose();
                user.NpcScriptInstance = null;
            }
            
            if (user.Field.LifePools.TryGetValue(EntityType.Npc, out LifePool<Life> pool)) {
                Npc npc = (Npc) pool.FindFirst(life => life.Id == _objectId);
                if (npc == null)
                    return;

                int npcId = npc.TemplateId;
                
                if (user.IsDebugging) 
                    user.SendMessage($"Object Id = {_objectId}, Npc Id = {npcId}");
                
                user.NpcScriptInstance = new NpcScriptMan(Client, _objectId, npcId);
                
                try {
                    user.ScriptEngine = Scriptable.GetEngine($"Npc/{npcId}.js", user.NpcScriptInstance).Result;
                    Scriptable.RunScriptAsync(user.ScriptEngine).Wait();
                } catch (Exception e) {
                    if (e is AggregateException ae) {
                        ae.Handle(x => {
                            if (x is FileNotFoundException) {
                                user.SendMessage($"Npc Not Found: {npcId}");
                            } else {
                                string error = $"Error executing npc: {npcId}.js ({e.Message})";
                                Log.Error(error);
                                user.SendMessage(error);
                            }

                            return true;
                        });
                    }
                }
            }
        }
    }

    
    
    
}