using DictionaryImplementation;
using Xunit;

namespace Tests
{
    public class DictionaryTests
    {
        [Fact]
        public void DictionaryStartsEmpty()
        {
            var dict = new Dictionary<int, string>();

            Assert.Equal(0, dict.Size);
        }

        [Fact]
        public void DictionaryAddsUsingIndexing()
        {
            var dict = new Dictionary<int, string> ();

            dict[1] = "one";
            dict[2] = "two";
            Assert.Equal(2, dict.Size);
            Assert.Equal("one", dict[1]);
            Assert.Equal("two", dict[2]);
        }

        [Fact]
        public void Dictionary_AddsUsingAddMethod()
        {
            var dict = new Dictionary<int, string>();

            dict.Add(1, "one");
            dict.Add(2, "two");

            Assert.Equal(2, dict.Size);
            Assert.Equal("one", dict[1]);
            Assert.Equal("two", dict[2]);
        }

        [Fact]
        public void Dictionary_ReturnsTrueIfContainsKey()
        {
            var dict = new Dictionary<int, string> {{1, "one"}, {2, "two"}};

            Assert.True(dict.ContainsKey(1));
        }

        [Fact]
        public void Dictionary_ReturnsFalseIfDoesNotContainKey()
        {
            var dict = new Dictionary<int, string> {{1, "one"}, {2, "two"}};

            Assert.False(dict.ContainsKey(3));
        }

        [Fact]
        public void Dictionary_CanDeleteKeyValuePairs()
        {
            var dict = new Dictionary<int, string> { { 1, "one" }, { 2, "two" } };

            dict.Remove(1);
            Assert.False(dict.ContainsKey(1));
        }

        [Fact]
        public void Dictionary_ReturnsAnArrayOfKeys()
        {
            var dict = new Dictionary<int, string> { { 1, "one" }, { 2, "two" } };

            var arr = new[] {1, 2};
            Assert.Equal(arr, dict.Keys());
        }

        [Fact]
        public void Dictionary_ReturnsAnArrayOfValues()
        {
            var dict = new Dictionary<int, string> { { 1, "one" }, { 2, "two" } };

            var arr = new[] { "one", "two" };
            Assert.Equal(arr, dict.Values());
        }
        [Fact]
        public void Dictionary_CanChangeValueForAKey()
        {
            var dict = new Dictionary<int, string> { { 1, "one" }, { 2, "two" } };

            dict[1] = "three";

            Assert.Equal("three", dict[1]);
        }
        [Fact]
        public void Dictionary_CanGetAValueUsingTheGetMethod()
        {
            var dict = new Dictionary<int, string> { { 1, "one" }, { 2, "two" } };

            Assert.Equal("two", dict.Get(2));
        }

    }
}
