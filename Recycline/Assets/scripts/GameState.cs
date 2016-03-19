public static class GameState
{
    public static int MAPWIDTH = 14;
    public static int MAPHEIGHT = 14;
	public static float TILESIZE = 0.5f; 
    public static TileType[,] FLOORMAP = new TileType[MAPHEIGHT, MAPWIDTH];
    public static ObjectType[,] OBJECTMAP = new ObjectType[MAPHEIGHT, MAPWIDTH];
	public static GameStateType GAMESTATE = new GameStateType();

	public enum TileType {Rock, Outdoor, Corridor, Treasury, Entertainment, Hospital, Barracks, Utility, Security};
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
}
