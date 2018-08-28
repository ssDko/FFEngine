using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using DkoLib;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBTileset : DBObject
    {
        #region Declarations        
        private TilesetMode mode;        
        private TileSize tileSize;
        private string note;

        //Parameters for each layer and tile in that layer
        private KeyedList<TilesetLayer, string> images;
        private KeyedList<TilesetLayer, List<TilePassage>> tilePassageList;
        private KeyedList<TilesetLayer, List<TilePassageDirection>> tilePassageDirectionList;
        private KeyedList<TilesetLayer, List<bool>> tileIsALadderList;
        private KeyedList<TilesetLayer, List<bool>> tileIsABushList;
        private KeyedList<TilesetLayer, List<bool>> tileIsACounterList;
        private KeyedList<TilesetLayer, List<bool>> tileIsADamageFloorList;
        private KeyedList<TilesetLayer, List<int>> tileTerraignTagList;        
        #endregion

        #region Properties       
        public TilesetMode Mode { get => mode; set => mode = value; }
        public TileSize TileSize { get => tileSize; set => tileSize = value; }
        public string Note { get => note; set => note = value; }

        [XmlElement("Image_Layer")]
        public KeyedList<TilesetLayer, string> Images { get => images; set => images = value; }
        [XmlElement("Passage_Layer")]
        public KeyedList<TilesetLayer, List<TilePassage>> TilePassageList { get => tilePassageList; set => tilePassageList = value; }
        [XmlElement("Passage_Direction_Layer")]
        public KeyedList<TilesetLayer, List<TilePassageDirection>> TilePassageDirectionList { get => tilePassageDirectionList; set => tilePassageDirectionList = value; }
        [XmlElement("Is_A_Ladder_Layer")]
        public KeyedList<TilesetLayer, List<bool>> TileIsALadderList { get => tileIsALadderList; set => tileIsALadderList = value; }
        [XmlElement("Is_A_Bush_Layer")]
        public KeyedList<TilesetLayer, List<bool>> TileIsABushList { get => tileIsABushList; set => tileIsABushList = value; }
        [XmlElement("Is_A_Counter_Layer")]
        public KeyedList<TilesetLayer, List<bool>> TileIsACounterList { get => tileIsACounterList; set => tileIsACounterList = value; }
        [XmlElement("Is_A_Damage_Floor_Layer")]
        public KeyedList<TilesetLayer, List<bool>> TileIsADamageFloorList { get => tileIsADamageFloorList; set => tileIsADamageFloorList = value; }
        [XmlElement("Terraign_Tag_Layer")]
        public KeyedList<TilesetLayer, List<int>> TileTerraignTagList { get => tileTerraignTagList; set => tileTerraignTagList = value; }        
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
                         KeyedList<TilesetLayer, List<TilePassage>> tilePassageList,
                         KeyedList<TilesetLayer, List<TilePassageDirection>> tilePassageDirectionList,
                         KeyedList<TilesetLayer, List<bool>> tileIsALadderList,
                         KeyedList<TilesetLayer, List<bool>> tileIsABushList,
                         KeyedList<TilesetLayer, List<bool>> tileIsACounterList,
                         KeyedList<TilesetLayer, List<bool>> tileIsADamageFloorList,
                         KeyedList<TilesetLayer, List<int>> tileTerraignTagList)
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
            Images.Add(TilesetLayer.A1, "");
            Images.Add(TilesetLayer.A2, "");
            Images.Add(TilesetLayer.A3, "");
            Images.Add(TilesetLayer.A4, "");
            Images.Add(TilesetLayer.A4, "");
            Images.Add(TilesetLayer.A5, "");
            Images.Add(TilesetLayer.B, "");
            Images.Add(TilesetLayer.C, "");
            Images.Add(TilesetLayer.D, "");
            Images.Add(TilesetLayer.E, "");

            TilePassageList = new KeyedList<TilesetLayer, List<TilePassage>>();
            TilePassageList.Add(TilesetLayer.A1, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.A2, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.A3, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.A4, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.A5, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.B, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.C, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.D, new List<TilePassage>());
            TilePassageList.Add(TilesetLayer.E, new List<TilePassage>());

            TilePassageDirectionList = new KeyedList<TilesetLayer, List<TilePassageDirection>>();
            TilePassageDirectionList.Add(TilesetLayer.A1, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.A2, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.A3, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.A4, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.A5, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.B, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.C, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.D, new List<TilePassageDirection>());
            TilePassageDirectionList.Add(TilesetLayer.E, new List<TilePassageDirection>());

            TileIsALadderList = new KeyedList<TilesetLayer, List<bool>>();
            TileIsALadderList.Add(TilesetLayer.A1, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.A2, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.A3, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.A4, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.A5, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.B, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.C, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.D, new List<bool>());
            TileIsALadderList.Add(TilesetLayer.E, new List<bool>());


            TileIsABushList = new KeyedList<TilesetLayer, List<bool>>();
            TileIsABushList.Add(TilesetLayer.A1, new List<bool>());
            TileIsABushList.Add(TilesetLayer.A2, new List<bool>());
            TileIsABushList.Add(TilesetLayer.A3, new List<bool>());
            TileIsABushList.Add(TilesetLayer.A4, new List<bool>());
            TileIsABushList.Add(TilesetLayer.A5, new List<bool>());
            TileIsABushList.Add(TilesetLayer.B, new List<bool>());
            TileIsABushList.Add(TilesetLayer.C, new List<bool>());
            TileIsABushList.Add(TilesetLayer.D, new List<bool>());
            TileIsABushList.Add(TilesetLayer.E, new List<bool>());

            TileIsACounterList = new KeyedList<TilesetLayer, List<bool>>();
            TileIsACounterList.Add(TilesetLayer.A1, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.A2, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.A3, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.A4, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.A5, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.B, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.C, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.D, new List<bool>());
            TileIsACounterList.Add(TilesetLayer.E, new List<bool>());

            TileIsADamageFloorList = new KeyedList<TilesetLayer, List<bool>>();
            TileIsADamageFloorList.Add(TilesetLayer.A1, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.A2, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.A3, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.A4, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.A5, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.B, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.C, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.D, new List<bool>());
            TileIsADamageFloorList.Add(TilesetLayer.E, new List<bool>());

            TileTerraignTagList = new KeyedList<TilesetLayer, List<int>>();
            TileTerraignTagList.Add(TilesetLayer.A1, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.A2, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.A3, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.A4, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.A5, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.B, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.C, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.D, new List<int>());
            TileTerraignTagList.Add(TilesetLayer.E, new List<int>());
        }
        #endregion

    }
}
