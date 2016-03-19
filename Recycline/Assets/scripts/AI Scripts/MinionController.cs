using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MinionController : MonoBehaviour
{
    private AIController.CommandType _command = AIController.CommandType.Nothing;
    private TileLocation target = new TileLocation(0, 0);

    List<TileLocation> path;
    int posOnPath = 0;

    private float speed = 20f;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = new Vector2(0, 0);
        FindPath findPath = new FindPath(new TileLocation(0, 0), new TileLocation(GameState.MAPWIDTH - 1, GameState.MAPHEIGHT - 1));
        path = findPath.FinalPath;
        posOnPath = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (path != null)
        {
            Vector2 target = new Vector2(path[posOnPath].X, path[posOnPath].Y);
            this.transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, target) < 0.1f)
            {
                if (posOnPath < path.Count - 1)
                    posOnPath++;
                else
                    path = null;
            }
        }
	}
}
