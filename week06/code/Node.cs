public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) // add the condition to avoid inserting duplicates
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Value is equal data - true
        if (value == Data)
            return true;
        // Value # for data on left - false
        else if (value < Data)
            return Left != null && Left.Contains(value);
        // Value # for data on right - false
        else if (value > Data)
            return Right != null && Right.Contains(value);
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        //1. Discover the height of the left
        //2. If left is null, height is 0, If existing, call GetHeight() recursively
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        
        //3. Discover the height of the right
        //4. If right is null, height is 0, If existing, call GetHeight() recursively
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();

        //5. Return 1 (this node) + the max of height of both sides
        //Use of Math.Max to get the larger of the two heights
        return 1 + Math.Max(leftHeight, rightHeight);

        //return 0; // Replace this line with the correct return statement(s)
    }
}