using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBTrait
    {
        #region Declaratons
        private Codes code;
        private int dataId;
        private int value1;
        private int value2;
        private Occasion occasion;
        #endregion

        #region Properties
        public Codes Code { get => code; set => code = value; }
        public int DataId { get => dataId; set => dataId = value; }
        public int Value1 { get => value1; set => value1 = value; }
        public int Value2 { get => value2; set => value2 = value; }       
        public Occasion Occasion { get => occasion; set => occasion = value; }


        #endregion

        #region Constructor(s)
        public DBTrait()
        {
            code = Codes.RecoverHP;
            dataId = 0;
            value1 = 0;
            value2 = 0;
            occasion = Occasion.Always;
        }

        public DBTrait(Codes code,
                        int dataId,
                        int value1,
                        int value2,
                        Occasion occasion)
        {
            Code = code;
            DataId = dataId;
            Value1 = value1;
            Value2 = value2;
            Occasion = occasion;
        }
        #endregion
    }

    
}
