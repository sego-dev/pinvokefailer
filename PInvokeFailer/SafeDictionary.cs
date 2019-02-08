#region Copyright (c) 2004-2018, Typemock     http://www.typemock.com
/************************************************************************************
                 
 Copyright © 2004-2018 Typemock Ltd

 This code is protected by international laws

 ***********************************************************************************/
#endregion
using System;
using System.Collections;
using System.Collections.Generic;

namespace TypeMock
{
    public class SafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        private readonly ReaderWriterLock sync = new ReaderWriterLock();

        public IDisposable ProtectReadScope()
        {
            return sync.AcquireRead();
        }

        public bool HasValues
        {
            get
            {
                using (sync.AcquireRead())
                {
                    return dictionary.Count > 0;
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get { return dictionary.Values; }
        }

        public bool Remove(TKey key)
        {
            bool res;
            using (sync.AcquireWrite())
            {
                res = dictionary.Remove(key);
            }

            return res;
        }

        public IEnumerable<TKey> Keys
        {
            get { return dictionary.Keys; }
        }

        public int Count
        {
            get
            {
                using (sync.AcquireRead())
                {
                    return dictionary.Count;
                }
            }
        }

        public bool ContainsKey(TKey key)
        {
            using (sync.AcquireRead())
            {
                return dictionary.ContainsKey(key);
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                using (sync.AcquireRead())
                {
                    return dictionary[key];
                }
            }
            set
            {
                using (sync.AcquireWrite())
                {
                    dictionary[key] = value;
                }
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            using (sync.AcquireRead())
            {
                return dictionary.TryGetValue(key, out value);
            }
        }

        public bool TryRemove(TKey key)
        {
            using (sync.AcquireWrite())
            {
                if (!dictionary.ContainsKey(key))
                {
                    return false;
                }

                dictionary.Remove(key);
                return true;
            }
        }

        public void Clear()
        {
            using (sync.AcquireWrite())
            {
                dictionary.Clear();
            }
        }

        public void Add(TKey key, TValue value)
        {
            using (sync.AcquireWrite())
            {
                dictionary.Add(key, value);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }
    }
}