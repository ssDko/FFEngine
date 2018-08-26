using System;
using System.Collections.Generic;
using System.Text;

namespace DkoLib
{
    [Serializable]
    public class KeyedList<K, T> : List<KeyValuePair<K, T>>
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
            base.Add(new KeyValuePair<K, T>(key, value));
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


                KeyValuePair<K, T> pair = this.Find(
                    delegate (KeyValuePair<K, T> kvp)
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
                KeyValuePair<K, T> pair = this.Find(
                    delegate (KeyValuePair<K, T> kvp)
                    {
                        return kvp.Key.Equals(key);
                    });

                pair = new KeyValuePair<K, T>(key, value);

            }
        }
        #endregion

    }
}
