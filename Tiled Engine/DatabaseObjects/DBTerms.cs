using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBTerms
    {
        #region Declarations
        // Stats
        private string level;
        private string levelAbbr;
        private string hp;
        private string hpAbbr;
        private string mp;
        private string mpAbbr;
        private string magic;
        private string spellSlot;
        private string spellSlotAbbr;
        private string exp;
        private string expAbbr;

        // Parameters
        private string maxHp;
        private string maxMp;
        private string maxSpellSlots;
        private string strength;
        private string agility;
        private string intellegence;
        private string stamina;
        private string luck;

        private string attack;
        private string accuracy;
        private string defense;
        private string evasion;

        // Commands        
        private string cmdEscape;
        private string cmdAttack;
        private string cmdGuard;
        private string cmdItem;
        private string cmdSkill;
        private string cmdEquip;
        private string cmdStatus;
        private string cmdFormation;
        private string cmdOptions;
        private string cmdSave;
        private string cmdGameEnd;

        private string termWeapon;
        private string termArmor;
        private string termKeyItem;
        private string termEquip;
        private string termOptimize;
        private string termClear;
        private string termBuy;
        private string termSell;
        private string termNewGame;
        private string termContinue;
        private string termToTitle;
        private string termCancel;

        // Messages
        private string msgAlwaysDash;
        private string msgRememberCommand;
        private string msgVolumeBGM;
        private string msgVolumeBGS;
        private string msgVolumeME;
        private string msgVolumeSE;
        private string msgPossession;
        private string msgTotalEXP;
        private string msgNextEXP;
        private string msgSaveMessage;
        private string msgLoadMessage;
        private string msgFile;
        private string msgPartyName;       
        private string msgEscapeStart;
        private string msgEscapeFailure;
        private string msgVictory;
        private string msgDefeat;
        private string msgObtainEXP;
        private string msgObtainGold;
        private string msgObtainItem;
        private string msgLevelUp;
        private string msgObtainSkill;
        private string msgUseItem;
        private string msgCriticalToEnemy;
        private string msgCriticalToActor;
        private string msgActorDamage;
        private string msgActorRecovery;
        private string msgActorGain;
        private string msgActorLoss;
        private string msgActorDrain;
        private string msgActorNoDamage;
        private string msgActorNoHit;
        private string msgEnemyDamage;
        private string msgEnemyRecovery;
        private string msgEnemyLoss;
        private string msgEnemyDrain;
        private string msgEnemyNoDamage;
        private string msgEnemyNoHit;
        private string msgEvasion;
        private string msgMagicEvasion;
        private string msgMagicReflection;
        private string msgCounterAttack;
        private string msgSubstitue;
        private string msgBuffAdd;
        private string msgDebuffAdd;
        private string msgBuffRemove;
        private string msgActionFailure;

        
        #endregion

        #region Properties
        public string Level { get => level; set => level = value; }
        public string LevelAbbr { get => levelAbbr; set => levelAbbr = value; }
        public string Hp { get => hp; set => hp = value; }
        public string HpAbbr { get => hpAbbr; set => hpAbbr = value; }
        public string Mp { get => mp; set => mp = value; }
        public string MpAbbr { get => mpAbbr; set => mpAbbr = value; }
        public string Magic { get => magic; set => magic = value; }
        public string SpellSlot { get => spellSlot; set => spellSlot = value; }
        public string SpellSlotAbbr { get => spellSlotAbbr; set => spellSlotAbbr = value; }
        public string Exp { get => exp; set => exp = value; }
        public string ExpAbbr { get => expAbbr; set => expAbbr = value; }

        public string MaxHp { get => maxHp; set => maxHp = value; }
        public string MaxMp { get => maxMp; set => maxMp = value; }
        public string MaxSpellSlots { get => maxSpellSlots; set => maxSpellSlots = value; }
        public string Strength { get => strength; set => strength = value; }
        public string Agility { get => agility; set => agility = value; }
        public string Intellegence { get => intellegence; set => intellegence = value; }
        public string Stamina { get => stamina; set => stamina = value; }
        public string Luck { get => luck; set => luck = value; }

        public string Attack { get => attack; set => attack = value; }
        public string Accuracy { get => accuracy; set => accuracy = value; }
        public string Defense { get => defense; set => defense = value; }
        public string Evasion { get => evasion; set => evasion = value; }

        public string CmdEscape { get => cmdEscape; set => cmdEscape = value; }
        public string CmdAttack { get => cmdAttack; set => cmdAttack = value; }
        public string CmdGuard { get => cmdGuard; set => cmdGuard = value; }
        public string CmdItem { get => cmdItem; set => cmdItem = value; }
        public string CmdSkill { get => cmdSkill; set => cmdSkill = value; }
        public string CmdEquip { get => cmdEquip; set => cmdEquip = value; }
        public string CmdStatus { get => cmdStatus; set => cmdStatus = value; }
        public string CmdFormation { get => cmdFormation; set => cmdFormation = value; }
        public string CmdOptions { get => cmdOptions; set => cmdOptions = value; }
        public string CmdSave { get => cmdSave; set => cmdSave = value; }
        public string CmdGameEnd { get => cmdGameEnd; set => cmdGameEnd = value; }

        public string TermWeapon { get => termWeapon; set => termWeapon = value; }
        public string TermArmor { get => termArmor; set => termArmor = value; }
        public string TermKeyItem { get => termKeyItem; set => termKeyItem = value; }
        public string TermEquip { get => termEquip; set => termEquip = value; }
        public string TermOptimize { get => termOptimize; set => termOptimize = value; }
        public string TermClear { get => termClear; set => termClear = value; }
        public string TermBuy { get => termBuy; set => termBuy = value; }
        public string TermSell { get => termSell; set => termSell = value; }
        public string TermNewGame { get => termNewGame; set => termNewGame = value; }
        public string TermContinue { get => termContinue; set => termContinue = value; }
        public string TermToTitle { get => termToTitle; set => termToTitle = value; }
        public string TermCancel { get => termCancel; set => termCancel = value; }

        public string MsgAlwaysDash { get => msgAlwaysDash; set => msgAlwaysDash = value; }
        public string MsgRememberCommand { get => msgRememberCommand; set => msgRememberCommand = value; }
        public string MsgVolumeBGM { get => msgVolumeBGM; set => msgVolumeBGM = value; }
        public string MsgVolumeBGS { get => msgVolumeBGS; set => msgVolumeBGS = value; }
        public string MsgVolumeME { get => msgVolumeME; set => msgVolumeME = value; }
        public string MsgVolumeSE { get => msgVolumeSE; set => msgVolumeSE = value; }
        public string MsgPossession { get => msgPossession; set => msgPossession = value; }
        public string MsgTotalEXP { get => msgTotalEXP; set => msgTotalEXP = value; }
        public string MsgNextEXP { get => msgNextEXP; set => msgNextEXP = value; }
        public string MsgSaveMessage { get => msgSaveMessage; set => msgSaveMessage = value; }
        public string MsgLoadMessage { get => msgLoadMessage; set => msgLoadMessage = value; }
        public string MsgFile { get => msgFile; set => msgFile = value; }
        public string MsgPartyName { get => msgPartyName; set => msgPartyName = value; }        
        public string MsgEscapeStart { get => msgEscapeStart; set => msgEscapeStart = value; }
        public string MsgEscapeFailure { get => msgEscapeFailure; set => msgEscapeFailure = value; }
        public string MsgVictory { get => msgVictory; set => msgVictory = value; }
        public string MsgDefeat { get => msgDefeat; set => msgDefeat = value; }
        public string MsgObtainEXP { get => msgObtainEXP; set => msgObtainEXP = value; }
        public string MsgObtainGold { get => msgObtainGold; set => msgObtainGold = value; }
        public string MsgObtainItem { get => msgObtainItem; set => msgObtainItem = value; }
        public string MsgLevelUp { get => msgLevelUp; set => msgLevelUp = value; }
        public string MsgObtainSkill { get => msgObtainSkill; set => msgObtainSkill = value; }
        public string MsgUseItem { get => msgUseItem; set => msgUseItem = value; }
        public string MsgCriticalToEnemy { get => msgCriticalToEnemy; set => msgCriticalToEnemy = value; }
        public string MsgCriticalToActor { get => msgCriticalToActor; set => msgCriticalToActor = value; }
        public string MsgActorDamage { get => msgActorDamage; set => msgActorDamage = value; }
        public string MsgActorRecovery { get => msgActorRecovery; set => msgActorRecovery = value; }
        public string MsgActorGain { get => msgActorGain; set => msgActorGain = value; }
        public string MsgActorLoss { get => msgActorLoss; set => msgActorLoss = value; }
        public string MsgActorDrain { get => msgActorDrain; set => msgActorDrain = value; }
        public string MsgActorNoDamage { get => msgActorNoDamage; set => msgActorNoDamage = value; }
        public string MsgActorNoHit { get => msgActorNoHit; set => msgActorNoHit = value; }
        public string MsgEnemyDamage { get => msgEnemyDamage; set => msgEnemyDamage = value; }
        public string MsgEnemyRecovery { get => msgEnemyRecovery; set => msgEnemyRecovery = value; }
        public string MsgEnemyLoss { get => msgEnemyLoss; set => msgEnemyLoss = value; }
        public string MsgEnemyDrain { get => msgEnemyDrain; set => msgEnemyDrain = value; }
        public string MsgEnemyNoDamage { get => msgEnemyNoDamage; set => msgEnemyNoDamage = value; }
        public string MsgEnemyNoHit { get => msgEnemyNoHit; set => msgEnemyNoHit = value; }
        public string MsgEvasion { get => msgEvasion; set => msgEvasion = value; }
        public string MsgMagicEvasion { get => msgMagicEvasion; set => msgMagicEvasion = value; }
        public string MsgMagicReflection { get => msgMagicReflection; set => msgMagicReflection = value; }
        public string MsgCounterAttack { get => msgCounterAttack; set => msgCounterAttack = value; }
        public string MsgSubstitue { get => msgSubstitue; set => msgSubstitue = value; }
        public string MsgBuffAdd { get => msgBuffAdd; set => msgBuffAdd = value; }
        public string MsgDebuffAdd { get => msgDebuffAdd; set => msgDebuffAdd = value; }
        public string MsgBuffRemove { get => msgBuffRemove; set => msgBuffRemove = value; }
        public string MsgActionFailure { get => msgActionFailure; set => msgActionFailure = value; }
        
        #endregion

        #region Constructor(s)
        public DBTerms()
        {
            Level = "Level";
            LevelAbbr = "Lv.";
            Hp = "HP";
            HpAbbr = "HP";
            Mp = "MP";
            MpAbbr = "MP";
            Magic = "Magic";
            SpellSlot = "Level %1";
            SpellSlotAbbr = "L:%1";
            Exp = "Experience";
            ExpAbbr = "EXP";
            MaxHp = "Max HP";
            MaxMp = "Max MP";
            MaxSpellSlots = "Max spell slots for L:%1";
            Strength = "Strength";
            Agility = "Agility";
            Intellegence = "Intellegence";
            Stamina = "Stamina";
            Luck = "Luck";
            Attack = "Attack";
            Accuracy = "Accuracy";
            Defense = "Defense";
            Evasion = "Evasion";            
            CmdEscape ="Flee";
            CmdAttack = "Attack";
            CmdGuard = "Defend";
            CmdItem = "Items";
            CmdSkill = "Skill";
            CmdEquip = "Equip";
            CmdStatus = "Status";
            CmdFormation = "Formation";
            CmdOptions = "Configuration";
            CmdSave = "Save";
            CmdGameEnd = "Quit";
            TermWeapon = "Weapon";
            TermArmor = "Armor";
            TermKeyItem = "Key Items";
            TermEquip = "Equip";
            TermOptimize = "Optimal";
            TermClear = "Clear";
            TermBuy = "Buy";
            TermSell = "Sell";
            TermNewGame = "New Game";
            TermContinue = "Load Game";
            TermToTitle = "To Tile Screen";
            TermCancel = "Cancel";
            MsgAlwaysDash = "Dash";
            MsgRememberCommand = "Remember Command";
            MsgVolumeBGM = "BGM Volume";
            MsgVolumeBGS = "BGS Volume";
            MsgVolumeME = "ME Volume";
            MsgVolumeSE = "SE Volume";
            MsgPossession = "Possession";
            MsgTotalEXP = "Current EXP /t %1";
            MsgNextEXP = "Next Level /t %1";
            MsgSaveMessage = "Select a file?";
            MsgLoadMessage = "Select a file to load.";
            MsgFile ="File";
            MsgPartyName = "%1's Party";            
            MsgEscapeStart = "%1 has started to escape!";
            MsgEscapeFailure = "However, it was unable to escape!";
            MsgVictory = "%1 was victor";
            MsgDefeat = msgDefeat;
            MsgObtainEXP = msgObtainEXP;
            MsgObtainGold = msgObtainGold;
            MsgObtainItem = msgObtainItem;
            MsgLevelUp = msgLevelUp;
            MsgObtainSkill = msgObtainSkill;
            MsgUseItem = msgUseItem;
            MsgCriticalToEnemy = msgCriticalToEnemy;
            MsgCriticalToActor = msgCriticalToActor;
            MsgActorDamage = msgActorDamage;
            MsgActorRecovery = msgActorRecovery;
            MsgActorGain = msgActorGain;
            MsgActorLoss = msgActorLoss;
            MsgActorDrain = msgActorDrain;
            MsgActorNoDamage = msgActorNoDamage;
            MsgActorNoHit = msgActorNoHit;
            MsgEnemyDamage = msgEnemyDamage;
            MsgEnemyRecovery = msgEnemyRecovery;
            MsgEnemyLoss = msgEnemyLoss;
            MsgEnemyDrain = msgEnemyDrain;
            MsgEnemyNoDamage = msgEnemyNoDamage;
            MsgEnemyNoHit = msgEnemyNoHit;
            MsgEvasion = msgEvasion;
            MsgMagicEvasion = msgMagicEvasion;
            MsgMagicReflection = msgMagicReflection;
            MsgCounterAttack = msgCounterAttack;
            MsgSubstitue = msgSubstitue;
            MsgBuffAdd = msgBuffAdd;
            MsgDebuffAdd = msgDebuffAdd;
            MsgBuffRemove = msgBuffRemove;
            MsgActionFailure = msgActionFailure;

        }




        public DBTerms(string level, string levelAbbr, string hp, string hpAbbr, string mp, string mpAbbr, string spellSlot, string spellSlotAbbr, string exp, string expAbbr, string maxHp,
                       string maxMp, string maxSpellSlots, string strength, string agility, string intellegence, string stamina, string luck, string attack, string accuracy, string defense,
                       string evasion, string cmdEscape, string cmdAttack, string cmdGuard, string cmdItem, string cmdSkill, string cmdEquip, string cmdStatus, string cmdFormation,
                       string cmdOptions, string cmdSave, string cmdGameEnd, string termWeapon, string termArmor, string termKeyItem, string termEquip, string termOptimize, string termClear,
                       string termBuy, string termSell, string termNewGame, string termContinue, string termToTitle, string termCancel, string msgAlwaysDash, string msgRememberCommand,
                       string msgVolumeBGM, string msgVolumeBGS, string msgVolumeME, string msgVolumeSE, string msgPossession, string msgTotalEXP, string msgNextEXP, string msgSaveMessage,
                       string msgLoadMessage, string msgFile, string msgPartyName, string msgEscapeStart, string msgEscapeFailure,
                       string msgVictory, string msgDefeat, string msgObtainEXP, string msgObtainGold, string msgObtainItem, string msgLevelUp, string msgObtainSkill, string msgUseItem,
                       string msgCriticalToEnemy, string msgCriticalToActor, string msgActorDamage, string msgActorRecovery, string msgActorGain, string msgActorLoss, string msgActorDrain,
                       string msgActorNoDamage, string msgActorNoHit, string msgEnemyDamage, string msgEnemyRecovery, string msgEnemyLoss, string msgEnemyDrain, string msgEnemyNoDamage,
                       string msgEnemyNoHit, string msgEvasion, string msgMagicEvasion, string msgMagicReflection, string msgCounterAttack, string msgSubstitue, string msgBuffAdd, string msgDebuffAdd,
                       string msgBuffRemove, string msgActionFailure)
        {
            Level = level;
            LevelAbbr = levelAbbr;
            Hp = hp;
            HpAbbr = hpAbbr;
            Mp = mp;
            MpAbbr = mpAbbr;
            SpellSlot = spellSlot;
            SpellSlotAbbr = spellSlotAbbr;
            Exp = exp;
            ExpAbbr = expAbbr;
            MaxHp = maxHp;
            MaxMp = maxMp;
            MaxSpellSlots = maxSpellSlots;
            Strength = strength;
            Agility = agility;
            Intellegence = intellegence;
            Stamina = stamina;
            Luck = luck;
            Attack = attack;
            Accuracy = accuracy;
            Defense = defense;
            Evasion = evasion;            
            CmdEscape = cmdEscape;
            CmdAttack = cmdAttack;
            CmdGuard = cmdGuard;
            CmdItem = cmdItem;
            CmdSkill = cmdSkill;
            CmdEquip = cmdEquip;
            CmdStatus = cmdStatus;
            CmdFormation = cmdFormation;
            CmdOptions = cmdOptions;
            CmdSave = cmdSave;
            CmdGameEnd = cmdGameEnd;
            TermWeapon = termWeapon;
            TermArmor = termArmor;
            TermKeyItem = termKeyItem;
            TermEquip = termEquip;
            TermOptimize = termOptimize;
            TermClear = termClear;
            TermBuy = termBuy;
            TermSell = termSell;
            TermNewGame = termNewGame;
            TermContinue = termContinue;
            TermToTitle = termToTitle;
            TermCancel = termCancel;
            MsgAlwaysDash = msgAlwaysDash;
            MsgRememberCommand = msgRememberCommand;
            MsgVolumeBGM = msgVolumeBGM;
            MsgVolumeBGS = msgVolumeBGS;
            MsgVolumeME = msgVolumeME;
            MsgVolumeSE = msgVolumeSE;
            MsgPossession = msgPossession;
            MsgTotalEXP = msgTotalEXP;
            MsgNextEXP = msgNextEXP;
            MsgSaveMessage = msgSaveMessage;
            MsgLoadMessage = msgLoadMessage;
            MsgFile = msgFile;
            MsgPartyName = msgPartyName;            
            MsgEscapeStart = msgEscapeStart;
            MsgEscapeFailure = msgEscapeFailure;
            MsgVictory = msgVictory;
            MsgDefeat = msgDefeat;
            MsgObtainEXP = msgObtainEXP;
            MsgObtainGold = msgObtainGold;
            MsgObtainItem = msgObtainItem;
            MsgLevelUp = msgLevelUp;
            MsgObtainSkill = msgObtainSkill;
            MsgUseItem = msgUseItem;
            MsgCriticalToEnemy = msgCriticalToEnemy;
            MsgCriticalToActor = msgCriticalToActor;
            MsgActorDamage = msgActorDamage;
            MsgActorRecovery = msgActorRecovery;
            MsgActorGain = msgActorGain;
            MsgActorLoss = msgActorLoss;
            MsgActorDrain = msgActorDrain;
            MsgActorNoDamage = msgActorNoDamage;
            MsgActorNoHit = msgActorNoHit;
            MsgEnemyDamage = msgEnemyDamage;
            MsgEnemyRecovery = msgEnemyRecovery;
            MsgEnemyLoss = msgEnemyLoss;
            MsgEnemyDrain = msgEnemyDrain;
            MsgEnemyNoDamage = msgEnemyNoDamage;
            MsgEnemyNoHit = msgEnemyNoHit;
            MsgEvasion = msgEvasion;
            MsgMagicEvasion = msgMagicEvasion;
            MsgMagicReflection = msgMagicReflection;
            MsgCounterAttack = msgCounterAttack;
            MsgSubstitue = msgSubstitue;
            MsgBuffAdd = msgBuffAdd;
            MsgDebuffAdd = msgDebuffAdd;
            MsgBuffRemove = msgBuffRemove;
            MsgActionFailure = msgActionFailure;
        }
        #endregion

        #region Methods

        #endregion

    }
}
