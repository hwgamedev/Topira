/**
 * A -very- simple class just to store a 'target' tile in the AI/Minion system, but I thought it might be useful for everyone!
 */
public class TileLocation
{
    private int _x;
    private int _y;

    private int _g = 0;
    private int _h = 0;

    private TileLocation _parent = null;

    public TileLocation(int x, int y, int g = 0, TileLocation parent = null)
    {
        X = x;
        Y = y;
        G = g;
        Parent = parent;

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

    public int G
    {
        get
        {
            return _g;
        }

        set
        {
            _g = value;
        }
    }

    public int H
    {
        get
        {
            return _h;
        }

        set
        {
            _h = value;
        }
    }

    public TileLocation Parent
    {
        get
        {
            return _parent;
        }

        set
        {
            _parent = value;
        }
    }
}
