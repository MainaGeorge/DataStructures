namespace DictionaryImplementation
{
    public class DictionaryEntry<TKey, TValue>
    {
        public TKey Key { get; set; }   
        public TValue Value { get; set; }
        public DictionaryEntry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
