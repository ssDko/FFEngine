using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBTypes
    {
        #region Declarations
        private List<string> elements;
        private List<string> skillTypes;
        private List<string> weaponTypes;
        private List<string> armorTypes;
        private List<string> enemyTypes;

        #endregion

        #region Properties
        public List<string> Elements { get => elements; set => elements = value; }
        public List<string> SkillTypes { get => skillTypes; set => skillTypes = value; }
        public List<string> WeaponTypes { get => weaponTypes; set => weaponTypes = value; }
        public List<string> ArmorTypes { get => armorTypes; set => armorTypes = value; }
        public List<string> EnemyTypes { get => enemyTypes; set => enemyTypes = value; }
        #endregion

        #region Constructor(s)
        public DBTypes()
        {
            Elements = new List<string>();
            SkillTypes = new List<string>();
            WeaponTypes = new List<string>();
            ArmorTypes = new List<string>();
            EnemyTypes = new List<string>();
        }

        public DBTypes(List<string> elements, 
                       List<string> skillTypes, 
                       List<string> weaponTypes, 
                       List<string> armorTypes, 
                       List<string> enemyTypes)
        {
            Elements = elements;
            SkillTypes = skillTypes;
            WeaponTypes = weaponTypes;
            ArmorTypes = armorTypes;
            EnemyTypes = enemyTypes;
        }


        #endregion

        #region Methods

        #endregion

    }
}
