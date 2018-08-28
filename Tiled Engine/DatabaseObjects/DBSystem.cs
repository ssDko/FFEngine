using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBSystem : DBObject
    {
        private static int MaxPartySize = 4;
        
        #region Declarations         
        //Resolution settings
        private int scaling;
        private int screenWidth;
        private int screenHeight;
        private bool isFullScreen;

        //Types
        private List<string> elements;
        private List<string> enemyTypes;

        //Systems
        private int[] startingParty = new int[MaxPartySize];
        private List<DBStartingEquipment> startingEquipmentList;

        private string gameTitle;

        private string boatImage;
        private string shipImage;
        private string airshipImage;

        private string currency;

        private Color windowColor;

        private List<int> magicSkillIDs; // Lists what skill types are magic
        
        //Options
        private bool playerFollowers;
        private bool killedBySlipDmg;
        private bool killedByFloorDmg;
        private bool useClassStartEquip;
        private bool useMPInstead;


        //Music
        private SoundFile titleMusic;
        private SoundFile battleMusic;
        private SoundFile victoryMusic;
        private SoundFile defeatMusic;
        private SoundFile gameOverMusic;
        private SoundFile boatMusic;
        private SoundFile shipMusic;
        private SoundFile airshipMusic;

        //Sounds
        private SoundFile cursorFX;
        private SoundFile decisionFX;
        private SoundFile cancelFX;
        private SoundFile buzzerFX;
        private SoundFile equipFX;
        private SoundFile saveFX;
        private SoundFile loadFX;
        private SoundFile battleStartFX;
        private SoundFile escapeFX;
        private SoundFile enemyAttackFX;
        private SoundFile enemyDamageFX;
        private SoundFile enemyCollapseFX;
        private SoundFile bossCollapse1FX;
        private SoundFile bossCollapse2FX;
        private SoundFile actorDamageFX;
        private SoundFile actorCollapseFX;
        private SoundFile recoveryFX;
        private SoundFile missFX;
        private SoundFile evasionFX;
        private SoundFile magicEvasionFX;
        private SoundFile magicReflectionFX;
        private SoundFile shopFX;
        private SoundFile useItemFX;
        private SoundFile useSkillFX;

        //Menu
        private bool itemCommand;
        private bool statusCommand;
        private bool skillCommand;
        private bool formationCommand;
        private bool equipCommand;
        private bool configurationCommand;
        private bool saveCommand;

        //Starting positions
        //Todo

        //Title screen
        private string tileScreenImage;
        private bool drawGameTitle;

        
        #endregion

        #region Properties
        //Resolution settings
        public int Scaling { get => scaling; set => scaling = value; }
        public int ScreenWidth { get => screenWidth; set => screenWidth = value; }
        public int ScreenHeight { get => screenHeight; set => screenHeight = value; }
        public bool IsFullScreen { get => isFullScreen; set => isFullScreen = value; }
        
        //Types
        public List<string> Elements { get => elements; set => elements = value; }
        public List<string> EnemyTypes { get => enemyTypes; set => enemyTypes = value; }

        //Systems
        public int[] StartingParty { get => startingParty; set => startingParty = value; }
        public List<DBStartingEquipment> StartingEquipmentList { get => startingEquipmentList; set => startingEquipmentList = value; }

        public string GameTitle { get => gameTitle; set => gameTitle = value; }

        public string BoatImage { get => boatImage; set => boatImage = value; }
        public string ShipImage { get => shipImage; set => shipImage = value; }
        public string AirshipImage { get => airshipImage; set => airshipImage = value; }

        public string Currency { get => currency; set => currency = value; }

        public Color WindowColor { get => windowColor; set => windowColor = value; }

        public List<int> MagicSkillIDs { get => magicSkillIDs; set => magicSkillIDs = value; }

        //Options
        public bool PlayerFollowers { get => playerFollowers; set => playerFollowers = value; }
        public bool KilledBySlipDmg { get => killedBySlipDmg; set => killedBySlipDmg = value; }
        public bool KilledByFloorDmg { get => killedByFloorDmg; set => killedByFloorDmg = value; }
        public bool UseClassStartEquip { get => useClassStartEquip; set => useClassStartEquip = value; }
        public bool UseMPInstead { get => useMPInstead; set => useMPInstead = value; }
       

        //Music
        public SoundFile TitleMusic { get => titleMusic; set => titleMusic = value; }
        public SoundFile BattleMusic { get => battleMusic; set => battleMusic = value; }
        public SoundFile VictoryMusic { get => victoryMusic; set => victoryMusic = value; }
        public SoundFile DefeatMusic { get => defeatMusic; set => defeatMusic = value; }
        public SoundFile GameOverMusic { get => gameOverMusic; set => gameOverMusic = value; }
        public SoundFile BoatMusic { get => boatMusic; set => boatMusic = value; }
        public SoundFile ShipMusic { get => shipMusic; set => shipMusic = value; }
        public SoundFile AirshipMusic { get => airshipMusic; set => airshipMusic = value; }

        //Sounds
        public SoundFile CursorFX { get => cursorFX; set => cursorFX = value; }
        public SoundFile DecisionFX { get => decisionFX; set => decisionFX = value; }
        public SoundFile CancelFX { get => cancelFX; set => cancelFX = value; }
        public SoundFile BuzzerFX { get => buzzerFX; set => buzzerFX = value; }
        public SoundFile EquipFX { get => equipFX; set => equipFX = value; }
        public SoundFile SaveFX { get => saveFX; set => saveFX = value; }
        public SoundFile LoadFX { get => loadFX; set => loadFX = value; }
        public SoundFile BattleStartFX { get => battleStartFX; set => battleStartFX = value; }
        public SoundFile EscapeFX { get => escapeFX; set => escapeFX = value; }
        public SoundFile EnemyAttackFX { get => enemyAttackFX; set => enemyAttackFX = value; }
        public SoundFile EnemyDamageFX { get => enemyDamageFX; set => enemyDamageFX = value; }
        public SoundFile EnemyCollapseFX { get => enemyCollapseFX; set => enemyCollapseFX = value; }
        public SoundFile BossCollapse1FX { get => bossCollapse1FX; set => bossCollapse1FX = value; }
        public SoundFile BossCollapse2FX { get => bossCollapse2FX; set => bossCollapse2FX = value; }
        public SoundFile ActorDamageFX { get => actorDamageFX; set => actorDamageFX = value; }
        public SoundFile ActorCollapseFX { get => actorCollapseFX; set => actorCollapseFX = value; }
        public SoundFile RecoveryFX { get => recoveryFX; set => recoveryFX = value; }
        public SoundFile MissFX { get => missFX; set => missFX = value; }
        public SoundFile EvasionFX { get => evasionFX; set => evasionFX = value; }
        public SoundFile MagicEvasionFX { get => magicEvasionFX; set => magicEvasionFX = value; }
        public SoundFile MagicReflectionFX { get => magicReflectionFX; set => magicReflectionFX = value; }
        public SoundFile ShopFX { get => shopFX; set => shopFX = value; }
        public SoundFile UseItemFX { get => useItemFX; set => useItemFX = value; }
        public SoundFile UseSkillFX { get => useSkillFX; set => useSkillFX = value; }

        //Menu
        public bool ItemCommand { get => itemCommand; set => itemCommand = value; }
        public bool StatusCommand { get => statusCommand; set => statusCommand = value; }
        public bool SkillCommand { get => skillCommand; set => skillCommand = value; }
        public bool FormationCommand { get => formationCommand; set => formationCommand = value; }
        public bool EquipCommand { get => equipCommand; set => equipCommand = value; }
        public bool ConfigurationCommand { get => configurationCommand; set => configurationCommand = value; }
        public bool SaveCommand { get => saveCommand; set => saveCommand = value; }
       

        //Starting positions
        //Todo

        //Title screen
        public string TileScreenImage { get => tileScreenImage; set => tileScreenImage = value; }
        public bool DrawGameTitle { get => drawGameTitle; set => drawGameTitle = value; }




        #endregion

        #region Constructor(s)
        public DBSystem()
        {
            Id = 1;
            Name = "System Settings";
            Scaling = 4;
            ScreenWidth = 1024;
            ScreenHeight = 960;
            IsFullScreen = false;

            Elements = new List<string>();
            EnemyTypes = new List<string>();

            StartingParty = new int[MaxPartySize];
            StartingEquipmentList = new List<DBStartingEquipment>();

            GameTitle = "";

            BoatImage = "";
            ShipImage = "";
            AirshipImage = "";

            Currency = "Gil";

            WindowColor = Color.Blue;

            MagicSkillIDs = new List<int>();

            PlayerFollowers = false;
            killedBySlipDmg = false;
            KilledByFloorDmg = false;
            UseClassStartEquip = false;
            UseMPInstead = false;

            TitleMusic = new SoundFile("", 100, 100, 0);
            BattleMusic = new SoundFile("", 100, 100, 0);
            VictoryMusic = new SoundFile("", 100, 100, 0);
            DefeatMusic = new SoundFile("", 100, 100, 0);
            GameOverMusic = new SoundFile("", 100, 100, 0);
            BoatMusic = new SoundFile("", 100, 100, 0);
            ShipMusic = new SoundFile("", 100, 100, 0);
            AirshipMusic = new SoundFile("", 100, 100, 0);

            CursorFX = new SoundFile("", 100, 100, 0);
            DecisionFX = new SoundFile("", 100, 100, 0);
            CancelFX = new SoundFile("", 100, 100, 0);
            BuzzerFX = new SoundFile("", 100, 100, 0);
            EquipFX = new SoundFile("", 100, 100, 0);
            SaveFX = new SoundFile("", 100, 100, 0);
            LoadFX = new SoundFile("", 100, 100, 0);
            BattleStartFX = new SoundFile("", 100, 100, 0);
            EscapeFX = new SoundFile("", 100, 100, 0);
            EnemyAttackFX = new SoundFile("", 100, 100, 0);
            EnemyDamageFX = new SoundFile("", 100, 100, 0);
            EnemyCollapseFX = new SoundFile("", 100, 100, 0);
            BossCollapse1FX = new SoundFile("", 100, 100, 0);
            BossCollapse2FX = new SoundFile("", 100, 100, 0);
            ActorDamageFX = new SoundFile("", 100, 100, 0);
            ActorCollapseFX = new SoundFile("", 100, 100, 0);
            RecoveryFX = new SoundFile("", 100, 100, 0);
            MissFX = new SoundFile("", 100, 100, 0);
            EvasionFX = new SoundFile("", 100, 100, 0);
            MagicEvasionFX = new SoundFile("", 100, 100, 0);
            MagicReflectionFX = new SoundFile("", 100, 100, 0);
            ShopFX = new SoundFile("", 100, 100, 0);
            UseItemFX = new SoundFile("", 100, 100, 0);
            UseSkillFX = new SoundFile("", 100, 100, 0);
    }

        public DBSystem(int scaling, int screenWidth, int screenHeight, bool isFullScreen, List<string> elements, List<string> enemyTypes, int[] startingParty, 
                        List<DBStartingEquipment> startingEquipmentList, string gameTitle, string boatImage, string shipImage, string airshipImage, string currency, 
                        Color windowColor, List<int> magicSkillIDs, bool playerFollowers, bool killedBySlipDmg, bool killedByFloorDmg, bool useClassStartEquip, bool useMPInstead, 
                        SoundFile titleMusic, SoundFile battleMusic, SoundFile victoryMusic, SoundFile defeatMusic, SoundFile gameOverMusic, SoundFile boatMusic, SoundFile shipMusic, 
                        SoundFile airshipMusic, SoundFile cursorFX, SoundFile decisionFX, SoundFile cancelFX, SoundFile buzzerFX, SoundFile equipFX, SoundFile saveFX, SoundFile loadFX, 
                        SoundFile battleStartFX, SoundFile escapeFX, SoundFile enemyAttackFX, SoundFile enemyDamageFX, SoundFile enemyCollapseFX, SoundFile bossCollapse1FX, SoundFile bossCollapse2FX, 
                        SoundFile actorDamageFX, SoundFile actorCollapseFX, SoundFile recoveryFX, SoundFile missFX, SoundFile evasionFX, SoundFile magicEvasionFX, SoundFile magicReflectionFX, 
                        SoundFile shopFX, SoundFile useItemFX, SoundFile useSkillFX, bool itemCommand, bool statusCommand, bool skillCommand, bool formationCommand, bool equipCommand, 
                        bool configurationCommand, bool saveCommand, string tileScreenImage, bool drawGameTitle)
        {
            Id = 1;
            Name = "System Settings";
            Scaling = scaling;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            IsFullScreen = isFullScreen;
            Elements = elements;
            EnemyTypes = enemyTypes;
            StartingParty = startingParty;
            StartingEquipmentList = startingEquipmentList;
            GameTitle = gameTitle;
            BoatImage = boatImage;
            ShipImage = shipImage;
            AirshipImage = airshipImage;
            Currency = currency;
            WindowColor = windowColor;
            MagicSkillIDs = magicSkillIDs;
            PlayerFollowers = playerFollowers;
            KilledBySlipDmg = killedBySlipDmg;
            KilledByFloorDmg = killedByFloorDmg;
            UseClassStartEquip = useClassStartEquip;
            UseMPInstead = useMPInstead;
            TitleMusic = titleMusic;
            BattleMusic = battleMusic;
            VictoryMusic = victoryMusic;
            DefeatMusic = defeatMusic;
            GameOverMusic = gameOverMusic;
            BoatMusic = boatMusic;
            ShipMusic = shipMusic;
            AirshipMusic = airshipMusic;
            CursorFX = cursorFX;
            DecisionFX = decisionFX;
            CancelFX = cancelFX;
            BuzzerFX = buzzerFX;
            EquipFX = equipFX;
            SaveFX = saveFX;
            LoadFX = loadFX;
            BattleStartFX = battleStartFX;
            EscapeFX = escapeFX;
            EnemyAttackFX = enemyAttackFX;
            EnemyDamageFX = enemyDamageFX;
            EnemyCollapseFX = enemyCollapseFX;
            BossCollapse1FX = bossCollapse1FX;
            BossCollapse2FX = bossCollapse2FX;
            ActorDamageFX = actorDamageFX;
            ActorCollapseFX = actorCollapseFX;
            RecoveryFX = recoveryFX;
            MissFX = missFX;
            EvasionFX = evasionFX;
            MagicEvasionFX = magicEvasionFX;
            MagicReflectionFX = magicReflectionFX;
            ShopFX = shopFX;
            UseItemFX = useItemFX;
            UseSkillFX = useSkillFX;
            ItemCommand = itemCommand;
            StatusCommand = statusCommand;
            SkillCommand = skillCommand;
            FormationCommand = formationCommand;
            EquipCommand = equipCommand;
            ConfigurationCommand = configurationCommand;
            SaveCommand = saveCommand;
            TileScreenImage = tileScreenImage;
            DrawGameTitle = drawGameTitle;
        }
        #endregion
    }
}
