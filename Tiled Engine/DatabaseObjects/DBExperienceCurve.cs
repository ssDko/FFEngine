using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBExperienceCurve : DBObject
    {
        private static int MaxGrowLevels = 98;
        //Todo: Possibly make this have a optional generated curve
        #region Declarations        
        private DBExpLevel[] expCurve = new DBExpLevel[MaxGrowLevels];
        #endregion

        #region Properties        
        public DBExpLevel[] ExpCurve { get => expCurve; set => expCurve = value; }
        #endregion

        #region Constructor(s)
        public DBExperienceCurve()
        {
            Id = 1;
            Name = "";
            for (int i = 0; i < MaxGrowLevels; i++)
            {
                ExpCurve[i] = new DBExpLevel(i + 1, 1);
            }
        }

        public DBExperienceCurve(int id, string name, DBExpLevel[] expCurve)
        {
            Id = id;
            Name = name;
            ExpCurve = expCurve;
        }
        #endregion

        #region Methods
        
        #endregion
    }
}
