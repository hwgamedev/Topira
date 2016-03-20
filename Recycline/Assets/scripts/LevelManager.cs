using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void SetupScene(){
		//Set all tiles to Blank (Outdoor?)
		for (int x = 0; x < GameState.MAPWIDTH; x++) {
			for (int y = 0; y < GameState.MAPHEIGHT; y++) {
				GameState.setTile (x, y, GameState.TileType.Outdoor);
			}
		}

		//Set random clusters of Rock
		int xOut = 0;		
		int xIn = 0;

		for (int x = 0; x < GameState.MAPWIDTH; x++) {
			for (int y = 0; y < GameState.MAPHEIGHT; y++) {
				if (x > 2 && x < GameState.MAPWIDTH-2 && y > 2 && y < GameState.MAPHEIGHT-2) {
					GameState.setTile (x, y, GameState.TileType.Rock);
				}
			}
		}
	}
		
	public void LoadScene(){
		//Display all Tiles
		for (int x = 0; x < GameState.MAPWIDTH; x++) {
			for (int y = 0; y < GameState.MAPHEIGHT; y++) {
				
				Vector2 temp = new Vector2(GameState.TILESIZE+x-0.5f, GameState.TILESIZE+y-0.5f);
				GameObject instance = null;
				switch (GameState.getTile(x, y)) {
					case GameState.TileType.Outdoor:
						instance = Instantiate (Resources.Load("Floor_Basic", typeof(GameObject))) as GameObject;
						instance.gameObject.transform.position = temp;
						break;
					case GameState.TileType.Rock:
						//Some Running Code
						instance = Instantiate (Resources.Load("Floor_Basic", typeof(GameObject))) as GameObject;
						instance.gameObject.transform.position = temp;
						break;
					default:
						Debug.Log("ERROR: Unknown tile state: " + GameState.getGameState());
						break;
				}
			}
		}
	}
}