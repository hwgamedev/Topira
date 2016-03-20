using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstPath
{
    private Queue<TileLocation> searchQueue;


    public void updatePaths()
    {
        GameState.setTarget(GameState.MAPWIDTH / 2, GameState.MAPHEIGHT - 1);
        resetPaths();

        randomNoise();

        searchQueue.Enqueue(new TileLocation(GameState.TARGET.X, GameState.TARGET.Y));
        runPathSearch();
    }

    private void randomNoise()
    {
        for (int x = 0; x < GameState.MAPWIDTH; x++)
        {
            for (int y = 0; y < GameState.MAPHEIGHT; y++)
            {
                if (GameState.getDir(x, y) != GameState.Direction.Target)
                {
                    if (Random.value < 0.3)
                        GameState.setTile(x, y, GameState.TileType.Rock);
                    else
                        GameState.setTile(x, y, GameState.TileType.Outdoor);
                }
                else
                {
                    GameState.setTile(x, y, GameState.TileType.Outdoor);
                }
            }
        }
    }

    private void resetPaths()
    {
        for (int x = 0; x < GameState.MAPWIDTH; x++)
        {
            for (int y = 0; y < GameState.MAPHEIGHT; y++)
            {
                if(GameState.getDir(x, y) != GameState.Direction.Target)
                    GameState.setDir(x, y, GameState.Direction.None);
            }
        }

        searchQueue = new Queue<TileLocation>();
    }

    private void runPathSearch()
    {
        int breakout = 0;
        while(searchQueue.Count > 0 && breakout++ < 1000)
        {
            TileLocation curTile = searchQueue.Dequeue();
            enqueueNeighbours(curTile.X, curTile.Y);
        }
    }

    private void enqueueNeighbours(int x, int y)
    {
        if (y > -1 && y <= GameState.MAPHEIGHT)
        {
            //Right
            if (x + 1 < GameState.MAPWIDTH && GameState.getDir(x + 1, y) == GameState.Direction.None)
            {
                if (GameState.getTile(x + 1, y) == GameState.TileType.Outdoor)
                {
                    GameState.setDir(x + 1, y, GameState.Direction.Left);
                    searchQueue.Enqueue(new TileLocation(x + 1, y));
                }
            }
            //Left
            if (x - 1 > -1 && GameState.getDir(x - 1, y) == GameState.Direction.None)
            {
                if (GameState.getTile(x - 1, y) == GameState.TileType.Outdoor)
                {
                    GameState.setDir(x - 1, y, GameState.Direction.Right);
                    searchQueue.Enqueue(new TileLocation(x - 1, y));
                }
            }
        }

        if (x > -1 && x < GameState.MAPWIDTH)
        {
            //Down
            if (y - 1 > -1 && GameState.getDir(x, y - 1) == GameState.Direction.None)
            {
                if (GameState.getTile(x, y - 1) == GameState.TileType.Outdoor)
                {
                    GameState.setDir(x, y - 1, GameState.Direction.Up);
                    searchQueue.Enqueue(new TileLocation(x, y - 1));
                }
            }
            //Up
            if (y + 1 < GameState.MAPHEIGHT && GameState.getDir(x, y + 1) == GameState.Direction.None)
            {
                if (GameState.getTile(x, y + 1) == GameState.TileType.Outdoor)
                {
                    GameState.setDir(x, y + 1, GameState.Direction.Down);
                    searchQueue.Enqueue(new TileLocation(x, y + 1));
                }
            }
        }
    }
}
