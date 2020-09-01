﻿using System.Numerics;
using NineToFive.Constants;
using NineToFive.Game.Storage;
using NineToFive.Packets;

namespace NineToFive.Game.Entity {
    public class Drop : Life {
        private Item _item;

        public Drop(int id, int quantity, Life creator) : base(id, EntityType.Drop) {
            Fh = creator.Fh;
            Location = creator.Location;
            Origin = creator.Location;
            Quantity = quantity;
        }

        public Vector2 Origin { get; set; }
        public int Quantity { get; set; }

        public Item Item {
            get => _item ?? new Item(TemplateId, true) {Quantity = (ushort) Quantity};
            set => _item = value;
        }
        
        public override byte[] EnterFieldPacket() {
            return DropPool.GetDropEnterField(this, 2);
        }

        public override byte[] LeaveFieldPacket() {
            return DropPool.GetDropLeaveField(this, 0);
        }
    }
}