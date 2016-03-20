public static class GameState
{
    public static int MAPWIDTH = 15;
    public static int MAPHEIGHT = 15;
	public static float TILESIZE = 0.5f;
    private static TileType[,] FLOORMAP = new TileType[MAPHEIGHT, MAPWIDTH];
    private static ObjectType[,] OBJECTMAP = new ObjectType[MAPHEIGHT, MAPWIDTH];
    private static GameStateType GAMESTATE = new GameStateType();

    private static Direction[,] DIRMAP = new Direction[MAPHEIGHT, MAPWIDTH];
    public static TileLocation TARGET;

	public enum TileType {Rock, Outdoor, Corridor, Treasury, Entertainment, Hospital, Barracks, Utility, Security};
    public enum Direction { None, Up, Right, Down, Left, Target}
    public enum ObjectType { }; //TODO: Fill in the types of objects here!! (For Pierre)
	public enum GameStateType {Ready, Running, Win, Fail};

	public static void setGameState(GameStateType gameStateType)
	{
		GAMESTATE = gameStateType;
	}

	public static GameStateType getGameState()
	{
		return GAMESTATE;
	}

    public static void setTile(int x, int y, TileType tileType)
    {
        FLOORMAP[y, x] = tileType;
    }

    public static TileType getTile(int x, int y)
    {
        return FLOORMAP[y, x];
    }

    public static void setObj(int x, int y, ObjectType objType)
    {
        OBJECTMAP[y, x] = objType;
    }

    public static ObjectType getObj(int x, int y)
    {
        return OBJECTMAP[y, x];
    }

    public static void setDir(int x, int y, Direction dir)
    {
        DIRMAP[y, x] = dir;
    }

    public static Direction getDir(int x, int y)
    {
        return DIRMAP[y, x];
    }

    public static void setTarget(int x, int y)
    {
        DIRMAP[y, x] = Direction.Target;
        TARGET = new TileLocation(x, y);
    }
}
