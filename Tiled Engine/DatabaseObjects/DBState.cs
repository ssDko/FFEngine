using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBState : DBObject
    {
        #region Declarations        
        private int iconId;
        private Restriction restriction;
        private int priority;
        private BattlerStateAnimation battlerAnimation;
        private BattlerStateOverlay battlerOverlay;

        //Removal Conditions
        private bool byBattleEnd;
        private bool byRestriciton;
        private AutoRemoveTiming removalTiming;
        private int timerLowerLimit;
        private int timerUpperLimit;        
        private bool byDamage;
        private int damagePercent;
        private bool bySteps;
        private int numberOfSteps;

        //Messages
        private string actorInflictedMsg;
        private string enemyInflictedMsg;
        private string statePersistsMsg;
        private string stateRemovedMsg;

        private List<DBTrait> traits;

        private string note;        
        #endregion

        #region Properties        
        public int IconId { get => iconId; set => iconId = value; }
        public Restriction Restriction { get => restriction; set => restriction = value; }
        public int Priority { get => priority; set => priority = value; }
        public BattlerStateAnimation BattlerAnimation { get => battlerAnimation; set => battlerAnimation = value; }
        public BattlerStateOverlay BattlerOverlay { get => battlerOverlay; set => battlerOverlay = value; }

        public bool ByBattleEnd { get => byBattleEnd; set => byBattleEnd = value; }
        public bool ByRestriciton { get => byRestriciton; set => byRestriciton = value; }
        public AutoRemoveTiming RemovalTiming { get => removalTiming; set => removalTiming = value; }
        public int TimerLowerLimit { get => timerLowerLimit; set => timerLowerLimit = value; }
        public int TimerUpperLimit { get => timerUpperLimit; set => timerUpperLimit = value; }        
        public bool ByDamage { get => byDamage; set => byDamage = value; }
        public int DamagePercent { get => damagePercent; set => damagePercent = value; }
        public bool BySteps { get => bySteps; set => bySteps = value; }
        public int NumberOfSteps { get => numberOfSteps; set => numberOfSteps = value; }

        public string ActorInflictedMsg { get => actorInflictedMsg; set => actorInflictedMsg = value; }
        public string EnemyInflictedMsg { get => enemyInflictedMsg; set => enemyInflictedMsg = value; }
        public string StatePersistsMsg { get => statePersistsMsg; set => statePersistsMsg = value; }
        public string StateRemovedMsg { get => stateRemovedMsg; set => stateRemovedMsg = value; }

        public List<DBTrait> Traits { get => traits; set => traits = value; }

        public string Note { get => note; set => note = value; }
        #endregion

        #region Constructor(s)
        public DBState()
        {
            Id = 1;
            Name = "";
            IconId = 0;
            Restriction = Restriction.None;
            Priority = 50;
            BattlerAnimation = BattlerStateAnimation.Normal;
            BattlerOverlay = BattlerStateOverlay.None;

            ByBattleEnd = false;
            ByRestriciton = false;
            RemovalTiming = AutoRemoveTiming.None;
            TimerLowerLimit = 1;
            TimerUpperLimit = 1;
            ByDamage = false;
            DamagePercent = 100;
            BySteps = false;
            NumberOfSteps = 100;

            ActorInflictedMsg = "";
            EnemyInflictedMsg = "";
            StatePersistsMsg = "";
            StateRemovedMsg = "";

            Traits = new List<DBTrait>();

            Note = "";            
        }

        public DBState(int id, 
                       string name, 
                       int iconId, 
                       Restriction restriction, 
                       int priority, 
                       BattlerStateAnimation battlerAnimation, 
                       BattlerStateOverlay battlerOverlay, 
                       bool byBattleEnd, 
                       bool byRestriciton, 
                       AutoRemoveTiming removalTiming,
                       int timerLowerLimit,
                       int timerUpperLimit,                      
                       bool byDamage, 
                       int damagePercent, 
                       bool bySteps, 
                       int numberOfSteps, 
                       string actorInflictedMsg, 
                       string enemyInflictedMsg, 
                       string statePersistsMsg, 
                       string stateRemovedMsg, 
                       List<DBTrait> traits, 
                       string note)
        {
            Id = id;
            Name = name;
            IconId = iconId;
            Restriction = restriction;
            Priority = priority;
            BattlerAnimation = battlerAnimation;
            BattlerOverlay = battlerOverlay;
            ByBattleEnd = byBattleEnd;
            ByRestriciton = byRestriciton;
            RemovalTiming = removalTiming;
            TimerLowerLimit = timerLowerLimit;
            TimerUpperLimit = timerUpperLimit;            
            ByDamage = byDamage;
            DamagePercent = damagePercent;
            BySteps = bySteps;
            NumberOfSteps = numberOfSteps;
            ActorInflictedMsg = actorInflictedMsg;
            EnemyInflictedMsg = enemyInflictedMsg;
            StatePersistsMsg = statePersistsMsg;
            StateRemovedMsg = stateRemovedMsg;
            Traits = traits;
            Note = note;
        }
        #endregion

        #region Methods

        #endregion

    }
}
