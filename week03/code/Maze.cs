/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        // 1. Get valid moviments for the actually location
        var validMoviments = _mazeMap[(_currX, _currY)];

        // 2. Verify if can move to left
        if (validMoviments[0]) // if true
        {
            _currX--; // move to left (decrease X)
        }
        else // if false
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        // 1. Get valid moviments for the actually location
        var validMoviments = _mazeMap[(_currX, _currY)];

        // 2. Verify if can move to right
        if (validMoviments[1]) // if true
        {
            _currX++; // move to right(increase X)
        }
        else // if false (wall)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        // 1. Get valid moviments for the actually location
        var validMoviments = _mazeMap[(_currX, _currY)];

        // 2. Verify if can move to up (index 2)
        if (validMoviments[2]) // if true
        {
            _currY--; // move to up (decrease Y)
        }
        else // if false (wall)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        // 1. Get valid moviments for the actually location
        var validMoviments = _mazeMap[(_currX, _currY)];

        // 2. Verify if can move to down (index 3)
        if (validMoviments[3]) // if true
        {
            _currY++; // move to down (increase Y)
        }
        else // if false (wall)
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}