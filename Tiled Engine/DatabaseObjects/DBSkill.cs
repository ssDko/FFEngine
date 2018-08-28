using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBSkill : DBObject
    {
        #region Declarations        
        private int iconId;
        private string description;
        private SkillType skillType;
        private Scope scope;
        private Occasion occasion;

        // If using standard MP
        private int mpCost;
        // If using spell slots (Max level is 8)
        private int spellSlotLevel;

        private int speed;
        private int successRate; //as a %
        private int repeatRate; // Min 1
        private HitType hitType;
        private int animationId;

        private string message1;
        private string message2;

        private int requiredWeaponId1;
        private int requiredWeaponId2;

        private DamageType damageType;
        private int damageElementId;
        private string damageFormula;
        private int variance; //as a%
        private Occasion damageOccasion;

        private List<DBEffect> effects;

        private string note;
        #endregion

        #region Properties        
        public int IconId { get => iconId; set => iconId = value; }
        public string Description { get => description; set => description = value; }
        public SkillType SkillType { get => skillType; set => skillType = value; }        
        public Scope Scope { get => scope; set => scope = value; }
        public Occasion Occasion { get => occasion; set => occasion = value; }

        public int MpCost { get => mpCost; set => mpCost = value; }
        public int SpellSlotLevel { get => spellSlotLevel; set => spellSlotLevel = value; }


        public int Speed { get => speed; set => speed = value; }
        public int SuccessRate { get => successRate; set => successRate = value; }
        public int RepeatRate { get => repeatRate; set => repeatRate = value; }
        public HitType HitType { get => hitType; set => hitType = value; }
        public int AnimationId { get => animationId; set => animationId = value; }

        public string Message1 { get => message1; set => message1 = value; }
        public string Message2 { get => message2; set => message2 = value; }

        public int RequiredWeaponId1 { get => requiredWeaponId1; set => requiredWeaponId1 = value; }
        public int RequiredWeaponId2 { get => requiredWeaponId2; set => requiredWeaponId2 = value; }

        public DamageType DamageType { get => damageType; set => damageType = value; }
        public int DamageElementId { get => damageElementId; set => damageElementId = value; }
        public string DamageFormula { get => damageFormula; set => damageFormula = value; }
        public int Variance { get => variance; set => variance = value; }
        public Occasion DamageOccasion { get => damageOccasion; set => damageOccasion = value; }

        public List<DBEffect> Effects { get => effects; set => effects = value; }

        public string Note { get => note; set => note = value; }
        
        #endregion

        #region Constructor(s)
        public DBSkill()
        {
            Id = 1;
            Name = "";
            IconId = 1;
            Description = "";
            SkillType = SkillType.None;
            Scope = Scope.None;
            Occasion = Occasion.Always;

            MpCost = 0;
            SpellSlotLevel = 0;

            Speed = 0;
            SuccessRate = 100;
            RepeatRate = 1;
            HitType = HitType.CertainHit;
            AnimationId = 1;

            Message1 = "";
            Message2 = "";

            RequiredWeaponId1 = 0;
            RequiredWeaponId2 = 0;

            DamageType = DamageType.None;
            DamageElementId = 0;
            DamageFormula = "";
            Variance = 0;
            DamageOccasion = Occasion.Always;

            Effects = new List<DBEffect>();

            Note = "";
        }

        public DBSkill(int id, 
                       string name, 
                       int iconId, 
                       string description, 
                       SkillType skillType, 
                       Scope scope, 
                       Occasion occasion, 
                       int mpCost, 
                       int spellSlotLevel, 
                       int speed, 
                       int successRate, 
                       int repeatRate, 
                       HitType hitType, 
                       int animationId, 
                       string message1, 
                       string message2, 
                       int requiredWeaponId1, 
                       int requiredWeaponId2, 
                       DamageType damageType, 
                       int damageElementId, 
                       string damageFormula, 
                       int variance, 
                       Occasion damageOccasion, 
                       List<DBEffect> effects, 
                       string note)
        {
            Id = id;
            Name = name;
            IconId = iconId;
            Description = description;
            SkillType = skillType;
            Scope = scope;
            Occasion = occasion;
            MpCost = mpCost;
            SpellSlotLevel = spellSlotLevel;
            Speed = speed;
            SuccessRate = successRate;
            RepeatRate = repeatRate;
            HitType = hitType;
            AnimationId = animationId;
            Message1 = message1;
            Message2 = message2;
            RequiredWeaponId1 = requiredWeaponId1;
            RequiredWeaponId2 = requiredWeaponId2;
            DamageType = damageType;
            DamageElementId = damageElementId;
            DamageFormula = damageFormula;
            Variance = variance;
            DamageOccasion = damageOccasion;
            Effects = effects;
            Note = note;
        }

        #endregion

        #region Methods

        #endregion
    }   
}
