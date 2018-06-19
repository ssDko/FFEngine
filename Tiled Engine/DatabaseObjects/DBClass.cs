using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBClass
    {
        private static int MaxMagicSlots = 8;
        private static int MaxStatGrowLevels = 98;
        #region Declarations
        private int id;
        private string name;
        private int expCurveId;
        private int startingEquipId;

        private int startingHP;
        private int startingMP; // if not using the spell slot system
        private int[] startingSpellSlots = new int[MaxMagicSlots];   // if we are 
        
        private int startingSTR;
        private int startingAGI;
        private int startingINT;
        private int startingVIT;  //Stamina
        private int startingLCK;
        private int startingHit;  
        private int startingMDef;

        //Todo: add actual stat curves
        private IndexedGrowStat[] growStatLevels = new IndexedGrowStat[MaxStatGrowLevels]; // The levels where a stat gain is garenteed. 
        private IndexedGrowSpellSlot[] growSpellSlotLevels = new IndexedGrowSpellSlot[MaxStatGrowLevels]; // The levels where you gain a spell slot

        private List<DBTrait> traits;
        private List<ClassSkills> skills;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public int ExpCurveId { get => expCurveId; set => expCurveId = value; }
        public int StartingEquipId { get => startingEquipId; set => startingEquipId = value; }

        public int StartingHP { get => startingHP; set => startingHP = value; }
        public int StartingMP { get => startingMP; set => startingMP = value; }
        public int[] StartingSpellSlots { get => startingSpellSlots; set => startingSpellSlots = value; }

        public int StartingSTR { get => startingSTR; set => startingSTR = value; }
        public int StartingAGI { get => startingAGI; set => startingAGI = value; }
        public int StartingINT { get => startingINT; set => startingINT = value; }
        public int StartingVIT { get => startingVIT; set => startingVIT = value; }
        public int StartingLCK { get => startingLCK; set => startingLCK = value; }
        public int StartingHit { get => startingHit; set => startingHit = value; }
        public int StartingMDef { get => startingMDef; set => startingMDef = value; }

        [XmlArray("LevelsStatsGrowAt")]
        [XmlArrayItem("At")]
        public IndexedGrowStat[] GrowStatLevels { get => growStatLevels; set => growStatLevels = value; }
        [XmlArray("LevelsSpellSlotsGrowAt")]
        [XmlArrayItem("At")]
        public IndexedGrowSpellSlot[] GrowSpellSlotLevels { get => growSpellSlotLevels; set => growSpellSlotLevels = value; }

        public List<DBTrait> Traits { get => traits; set => traits = value; }
        public List<ClassSkills> Skills { get => skills; set => skills = value; }
        #endregion

        #region Constructor(s)
        public DBClass()
        {
            Id = 1;
            Name = "";

            ExpCurveId = 1;
            StartingEquipId = 1;

            StartingHP = 1;
            StartingMP = 0;

            StartingSpellSlots = new int[MaxStatGrowLevels];

            StartingSTR = 1;
            StartingAGI = 1;
            StartingINT = 1;
            StartingVIT = 1;
            StartingLCK = 1;
            StartingHit = 1;
            StartingMDef = 1;

            GrowStatLevels = new IndexedGrowStat[MaxStatGrowLevels];
            GrowSpellSlotLevels = new IndexedGrowSpellSlot[MaxStatGrowLevels];

            Traits = new List<DBTrait>();
            Skills = new List<ClassSkills>();

        }

        public DBClass(int id,
                       string name,
                       int expCurveId,
                       int startingEquipId,
                       int startingHP,
                       int startingMP,
                       int[] startingSpellSlots,
                       int startingSTR,
                       int startingAGI,
                       int startingINT,
                       int startingVIT,
                       int startingLCK,
                       int startingHit,
                       int startingMDef,
                       IndexedGrowStat[] growStatLevels,
                       IndexedGrowSpellSlot[] growSpellSlotLevels,
                       List<DBTrait> traits,
                       List<ClassSkills> skills)
        {
            Id = id;
            Name = name;

            ExpCurveId = expCurveId;
            StartingEquipId = startingEquipId;

            StartingHP = startingHP;
            StartingMP = startingMP;
            StartingSpellSlots = startingSpellSlots;

            StartingSTR = startingSTR;
            StartingAGI = startingAGI;
            StartingINT = startingINT;
            StartingVIT = startingVIT;
            StartingLCK = startingLCK;
            StartingHit = startingHit;
            StartingMDef = startingMDef;

            GrowStatLevels = growStatLevels;
            GrowSpellSlotLevels = growSpellSlotLevels;

            Traits = traits;
            Skills = skills;
        }

        public DBClass(int id,
                       string name,
                       int expCurveId,
                       int startingHP,
                       int[] startingSpellSlots,
                       int startingSTR,
                       int startingAGI,
                       int startingINT,
                       int startingVIT,
                       int startingLCK,
                       int startingHit,
                       int startingMDef,
                       GrowStat[] growStatLevels,
                       GrowSpellSlot[] growSpellSlotLevels,
                       List<DBTrait> traits,
                       List<ClassSkills> skills)
        {
            Id = id;
            Name = name;
            ExpCurveId = expCurveId;
            StartingHP = startingHP;
            StartingMP = startingMP;
            StartingSpellSlots = startingSpellSlots;
            StartingSTR = startingSTR;
            StartingAGI = startingAGI;
            StartingINT = startingINT;
            StartingVIT = startingVIT;
            StartingLCK = startingLCK;
            StartingHit = startingHit;
            StartingMDef = startingMDef;
            GrowStatsRaw = growStatLevels;
            GrowSpellSlotsRaw = growSpellSlotLevels;
            Traits = traits;
            Skills = skills;
        }
        #endregion

        #region Methods
        [XmlIgnore]
        public IEnumerable<GrowStat> GrowStatsRaw
        {
            get { return growStatLevels.Select(x => x.GrowStat); }
            set
            {
                growStatLevels = value.Select((x, i) => new IndexedGrowStat { Level = i + 2, GrowStat = x }).ToArray();
            }
        }

        [XmlIgnore]
        public IEnumerable<GrowSpellSlot> GrowSpellSlotsRaw
        {
            get { return growSpellSlotLevels.Select(x => x.GrowSpell); }
            set
            {
                growSpellSlotLevels = value.Select((x, i) => new IndexedGrowSpellSlot { Level = i + 2, GrowSpell = x }).ToArray();
            }
        }

       


        #endregion
    }   

    

    

    
   

}
