/**
 * A -very- simple class just to store a 'target' tile in the AI/Minion system, but I thought it might be useful for everyone!
 */
public class TileLocation
{
    private int _x;
    private int _y;

    public TileLocation(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X
    {
        get
        {
            return _x;
        }

        set
        {
            _x = value;
        }
    }

    public int Y
    {
        get
        {
            return _y;
        }

        set
        {
            _y = value;
        }
    }
}
