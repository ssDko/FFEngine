using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBStartingEquipment
    {
        private static int NumOfSlots = 5;
        #region Declarations
        private int id;
        private int[] equips = new int[NumOfSlots];
        private int associatedId;
        #endregion

        #region Properties
        [XmlAttribute("ID")]
        public int Id { get => id; set => id = value; }
        public int[] Equips { get => equips; set => equips = value; }
        public int AssociatedId { get => associatedId; set => associatedId = value; }
        #endregion

        #region Constructor(s)
        public DBStartingEquipment()
        {
            Id = 1;
            Equips = new int[] { 0, 0, 0, 0, 0};
            AssociatedId = 1;
        }

        public DBStartingEquipment(int id, int[] equips, int associatedId)
        {
            Id = id;
            Equips = equips;
            AssociatedId = associatedId;
        }
        #endregion
    }
}
