using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DkoLib
{
    [Serializable]
    public class KeyedList<K, T> : List<MyKeyValuePair<K, T>>
    {
        #region Declarations

        #endregion

        #region Properties

        #endregion

        #region Constructor(s)
        #endregion

        #region Methods
        public void Add(K key, T value)
        {
            this[key] = value;
        }
        
        public List<K> Keys
        {
            get
            {
                List<K> temp = new List<K>();
                foreach(var pair in this)
                {
                    temp.Add(pair.Key);
                }

                return temp;
            }            
        }
        
        public T this[K key]
        {
            get
            {
                T valueObject = default(T);


                MyKeyValuePair<K, T> pair = this.Find(
                    delegate (MyKeyValuePair<K, T> kvp)
                    {
                        return kvp.Key.Equals(key);
                    });

                if (pair.Value != null)
                {
                    valueObject = pair.Value;
                }

                return valueObject;
            }

            set
            {
                MyKeyValuePair<K, T> pair = this.Find(
                    delegate (MyKeyValuePair<K, T> kvp)
                    {
                        return kvp.Key.Equals(key);
                    });
                if (pair != null)
                {
                    pair = new MyKeyValuePair<K, T>(key, value);
                }
                else
                {
                    base.Add(new MyKeyValuePair<K, T>(key, value));
                }

            }
        }
        #endregion

    }
}
