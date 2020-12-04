using StackImplementation;
using Xunit;

namespace Tests
{
    public class StackTests
    {
        [Fact]
        public void StackStartsEmpty()
        {
            var stack = new Stack<int>();

            Assert.Equal(0, stack.Size);
        }

        [Fact]
        public void StackStartsWithOneElement()
        {
            var stack = new Stack<int>(10);

            Assert.Equal(1, stack.Size);
        }
        [Fact]
        public void Stack_ReturnsCorrectNumberOfElementsPresent()
        {
            var stack = new Stack<int>();

            stack.Push(20);
            stack.Push(30);
            Assert.Equal(2, stack.Size);
        }

        [Fact]
        public void Stack_CanPopElements()
        {
            var stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Pop());
            Assert.Equal(1, stack.Size);
        }

        [Fact]
        public void Stack_CanCheckNextElementToBePopped()
        {
            var stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Peek());
        }
    }
}
