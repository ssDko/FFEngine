using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBEffect
    {
        #region Declaratons
        private Codes code;
        private int dataId;
        private int value1;
        private int value2;
        private Occasion occasion;
        #endregion

        #region Properties
        public int DataId { get => dataId; set => dataId = value; }
        public int Value1 { get => value1; set => value1 = value; }
        public int Value2 { get => value2; set => value2 = value; }
        internal Codes Code { get => code; set => code = value; }
        public Occasion Occasion { get => occasion; set => occasion = value; }


        #endregion

        #region Constructor(s)
        public DBEffect()
        {
            Code = Codes.RecoverHP;
            DataId = 0;
            Value1 = 0;
            Value2 = 0;
            Occasion = Occasion.Always;
        }

        public DBEffect(Codes code,
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
