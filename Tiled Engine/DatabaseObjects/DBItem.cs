using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBItem
    {
        #region Declarations
        private int id;
        private string name;
        private string description;
        private int iconId;
        private int price;
        private bool consumable;
        private ItemType itemType;
        private Scope scope;
        private Occasion occasion;

        private int speed;
        private int successRate; //as a %
        private int repeatRate; // Min 1
        private HitType hitType;
        private int animationId;

        
        private DamageType damageType;
        private int damageElementId;
        private string damageFormula;
        private int variance; //as a%
        private Occasion damageOccasion;

        private List<DBEffect> effects;         

        private string note;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int IconId { get => iconId; set => iconId = value; }
        public int Price { get => price; set => price = value; }
        public bool Consumable { get => consumable; set => consumable = value; }
        public ItemType ItemType { get => itemType; set => itemType = value; }
        public Scope Scope { get => scope; set => scope = value; }
        public Occasion Occasion { get => occasion; set => occasion = value; }

        public int Speed { get => speed; set => speed = value; }
        public int SuccessRate { get => successRate; set => successRate = value; }
        public int RepeatRate { get => repeatRate; set => repeatRate = value; } 
        public HitType HitType { get => hitType; set => hitType = value; }
        public int AnimationId { get => animationId; set => animationId = value; }

        public DamageType DamageType { get => damageType; set => damageType = value; }
        public int DamageElementId { get => damageElementId; set => damageElementId = value; }
        public string DamageFormula { get => damageFormula; set => damageFormula = value; }
        public int Variance { get => variance; set => variance = value; }
        public Occasion DamageOccasion { get => damageOccasion; set => damageOccasion = value; }


        public List<DBEffect> Effects { get => effects; set => effects = value; }        

        public string Note { get => note; set => note = value; }
        

        #endregion

        #region Constructor(s)
        public DBItem()
        {
            Id = 1;
            Name = "";
            Description = "";
            IconId = 0;
            Price = 0;
            Consumable = true;
            ItemType = ItemType.Regular;
            Scope = Scope.None;
            Occasion = Occasion.Always;

            Speed = 0;
            SuccessRate = 100;
            RepeatRate = 1;
            HitType = HitType.CertainHit;
            AnimationId = 1;

            DamageType = DamageType.None;
            DamageElementId = 0;
            DamageFormula = "";
            Variance = 0;
            DamageOccasion = Occasion.Always;

            Effects = new List<DBEffect>();          

            Note = "";
        }

        public DBItem(int id,
                      string name,
                      string description,
                      int iconId,
                      int price,
                      bool consumable,
                      ItemType itemType,
                      Scope scope,
                      Occasion occasion,
                      int speed,
                      int successRate,
                      int repeatRate,
                      HitType hitType,
                      int animationId,
                      DamageType damageType,
                      int damageElementId,
                      string damageFormula,
                      int variance,
                      Occasion damageOccasion,
                      List<DBEffect> effects,                      
                      string note
                      )
        {
            Id = id;
            Name = name;
            Description = description;
            IconId = iconId;
            Price = price;
            Consumable = consumable;
            ItemType = itemType;
            Scope = scope;
            Occasion = occasion;
            Speed = speed;
            SuccessRate = successRate;
            RepeatRate = repeatRate;
            HitType = hitType;
            AnimationId = animationId;
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
