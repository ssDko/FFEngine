using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DkoLib
{
    [Serializable]
    public class MyKeyValuePair<K,V>
    {
        #region Declarations
        private K key;
        private V value;

        
        #endregion

        #region Properties
        [XmlAttribute("Key")]
        public K Key { get => key; set => key = value; }
        public V Value { get => value; set => this.value = value; }
        #endregion

        #region Constructor(s)
        public MyKeyValuePair()
        {            
        }

        public MyKeyValuePair(K key, V value)
        {
            Key = key;
            Value = value;
        }
        #endregion

        #region Methods

        #endregion

    }
}
