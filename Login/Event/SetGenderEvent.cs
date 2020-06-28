﻿using NineToFive.IO;

namespace NineToFive.Event {
    /// <summary>
    /// <para>CLogin::SendCancelGenderPacket</para>
    /// <para>CLogin::SendSetGenderPacket</para>
    /// </summary>
    class SetGenderEvent : PacketEvent {

        private bool _success;
        private byte _gender;

        public SetGenderEvent(Client client) : base(client) {
        }

        public override void OnHandle() {
            if (_success) Client.Gender = _gender;
            Client.Session.Write(GetSetAccountResult(_gender, _success));
        }

        public override bool OnProcess(Packet p) {
            _success = p.ReadBool();
            if (_success) _gender = p.ReadByte();
            return _gender == 0 || _gender == 1;
        }

        private static byte[] GetSetAccountResult(byte gender, bool success) {
            using Packet p = new Packet();
            p.WriteShort((short)SendOps.CLogin.OnSetAccountResult);
            p.WriteByte(gender);
            p.WriteBool(success);
            return p.ToArray();
        }
    }
}