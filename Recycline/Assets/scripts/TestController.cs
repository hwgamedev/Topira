using UnityEngine;
using System.Collections;

public class TestController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        /*for (int x = 0; x < GameState.MAPWIDTH; x++)
        {
            for (int y = 0; y < GameState.MAPHEIGHT; y++)
            {
               GameState.setTile
            }
        }*/

		BreadthFirstPath path = BreadthFirstPath.Instance;
        path.updatePaths();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnDrawGizmos()
    {
        for (int x = 0; x < GameState.MAPWIDTH; x++)
        {
            for (int y = 0; y < GameState.MAPHEIGHT; y++)
            {
                if (GameState.getTile(x, y) == GameState.TileType.Rock)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawSphere(new Vector2(x, y), 0.5f);
                }
                else
                {
                    if (GameState.getDir(x, y) == GameState.Direction.Right)
                    {
                        Gizmos.color = Color.yellow;
                        Gizmos.DrawSphere(new Vector2(x, y), 0.5f);
                    }
                    else if (GameState.getDir(x, y) == GameState.Direction.Down)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawSphere(new Vector2(x, y), 0.5f);
                    }
                    else if (GameState.getDir(x, y) == GameState.Direction.Left)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawSphere(new Vector2(x, y), 0.5f);
                    }
                    else if (GameState.getDir(x, y) == GameState.Direction.Up)
                    {
                        Gizmos.color = Color.magenta;
                        Gizmos.DrawSphere(new Vector2(x, y), 0.5f);
                    }
                    else if (GameState.getDir(x, y) == GameState.Direction.Target)
                    {
                        Gizmos.color = Color.cyan;
                        Gizmos.DrawSphere(new Vector2(x, y), 0.5f);
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                        Gizmos.DrawSphere(new Vector2(x, y), 0.5f);
                    }
                }
            }
        }
    }
}
