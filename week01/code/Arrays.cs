public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // ---------- Implementation Plan -----------//
        // 1. Create an array of doubles with the size of 'length'.
        // 2. Use a for loop to iterate length times.Loop index(i) go from 0 to length - 1.
        // 3. Inside the loop, we need to calculate the correct multiple.The first multiple is number * 1, the second is number * 2, and so on.
        // 4. Indice 'i' starts with 0.Calculate the multiple by multiplying 'number' with (i + 1).
        // 5.Calculate the multiple as: multiple = number * (i + 1).
        // 6. Store the calculated multiple in the array at index i.
        // 7. After the loop completes, return the filled array.

        // Step 1: Array creation
        double[] multiplesArray = new double[length];

        // Step 2: Loop 'for' from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // Step 3,4,5: Calculate the value (i + 1 like multiple)
            double value = number * (i + 1);
            // Step 6: Store the value in the array
            multiplesArray[i] = value;
        }
        // Step 7: Return the filled array
        return multiplesArray;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // ---------- Implementation Plan -----------//
        //  Using list slicing to modfify the existing list.
        //  Eg. data = {1, 2, 3, 4, 5, 6, 7, 8, 9}, amount = 3
        //  Result expected: {7, 8, 9, 1, 2, 3, 4, 5, 6}

        // 1. Otimization : If the amount is bigger than the necessary.
        //    If the list length is 9, rotate 9 is the same that rotate 0.
        //    So, we can use amount % data.Count to get the effective rotation amount.
        //    Eg. amount = 9, data.count = 9. 9 % 9 = 0. No rotation needed.
        //    Eg. amount = 3, data.count = 9. 3 % 9 = 3. Rotate by 3.
        int effectiveAmount = amount % data.Count;

        // 2. If the amount effective is 0, no rotation needed.
        if (effectiveAmount == 0)
        {
            return; // No rotation needed
        }

        // 3. Calculate the index where the "tail"( the part that goes to the front) starts.
        //    Eg. 9 items, amount = 3, tail starts at index 6 (9 - 3)
        //    Eg. Calculate: 9 - 3 = 6
        int splitIndex = data.Count - effectiveAmount;

        // 4. Create a "tail" (last items) for a temporary list.
        //    Using GetRange (index_initial, count_of_items)
        //    Eg.  data.GetRange(6, 3) => return {7, 8, 9}
        List<int> tail = data.GetRange(splitIndex, effectiveAmount);

        // 5. Remove the "tail" from the end of the original "data" list.
        //    Using RemoveRange (index_initial, count_of_items)
        //    Eg. data.RemoveRange(6, 3) => data becomes {1, 2, 3, 4, 5, 6}
        data.RemoveRange(splitIndex, effectiveAmount);

        // 6. Insert the "tail"(save temporary list) at the beginning of the original "data" list.
        //    Using InsertRange (index_of_insert, colection_to_insert)
        //    Eg. data.InsertRange(0, tail) => data becomes {7, 8, 9, 1, 2, 3, 4, 5, 6}
        data.InsertRange(0, tail);
    }
}
