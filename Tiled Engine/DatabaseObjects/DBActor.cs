using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{   [Serializable]
    public class DBActor : DBObject
    {
        #region Declarations       
        private int classId; // Index of the characters class     
        private int initialLevel;
        private int maxLevel;

        private int startingEquipId;

        private string characterName; // The name of the character image used
        private int characterIndex; // Index of the charaacter in the character image used (Upto 8)
        private string battlerName;  // The name of the side view battler image 

        private List<DBTrait> traits;
        // Optional 
        private string faceImage; // The name of the face image
        private string nickname;
        private string note;
        private string profile;

        #endregion

        #region Properties        
        public int ClassId { get => classId; set => classId = value; }
        public int InitialLevel { get => initialLevel; set => initialLevel = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }

        public int StartingEquipId { get => startingEquipId; set => startingEquipId = value; }

        public string CharacterName { get => characterName; set => characterName = value; }
        public int CharacterIndex { get => characterIndex; set => characterIndex = value; }
        public string BattlerName { get => battlerName; set => battlerName = value; }

        public List<DBTrait> Traits { get => traits; set => traits = value; }

        public string FaceImage { get => faceImage; set => faceImage = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Note { get => note; set => note = value; }
        public string Profile { get => profile; set => profile = value; }
       


        #endregion

        #region Constructor(s)
        public DBActor()
        {
            Id = 1;
            Name = "";
            ClassId = 1;
            InitialLevel = 1;
            MaxLevel = 99;
            StartingEquipId = 1;
            CharacterName = "";
            CharacterIndex = 0;
            BattlerName = "";
            Traits = new List<DBTrait>();
            FaceImage = "";
            Nickname = "";
            Note = "";
            Profile = "";
        }

        public DBActor(int id, string name, int classId, int initialLevel, int maxLevel, int startingEquipId, string characterName, int characterIndex, string battlerName, List<DBTrait> traits, string faceImage, string nickname, string note, string profile)
        {
            Id = id;
            Name = name;
            ClassId = classId;
            InitialLevel = initialLevel;
            MaxLevel = maxLevel;
            StartingEquipId = startingEquipId;
            CharacterName = characterName;
            CharacterIndex = characterIndex;
            BattlerName = battlerName;
            Traits = traits;
            FaceImage = faceImage;
            Nickname = nickname;
            Note = note;
            Profile = profile;
        }



        #endregion

        #region Methods

        #endregion
    }
}
