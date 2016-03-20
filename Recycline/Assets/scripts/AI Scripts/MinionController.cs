using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinionController : MonoBehaviour
{
    private float speed = 2;
    private GameState.Direction curDir = GameState.Direction.None;

	// Use this for initialization
	void Start ()
    {
        //Put it at 0.0!
        this.transform.position = new Vector2(Mathf.Floor(Random.Range(0, GameState.MAPWIDTH)) , 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        calculateTile();

        if (curDir == GameState.Direction.Right)
        {
            this.transform.position = new Vector2(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y);
        }
        else if (curDir == GameState.Direction.Down)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - speed * Time.deltaTime);
        }
        else if (curDir == GameState.Direction.Left)
        {
            this.transform.position = new Vector2(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y);
        }
        else if (curDir == GameState.Direction.Up)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime);
        }
    }

    private void calculateTile()
    {
        int x = 0, y = 0;
        if(curDir == GameState.Direction.Right)
        {
            x = Mathf.FloorToInt(this.transform.position.x);
            y = Mathf.RoundToInt(this.transform.position.y);
        }
        else if (curDir == GameState.Direction.Left)
        {
            x = Mathf.CeilToInt(this.transform.position.x);
            y = Mathf.RoundToInt(this.transform.position.y);
        }
        else if (curDir == GameState.Direction.Up)
        {
            x = Mathf.RoundToInt(this.transform.position.x);
            y = Mathf.FloorToInt(this.transform.position.y);
        }
        else if (curDir == GameState.Direction.Down)
        {
            x = Mathf.RoundToInt(this.transform.position.x);
            y = Mathf.CeilToInt(this.transform.position.y);
        }

        curDir = GameState.getDir(x, y);

        if(curDir == GameState.Direction.Target)
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
