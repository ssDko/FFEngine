using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBExpLevel
    {
        private int level; // Current level
        private int expNeeded;

        [XmlAttribute("Level")]
        public int Level { get => level; set => level = value; }
        [XmlAttribute("ExpNeeded")]
        public int ExpNeeded { get => expNeeded; set => expNeeded = value; }

        public DBExpLevel()
        {
            Level = 1;
            ExpNeeded = 1;
        }

        public DBExpLevel(int level, int expNeeded)
        {
            Level = level;
            ExpNeeded = expNeeded;
        }
    }
}
