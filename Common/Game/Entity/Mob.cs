﻿using System;
using NineToFive.Constants;
using NineToFive.Game.Entity.Meta;
using NineToFive.Wz;

namespace NineToFive.Game.Entity {
    public class Mob : Meta.Entity {
        public int Id { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MaxMP { get; set; }
        public int Speed { get; set; }
        public int PADamage { get; set; }
        public int PDDamage { get; set; }
        public int PDRate { get; set; }
        public int MADamage { get; set; }
        public int MDDamage { get; set; }
        public int MDRate { get; set; }
        public int Acc { get; set; }
        public int Eva { get; set; }
        
        public TemplateMob.Ban MonsterBan { get; set; }
        public TemplateMob.LoseItem[] LoseItems { get; set; }
        public int[] DamagedBySelectedSkill { get; set; }
        public int[] DamagedBySelectedMob { get; set; }
        public int[] Revives { get; set; }
        public TemplateMob.Skill[] Skills { get; set; }
        public Tuple<int, int> HealOnDestroy;
        public int SelfDestruction;

        public int BodyAttack { get; set; }
        public int Pushed { get; set; }
        public int SummonType { get; set; }
        public int Boss { get; set; }
        public int IgnoreFieldOut { get; set; }
        public int Category { get; set; }
        public int HPgaugeHide { get; set; }
        public int HpTagColor { get; set; }
        public int HpTagBgColor { get; set; }
        public int FirstAttack { get; set; }
        public int Exp { get; set; }
        public int HpRecovery { get; set; }
        public int MpRecovery { get; set; }
        public int ExplosiveReward { get; set; }
        public int HideName { get; set; }
        public int RemoveAfter { get; set; }
        public int NoFlip { get; set; }
        public int Undead { get; set; }
        public int DamagedByMob { get; set; }
        public int RareItemDropLevel { get; set; }
        public int FlySpeed { get; set; }
        public int PublicReward { get; set; }
        public int Invincible { get; set; }
        public int UpperMostLayer { get; set; }
        public int NoRegen { get; set; }
        public int HideHP { get; set; }
        public int MBookID { get; set; }
        public int NoDoom { get; set; }
        public int FixedDamage { get; set; }
        public int RemoveQuest { get; set; }
        public int ChargeCount { get; set; }
        public int AngerGauge { get; set; }
        public int ChaseSpeed { get; set; }
        public int Escort { get; set; }
        public int RemoveOnMiss { get; set; }
        public int CoolDamage { get; set; }
        public int CoolDamageProb { get; set; }
        public int _0 { get; set; }
        public int GetCP { get; set; }
        public int CannotEvade { get; set; }
        public int DropItemPeriod { get; set; }
        public int OnlyNormalAttack { get; set; }
        public int Point { get; set; }
        public int FixDamage { get; set; }
        public int Weapon { get; set; }
        public int NotAttack { get; set; }
        public int DoNotRemove { get; set; }
        public int CantPassByTeleport { get; set; }
        public int Phase { get; set; }
        public int DualGauge { get; set; }
        public int Disable { get; set; }
        
        public float Fs { get; set; }
        
        public string PartyReward { get; set; }
        public string Buff { get; set; }
        public string DefaultHP { get; set; }
        public string DefaultMP { get; set; }
        public string Link { get; set; }
        public string MobType { get; set; }
        public string ElemAttr { get; set; }

        public Mob(int id) : base(EntityType.Mob) {
            Id = id;
            MobWz.SetMob(this);
        }
    }
}