using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Try to remove an item from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Should be thrown an exception.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message, "Exception message is incorrect");
        }
    }

    [TestMethod]
    // Scenario: Add ["A", priority 1], [B, priority 3], [C, priority 2]
    // Expected Result: Should remove and return "B" first (highest priority)
    // Defect(s) Found: None.
    public void TestPriorityQueue_BasicDequeue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        // Expected "B" (priority 5) be removed first
        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Add items where the higher priority is at the end of the queue. ["A", priority 1], [B, priority 2], [C, priority 5]
    // Expected Result: Should remove "C"
    // Defect(s) Found:  The loop "for" stops in "Count - 1", so it never checks the last item in the list.
    public void TestPriorityQueue_HighestAtEnd()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 5); // Highest priority at the end

        // Expected "C" (priority 5) add to end queue
        var result = pq.Dequeue();
        Assert.AreEqual("C", result, "High priority item not found in the end of the queue.");
    }

    [TestMethod]
    // Scenario: Verification if the items are actually removed from the queue after Dequeue operation. Add ["A", priority 1], [B, priority 5]
    // Expected Result: Should Remove "B" first, then "A", and the queue should be empty afterward.
    // Defect(s) Found: The loop "for" is failing in 2 items, the last item is not removed from the queue.
    public void TestPriorityQueue_ItemsAreRemoved()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);

        // Dequeue "B"
        var result1 = pq.Dequeue();
        Assert.AreEqual("B", result1);

        // Dequeue "A"
        var result2 = pq.Dequeue();
        Assert.AreEqual("A", result2);

        // Try to remove from empty queue
        try
        {
            pq.Dequeue();
            Assert.Fail("The queue should be empty and throw an exception.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Test the "tie-breaker" (FIFO). Add ["A", priority 5], [B, priority 1], [C, priority 5]
    // Expected Result: Should remove "A" first (added first with highest priority), then "C".
    // Defect(s) Found: The logic '>= ' in the loop causes a violation of FIFO, taking the last added item instead of the first one.
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5); // First with highest priority 5
        pq.Enqueue("B", 1);
        pq.Enqueue("C", 5); // Second with highest priority 5

        // Dequeue "A" first
        var result1 = pq.Dequeue();
        Assert.AreEqual("A", result1, "Tiebreaker failure: I expected A.");

        // Dequeue "C" next
        var result2 = pq.Dequeue();
        Assert.AreEqual("C", result2, "The queue did not remove C after A.");
    }
}