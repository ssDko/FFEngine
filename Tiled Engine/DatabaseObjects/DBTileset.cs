using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DkoLib;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBTileset
    {
        #region Declarations
        private int id;
        private string name;
        private TilesetMode mode;        
        private TileSize tileSize;
        private string note;



        //Parameters for each layer and tile in that layer
        private KeyedList<TilesetLayer, string> images;
        private KeyedList<TilesetLayer, TilePassage> tilePassageList;
        private KeyedList<TilesetLayer, TilePassageDirection> tilePassageDirectionList;
        private KeyedList<TilesetLayer, bool> tileIsALadderList;
        private KeyedList<TilesetLayer, bool> tileIsABushList;
        private KeyedList<TilesetLayer, bool> tileIsACounterList;
        private KeyedList<TilesetLayer, bool> tileIsADamageFloorList;
        private KeyedList<TilesetLayer, int> tileTerraignTagList;        
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public TilesetMode Mode { get => mode; set => mode = value; }
        public TileSize TileSize { get => tileSize; set => tileSize = value; }
        public string Note { get => note; set => note = value; }

        public KeyedList<TilesetLayer, string> Images { get => images; set => images = value; }
        public KeyedList<TilesetLayer, TilePassage> TilePassageList { get => tilePassageList; set => tilePassageList = value; }
        public KeyedList<TilesetLayer, TilePassageDirection> TilePassageDirectionList { get => tilePassageDirectionList; set => tilePassageDirectionList = value; }
        public KeyedList<TilesetLayer, bool> TileIsALadderList { get => tileIsALadderList; set => tileIsALadderList = value; }
        public KeyedList<TilesetLayer, bool> TileIsABushList { get => tileIsABushList; set => tileIsABushList = value; }
        public KeyedList<TilesetLayer, bool> TileIsACounterList { get => tileIsACounterList; set => tileIsACounterList = value; }
        public KeyedList<TilesetLayer, bool> TileIsADamageFloorList { get => tileIsADamageFloorList; set => tileIsADamageFloorList = value; }
        public KeyedList<TilesetLayer, int> TileTerraignTagList { get => tileTerraignTagList; set => tileTerraignTagList = value; }
        
        #endregion

        #region Constructor(s)
        public DBTileset()
        {
            Id = 1;
            Name = "";
            Mode = TilesetMode.WorldType;
            TileSize = TileSize.ThirtyTwo;
            Note = "";

            SetupLayersToDefaults();
            
        }

        public DBTileset(int id, 
                         string name, 
                         TilesetMode mode,                          
                         TileSize tileSize,
                         string note,
                         KeyedList<TilesetLayer, string> images,
                         KeyedList<TilesetLayer, TilePassage> tilePassageList,
                         KeyedList<TilesetLayer, TilePassageDirection> tilePassageDirectionList,
                         KeyedList<TilesetLayer, bool> tileIsALadderList,
                         KeyedList<TilesetLayer, bool> tileIsABushList,
                         KeyedList<TilesetLayer, bool> tileIsACounterList,
                         KeyedList<TilesetLayer, bool> tileIsADamageFloorList,
                         KeyedList<TilesetLayer, int> tileTerraignTagList)
        {
            Id = id;
            Name = name;
            Mode = mode;
            Note = note;
            TileSize = tileSize;

            Images = images;
            TilePassageList = tilePassageList;
            TilePassageDirectionList = tilePassageDirectionList;
            TileIsALadderList = tileIsALadderList;
            TileIsABushList = tileIsABushList;
            TileIsACounterList = tileIsACounterList;
            TileIsADamageFloorList = tileIsADamageFloorList;
            TileTerraignTagList = tileTerraignTagList;
        }
        #endregion


        #region Methods
        private void SetupLayersToDefaults()
        {
            Images = new KeyedList<TilesetLayer, string>();
            Images.Keys.Add(TilesetLayer.A1);
            Images.Keys.Add(TilesetLayer.A2);
            Images.Keys.Add(TilesetLayer.A3);
            Images.Keys.Add(TilesetLayer.A4);
            Images.Keys.Add(TilesetLayer.A5);
            Images.Keys.Add(TilesetLayer.B);
            Images.Keys.Add(TilesetLayer.C);
            Images.Keys.Add(TilesetLayer.D);
            Images.Keys.Add(TilesetLayer.E);            

            TilePassageList = new KeyedList<TilesetLayer, TilePassage>();
            TilePassageList.Keys.Add(TilesetLayer.A1);
            TilePassageList.Keys.Add(TilesetLayer.A2);
            TilePassageList.Keys.Add(TilesetLayer.A3);
            TilePassageList.Keys.Add(TilesetLayer.A4);
            TilePassageList.Keys.Add(TilesetLayer.A5);
            TilePassageList.Keys.Add(TilesetLayer.B);
            TilePassageList.Keys.Add(TilesetLayer.C);
            TilePassageList.Keys.Add(TilesetLayer.D);
            TilePassageList.Keys.Add(TilesetLayer.E);            

            TilePassageDirectionList = new KeyedList<TilesetLayer, TilePassageDirection>();
            TilePassageDirectionList.Keys.Add(TilesetLayer.A1);
            TilePassageDirectionList.Keys.Add(TilesetLayer.A2);
            TilePassageDirectionList.Keys.Add(TilesetLayer.A3);
            TilePassageDirectionList.Keys.Add(TilesetLayer.A4);
            TilePassageDirectionList.Keys.Add(TilesetLayer.A5);
            TilePassageDirectionList.Keys.Add(TilesetLayer.B);
            TilePassageDirectionList.Keys.Add(TilesetLayer.C);
            TilePassageDirectionList.Keys.Add(TilesetLayer.D);
            TilePassageDirectionList.Keys.Add(TilesetLayer.E);            

            TileIsALadderList = new KeyedList<TilesetLayer, bool>();
            TileIsALadderList.Keys.Add(TilesetLayer.A1);
            TileIsALadderList.Keys.Add(TilesetLayer.A2);
            TileIsALadderList.Keys.Add(TilesetLayer.A3);
            TileIsALadderList.Keys.Add(TilesetLayer.A4);
            TileIsALadderList.Keys.Add(TilesetLayer.A5);
            TileIsALadderList.Keys.Add(TilesetLayer.B);
            TileIsALadderList.Keys.Add(TilesetLayer.C);
            TileIsALadderList.Keys.Add(TilesetLayer.D);
            TileIsALadderList.Keys.Add(TilesetLayer.E);
         

            TileIsABushList = new KeyedList<TilesetLayer, bool>();
            TileIsABushList.Keys.Add(TilesetLayer.A1);
            TileIsABushList.Keys.Add(TilesetLayer.A2);
            TileIsABushList.Keys.Add(TilesetLayer.A3);
            TileIsABushList.Keys.Add(TilesetLayer.A4);
            TileIsABushList.Keys.Add(TilesetLayer.A5);
            TileIsABushList.Keys.Add(TilesetLayer.B);
            TileIsABushList.Keys.Add(TilesetLayer.C);
            TileIsABushList.Keys.Add(TilesetLayer.D);
            TileIsABushList.Keys.Add(TilesetLayer.E);

            TileIsACounterList = new KeyedList<TilesetLayer, bool>();
            TileIsACounterList.Keys.Add(TilesetLayer.A1);
            TileIsACounterList.Keys.Add(TilesetLayer.A2);
            TileIsACounterList.Keys.Add(TilesetLayer.A3);
            TileIsACounterList.Keys.Add(TilesetLayer.A4);
            TileIsACounterList.Keys.Add(TilesetLayer.A5);
            TileIsACounterList.Keys.Add(TilesetLayer.B);
            TileIsACounterList.Keys.Add(TilesetLayer.C);
            TileIsACounterList.Keys.Add(TilesetLayer.D);
            TileIsACounterList.Keys.Add(TilesetLayer.E);

            TileIsADamageFloorList = new KeyedList<TilesetLayer, bool>();
            TileIsADamageFloorList.Keys.Add(TilesetLayer.A1);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.A2);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.A3);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.A4);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.A5);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.B);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.C);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.D);
            TileIsADamageFloorList.Keys.Add(TilesetLayer.E);

            TileTerraignTagList = new KeyedList<TilesetLayer, int>();
            TileTerraignTagList.Keys.Add(TilesetLayer.A1);
            TileTerraignTagList.Keys.Add(TilesetLayer.A2);
            TileTerraignTagList.Keys.Add(TilesetLayer.A3);
            TileTerraignTagList.Keys.Add(TilesetLayer.A4);
            TileTerraignTagList.Keys.Add(TilesetLayer.A5);
            TileTerraignTagList.Keys.Add(TilesetLayer.B);
            TileTerraignTagList.Keys.Add(TilesetLayer.C);
            TileTerraignTagList.Keys.Add(TilesetLayer.D);
            TileTerraignTagList.Keys.Add(TilesetLayer.E);
        }
        #endregion

    }
}
