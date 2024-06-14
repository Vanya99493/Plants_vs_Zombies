using System;

namespace CustomClasses
{
    [Serializable]
    public class Pair<T, K>
    {
        public T Key;
        public K Value;

        public Pair(T key, K value)
        {
            Key = key;
            Value = value;
        }
    }
}