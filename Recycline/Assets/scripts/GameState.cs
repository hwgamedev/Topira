using UnityEngine;

public static class GameState
{
    public static int MAPWIDTH = 15;
    public static int MAPHEIGHT = 15;
	public static int HEALTH = 100;
	public static int GOLD = 1000;

	public static float TILESIZE = 0.5f;
    private static TileType[,] FLOORMAP = new TileType[MAPHEIGHT, MAPWIDTH];
    private static ObjectType[,] OBJECTMAP = new ObjectType[MAPHEIGHT, MAPWIDTH];
	private static GameObject[,] GAMEOBJECTS = new GameObject[MAPHEIGHT, MAPWIDTH];
    private static GameStateType GAMESTATE = new GameStateType();
	private static ObjectSelect SELECTION = new ObjectSelect();

    private static Direction[,] DIRMAP = new Direction[MAPHEIGHT, MAPWIDTH];
    public static TileLocation TARGET;

	public enum TileType {Rock, Outdoor, Corridor, Treasury, Entertainment, Hospital, Barracks, Utility, Security};

    public enum Direction { None, Up, Right, Down, Left, Target}
    public enum ObjectType { None, Stone, Diamond, Tower }; //TODO: Fill in the types of objects here!! (For Pierre)
	public enum GameStateType {Ready, Running, Win, Fail};
	public enum ObjectSelect { None, Rock, Tower }


	public static void setObjectSelection(ObjectSelect objectSelectType)
	{
		SELECTION = objectSelectType;
	}

	public static ObjectSelect getObjectSelection(){
		return SELECTION;
	}

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

	public static GameObject getGameObject(int x, int y)
	{
		return GAMEOBJECTS[y, x];
	}

	public static void setGameObjects(int x, int y, GameObject go)
	{
		GAMEOBJECTS[y, x] = go;
	}
}
