using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    public class DBCommonEvent : DBObject
    {
        #region Declarations
        
        private Trigger trigger;
        private int switchId;

        private List<EventCommand> eventCommands;       
        #endregion

        #region Properties        
        public Trigger Trigger { get => trigger; set => trigger = value; }
        public int SwitchId { get => switchId; set => switchId = value; }

        public List<EventCommand> EventCommands { get => eventCommands; set => eventCommands = value; }
        #endregion

        #region Constructor(s)
        public DBCommonEvent()
        {
            Id = 1;
            Name = "";
            Trigger = Trigger.None;
            SwitchId = 0;
            EventCommands = new List<EventCommand>();
        }

        public DBCommonEvent(int id, string name, Trigger trigger, int switchId, List<EventCommand> eventCommands)
        {
            Id = id;
            Name = name;
            Trigger = trigger;
            SwitchId = switchId;
            EventCommands = eventCommands;
        }
        #endregion

        #region Methods

        #endregion

    }
}
