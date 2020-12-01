using LinkedListImplementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryImplementation
{
    public class Dictionary<TKey, TValue> : IEnumerable<DictionaryEntry<TKey, TValue>>
    {
        private readonly LinkedListImplementation.LinkedList<DictionaryEntry<TKey, TValue>>[] _data;

        public Dictionary()
        {
            _data = new LinkedListImplementation.LinkedList<DictionaryEntry<TKey, TValue>>[5];
        }

        public int Size
        {
            get
            {
                if (_data == null)
                    return 0;
                var count = _data.Where(list => list != null).Sum(list => list.Size);
                return count;
            }

        }

        public TValue this[TKey key]
        {
            get => Get(key);
            set => Add(key, value);
        }

        public void Add(TKey key, TValue value)
        {
            var index = GetHashedKey(key);
            var dictNode = new Node<DictionaryEntry<TKey, TValue>>(new DictionaryEntry<TKey, TValue>(key, value));

            if (_data[index] == null)
            {
                _data[index] = new LinkedListImplementation.LinkedList<DictionaryEntry<TKey, TValue>>(dictNode);
            }
            else
                Insert(dictNode, index);
        }

        public TValue Get(TKey key)
        {
            var index = GetHashedKey(key);

            if (_data[index] == null)
                throw new InvalidOperationException();

            var currentNode = _data[index].HeadNode;
            TValue result = default;

            while (currentNode != null)
            {
                if (currentNode.Value.Key.Equals(key))
                {
                    result = currentNode.Value.Value;
                    break;
                }
                currentNode = currentNode.Next;
            }

            return result;
        }
        private void Insert(Node<DictionaryEntry<TKey, TValue>> dictNode, int index)
        {
            var currentNode = _data[index].HeadNode;
            var hasChanged = false;
            while (currentNode != null)
            {
                if (currentNode.Value.Key.Equals(dictNode.Value.Key))
                {
                    currentNode.Value.Value = dictNode.Value.Value;
                    hasChanged = true;
                }

                currentNode = currentNode.Next;
            }

            if (!hasChanged)
                _data[index].Add(dictNode);

        }

        public void Remove(TKey key)
        {
            var index = GetHashedKey(key);

            if (_data[index] == null)
                throw new InvalidOperationException();
            if (_data[index].HeadNode.Value.Key.Equals(key))
            {
                _data[index].RemoveFirst();
                return;
            }
            if (_data[index].TailNode.Value.Key.Equals(key))
            {
                _data[index].RemoveLast();
                return;
            }
            var nodeBeforeDeleted = GetNodeBeforeDeleted(key, index);
            nodeBeforeDeleted.Next = nodeBeforeDeleted.Next.Next;
        }

        private Node<DictionaryEntry<TKey, TValue>> GetNodeBeforeDeleted(TKey key, int index)
        {
            var list = _data[index].HeadNode;
            Node<DictionaryEntry<TKey, TValue>> result = null;

            while (list.Next != null)
            {
                if (list.Next.Value.Key.Equals(key))
                {
                    result = list;
                    break;
                }

                list = list.Next;
            }

            return result;
        }
        public int GetHashedKey(TKey key) => Math.Abs(key.GetHashCode() % _data.Length);

        public IEnumerator<DictionaryEntry<TKey, TValue>> GetEnumerator()
        {
            return _data.Where(list => list != null).SelectMany(list => list).GetEnumerator();
        }

        public IEnumerable<TKey> Keys()
        {
            var data = _data.Where(x => x != null);
            var allKeys = (from lis in data from entry in lis select entry.Key).ToList();

            return allKeys;
        }
        public IEnumerable<TValue> Values()
        {
            var data = _data.Where(x => x != null);
            var allValues
                = (from lis in data from entry in lis select entry.Value).ToList();

            return allValues;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
