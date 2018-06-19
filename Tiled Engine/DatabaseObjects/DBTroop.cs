using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBTroop
    {
        private static int MaxMemmbers = 9;

        #region Declarations
        private int id;
        private string name;
        private int[] memmberIds = new int[MaxMemmbers];
        private bool[] hiddenMemmbers = new bool[MaxMemmbers];
        private List<BattleEventPage> eventPages;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int[] MemmberIds { get => memmberIds; set => memmberIds = value; }
        public bool[] HiddenMemmbers { get => hiddenMemmbers; set => hiddenMemmbers = value; }
        public List<BattleEventPage> EventPages { get => eventPages; set => eventPages = value; }
        #endregion

        #region Constructor(s)
        public DBTroop()
        {
            Id = 1;
            Name = "";
            for (int i = 0; i < MaxMemmbers; i++)
            {
                MemmberIds[i] = 0;
                HiddenMemmbers[i] = false;
            }

            eventPages = new List<BattleEventPage>();
        }
        public DBTroop(int id, 
                       string name, 
                       int[] memmberIds, 
                       bool[] hiddenMemmbers, 
                       List<BattleEventPage> eventPages)
        {
            Id = id;
            Name = name;
            MemmberIds = memmberIds;
            HiddenMemmbers = hiddenMemmbers;
            EventPages = eventPages;
        }
        #endregion

        #region Methods

        #endregion

    }
}
