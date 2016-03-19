using System;
using System.Collections.Generic;

static class ListExtension
{
    public static T PopAt<T>(this List<T> list, int index)
    {
        T r = list[index];
        list.RemoveAt(index);
        return r;
    }
}

public class FindPath
{
    List<TileLocation> openNodes = new List<TileLocation>();
    //List<TileLocation> closedNodes = new List<TileLocation>();
    TileLocation _target;

    bool[,] visitedNodes = new bool[GameState.MAPWIDTH, GameState.MAPHEIGHT];
    bool[,] closedNodes = new bool[GameState.MAPWIDTH, GameState.MAPHEIGHT];

    List<TileLocation> finalPath = new List<TileLocation>();

    public FindPath(TileLocation start, TileLocation target)
    {
        //Flip these so the target comes back in the right order!
        _target = start;
        findNeighbours(_target);
    }

    public void findNeighbours(TileLocation tileLoc)
    {
        int xPos = tileLoc.X, yPos = tileLoc.Y, gVal = tileLoc.G;
        visitedNodes[xPos, yPos] = true;

        if (!(xPos == _target.X && yPos == _target.Y))
        { 
            //x + 1, y = 0
            if (xPos + 1 < GameState.MAPWIDTH && GameState.getTile(xPos + 1, yPos) != GameState.TileType.Rock && !closedNodes[xPos + 1, yPos] && !visitedNodes[xPos + 1, yPos])
            {
                openNodes.Add(new TileLocation(xPos + 1, yPos, gVal + 10, tileLoc));
            }
            //x = 0, y + 1
            if (yPos + 1 < GameState.MAPHEIGHT && GameState.getTile(xPos, yPos + 1) != GameState.TileType.Rock && !closedNodes[xPos, yPos + 1] && !closedNodes[xPos, yPos + 1])
            {
                openNodes.Add(new TileLocation(xPos, yPos + 1, gVal + 10, tileLoc));
            }
            //x - 1, y = 0
            if (xPos - 1 > 0 && GameState.getTile(xPos - 1, yPos) != GameState.TileType.Rock && !closedNodes[xPos - 1, yPos] && !closedNodes[xPos - 1, yPos])
            {
                openNodes.Add(new TileLocation(xPos - 1, yPos, gVal + 10, tileLoc));
            }
            //x = y, y - 1
            if (yPos - 1 > 0 && GameState.getTile(xPos, yPos - 1) != GameState.TileType.Rock && !closedNodes[xPos, yPos - 1] && !closedNodes[xPos, yPos - 1])
            {
                openNodes.Add(new TileLocation(xPos, yPos - 1, gVal + 10, tileLoc));
            }
        }
        else
        {
            TileLocation childTile = tileLoc;
            while (childTile.Parent != null)
            {
                finalPath.Add(childTile);
                childTile = childTile.Parent;
            }
        }

        //closedNodes.Add(tileLoc);
        closedNodes[xPos, yPos] = true;
        findSmallestF();
    }

    private void findSmallestF()
    {
        int smallestF = int.MaxValue;
        int openListPos = -1;

        for(int i = 0; i < openNodes.Count; i++)
        {
            int f = openNodes[i].G + (Math.Abs(openNodes[i].X - _target.X) + Math.Abs(openNodes[i].Y - _target.Y) * 10);

            if (f < smallestF)
            {
                smallestF = f;
                openListPos = i;
            }
        }

        findNeighbours(openNodes.PopAt(openListPos));
    }
}
