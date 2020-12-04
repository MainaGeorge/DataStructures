using QueueImplementation;
using Xunit;

namespace Tests
{
    public class QueueTests
    {
        [Fact]
        public void QueueStartsEmpty()
        {
            var queue = new Queue<int>();

            Assert.Equal(0, queue.Size);
        }

        [Fact]
        public void QueueStartsWithOneElement()
        {
            var queue = new Queue<int>(10);

            Assert.Equal(1, queue.Size);
        }
        [Fact]
        public void Queue_ReturnsCorrectNumberOfElementsPresent()
        {
            var queue = new Queue<int>();

            queue.Enqueue(20);
            queue.Enqueue(30);
            Assert.Equal(2, queue.Size);
        }

        [Fact]
        public void Queue_CanDequeueElements()
        {
            var queue = new Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.Equal(10, queue.Dequeue());
            Assert.Equal(1, queue.Size);
        }

        [Fact]
        public void Queue_CanCheckNextElementToBeDequeued()
        {
            var queue = new Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);

            Assert.Equal(10, queue.Peek());
        }
    }
}
