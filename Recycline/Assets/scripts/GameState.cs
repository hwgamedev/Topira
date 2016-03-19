public static class GameState
{
    public static int LEVEL = 0;
    public static int MAPWIDTH = 50;
    public static int MAPHEIGHT = 50;
    public static TileType[,] CURRENTMAP = new TileType[MAPHEIGHT, MAPWIDTH];
    public static ObjectType[,] CURRENTOBJ = new ObjectType[MAPHEIGHT, MAPWIDTH];

    public enum TileType {Rock, Outdoor, Corridor, Treasury, Entertainment, Hospital, Barracks, Utility, Security}
    public enum ObjectType { }; //TODO: Fill in the types of objects here!! (For Pierre)

    public static void setTile(int x, int y, TileType tileType)
    {
        CURRENTMAP[y, x] = tileType;
    }

    public static TileType getTile(int x, int y)
    {
        return CURRENTMAP[y, x];
    }

    public static void setObj(int x, int y, ObjectType objType)
    {
        CURRENTOBJ[y, x] = objType;
    }

    public static ObjectType getObj(int x, int y)
    {
        return CURRENTOBJ[y, x];
    }
}
