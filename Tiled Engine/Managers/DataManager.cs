using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TiledEngine.DatabaseObjects;

namespace TiledEngine.Managers
{
    public static class DataManager
    {
        #region Declarations
        // Database objects
        private static List<DBActor> dataActors = new List<DBActor>();
        private static List<DBClass> dataClasses = new List<DBClass>();
        private static List<DBExperienceCurve> dataExpCurves = new List<DBExperienceCurve>();
        private static List<DBSkill> dataSkills = new List<DBSkill>();
        private static List<DBItem> dataItems = new List<DBItem>();
        private static List<DBWeapon> dataWeapons = new List<DBWeapon>();
        private static List<DBArmor> dataArmors = new List<DBArmor>();
        private static List<DBEnemy> dataEnemies = new List<DBEnemy>();
        private static List<DBTroop> dataTroops = new List<DBTroop>();
        private static List<DBState> dataStates = new List<DBState>();
        private static List<DBAnimation> dataAnimations = new List<DBAnimation>();
        private static List<DBTileset> dataTilesets = new List<DBTileset>();
        private static List<DBCommonEvent> dataCommonEvents = new List<DBCommonEvent>();
        private static List<DBSystem> dataSystems = new List<DBSystem>();
        private static List<DBMapInfo> dataMapsInfo = new List<DBMapInfo>();
        private static List<DBMap> dataMaps = new List<DBMap>();
        private static List<DBTypes> dataTypes = new List<DBTypes>();
        // Game objects - Todo

        private static string Path = @"Content\Data\";

        // Listing of files associated with the appropriate database        
        private static Dictionary<string, string> databaseFiles = new Dictionary<string, string>();

        public static List<DBActor> DataActors { get => dataActors; private set => dataActors = value; }
        public static List<DBClass> DataClasses { get => dataClasses; private set => dataClasses = value; }
        public static List<DBExperienceCurve> DataExpCurves { get => dataExpCurves; private set => dataExpCurves = value; }
        public static List<DBSkill> DataSkills { get => dataSkills; private set => dataSkills = value; }
        public static List<DBItem> DBItems { get => dataItems; private set => dataItems = value; }
        public static List<DBWeapon> DataWeapons { get => dataWeapons; private set => dataWeapons = value; }
        public static List<DBArmor> DataArmors { get => dataArmors; private set => dataArmors = value; }
        public static List<DBEnemy> DataEnemies { get => dataEnemies; private set => dataEnemies = value; }
        public static List<DBTroop> DataTroops { get => dataTroops; private set => dataTroops = value; }
        public static List<DBState> DataStates { get => dataStates; private set => dataStates = value; }
        public static List<DBAnimation> DataAnimations { get => dataAnimations; private set => dataAnimations = value; }
        public static List<DBTileset> DataTilesets { get => dataTilesets; private set => dataTilesets = value; }
        public static List<DBCommonEvent> DataCommonEvents { get => dataCommonEvents; private set => dataCommonEvents = value; }        
        public static List<DBMapInfo> DataMapsInfo { get => dataMapsInfo; private set => dataMapsInfo = value; }
        public static List<DBMap> DataMaps { get => dataMaps; private set => dataMaps = value; }
        public static List<DBSystem> DataSystems { get => dataSystems; private set => dataSystems = value; }
        public static List<DBTypes> DataTypes { get => dataTypes; set => dataTypes = value; }
        #endregion


        #region Constructor(s)
        static DataManager()
        {
            // Set file associations
            databaseFiles.Add("dataActors", "Actors.xml");
            databaseFiles.Add("dataClasses", "Classes.xml");
            databaseFiles.Add("dataExpCurves", "ExperienceCurves.xml");
            databaseFiles.Add("dataSkills", "Skills.xml");
            databaseFiles.Add("dataItems", "Items.xml");
            databaseFiles.Add("dataWeapons", "Weapons.xml");
            databaseFiles.Add("dataArmors", "Armors.xml");
            databaseFiles.Add("dataEnemies","Enemies.xml");
            databaseFiles.Add("dataTroops", "Troops.xml");
            databaseFiles.Add("dataStates", "States.xml");
            databaseFiles.Add("dataAnimations", "Animations.xml");
            databaseFiles.Add("dataTilesets", "Tilesets.json");
            databaseFiles.Add("dataCommonEvents", "CommonEvents.xml");
            databaseFiles.Add("dataSystems", "System.xml");
            databaseFiles.Add("dataMapsInfo", "MapsInfo.xml");
            databaseFiles.Add("dataTypes", "Types.xml");


            //LoadDataBase();
        }


        #endregion

        #region Methods
        public static void LoadDataBase()
        {            
            LoadDataFile(out dataActors, databaseFiles[nameof(dataActors)]);
            LoadDataFile(out dataClasses, databaseFiles[nameof(dataClasses)]);
            LoadDataFile(out dataExpCurves, databaseFiles[nameof(dataExpCurves)]);
            LoadDataFile(out dataSkills, databaseFiles[nameof(dataSkills)]);
            LoadDataFile(out dataItems, databaseFiles[nameof(dataItems)]);
            LoadDataFile(out dataWeapons, databaseFiles[nameof(dataWeapons)]);
            LoadDataFile(out dataArmors, databaseFiles[nameof(dataArmors)]);
            LoadDataFile(out dataEnemies, databaseFiles[nameof(dataEnemies)]);
            LoadDataFile(out dataTroops, databaseFiles[nameof(dataTroops)]);
            LoadDataFile(out dataStates, databaseFiles[nameof(dataStates)]);
            LoadDataFile(out dataAnimations, databaseFiles[nameof(dataAnimations)]);
            LoadDataFile(out dataTilesets, databaseFiles[nameof(dataTilesets)]);
            LoadDataFile(out dataCommonEvents, databaseFiles[nameof(dataCommonEvents)]);
            LoadDataFile(out dataSystems, databaseFiles[nameof(dataSystems)]);
            LoadDataFile(out dataMapsInfo, databaseFiles[nameof(dataMapsInfo)]);
            LoadDataFile(out dataTypes, databaseFiles[nameof(dataTypes)]);

        }        

        private static void LoadDataFile<T>(out List<T> dataList, string src) 
        {
            System.Type type = typeof(List<T>);
            XmlSerializer serializer = new XmlSerializer(type);

            try
            {
               
                using (Stream reader = new FileStream(Path + src, FileMode.Open))
                {
                    try
                    {
                        dataList = (List<T>)serializer.Deserialize(reader);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Data file " + src + ", does not have valid data!");
                        Console.WriteLine("Using default data.");
                        dataList = new List<T>();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Data file " + src + ", does not exist!");
                Console.WriteLine("Using default data.");
                dataList = new List<T>();
            }            
        }    
        #endregion
    }
}
