using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public abstract class DBObject 
    {
        #region Declarations
        private int id;
        private string name;
        #endregion

        #region Properties
        [XmlAttribute("ID")]
        public int Id { get => id; set => id = value; }
        [XmlAttribute("Name")]
        public string Name { get => name; set => name = value; }
        #endregion

        #region Constructor(s)
        public DBObject()
        {
            id = 1;
            name = "";
        }
        #endregion

        #region Methods

        #endregion

    }
}
