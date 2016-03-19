using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void SetupScene(){
		//Set all tiles to Blank (Outdoor?)
		for (int x = 0; x < GameState.MAPHEIGHT; x++) {
			for (int y = 0; y < GameState.MAPHEIGHT; y++) {
				GameState.setTile (x, y, GameState.TileType.Outdoor);
			}
		}

		//Set random clusters of Rock
		int myRandomInt = 0;		
		for (int x = 0; x < GameState.MAPHEIGHT; x++) {
			for (int y = 0; y < GameState.MAPHEIGHT; y++) {
				myRandomInt = Random.Range(0 , 3);
				if (myRandomInt == 1) {
					GameState.setTile (x, y, GameState.TileType.Rock);
				}
			}
		}
	}
		
	public void LoadScene(){
		//Display all Tiles
		for (int x = 0; x < GameState.MAPHEIGHT; x++) {
			for (int y = 0; y < GameState.MAPHEIGHT; y++) {
				Vector3 temp = new Vector3(GameState.TILESIZE+x,GameState.TILESIZE, GameState.TILESIZE+y);
				if(GameState.getTile(x, y).Equals(GameState.TileType.Outdoor)){
					GameObject instance = Instantiate (Resources.Load("Blank", typeof(GameObject))) as GameObject;
					instance.gameObject.transform.position = temp;
				}else if(GameState.getTile(x, y).Equals(GameState.TileType.Rock))
				{
					GameObject instance = Instantiate (Resources.Load("Rock", typeof(GameObject))) as GameObject;
					instance.gameObject.transform.position = temp;
				}

			}
		}
	}
}