using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBExperienceCurve
    {
        private static int MaxGrowLevels = 98;
        //Todo: Possibly make this have a optional generated curve
        #region Declarations
        private int id;
        private DBExpLevel[] expCurve = new DBExpLevel[MaxGrowLevels];
        #endregion

        #region Properties
        [XmlAttribute("ID")]
        public int Id { get => id; set => id = value; }
        public DBExpLevel[] ExpCurve { get => expCurve; set => expCurve = value; }
        #endregion

        #region Constructor(s)
        public DBExperienceCurve()
        {
            Id = 1;
            for (int i = 0; i < MaxGrowLevels; i++)
            {
                ExpCurve[i] = new DBExpLevel(i + 1, 1);
            }
        }

        public DBExperienceCurve(int id, DBExpLevel[] expCurve)
        {
            Id = id; 
            ExpCurve = expCurve;
        }
        #endregion

        #region Methods
        
        #endregion
    }
}
