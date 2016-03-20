using UnityEngine;
using System.Collections;

public class BlankFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		float x = this.transform.position.x;
		float y = this.transform.position.y;

		if (GameState.getObj ((int)x, (int)y) == GameState.ObjectType.None)
		{
			
			if (GameState.getObjectSelection () == GameState.ObjectSelect.Rock) {
			
				GameState.setObj ((int)x, (int)y, GameState.ObjectType.Stone);

				GameObject temp = (GameObject)Instantiate (Resources.Load ("Rock"), new Vector3 (x, y, 0), Quaternion.identity);

				GameState.setGameObjects ((int)x, (int)y, temp);

			} else if (GameState.getObjectSelection () == GameState.ObjectSelect.Tower) {

				GameState.setObj ((int)x, (int)y, GameState.ObjectType.Tower);
				GameObject temp = (GameObject)Instantiate (Resources.Load ("Tower"), new Vector3 (x, y, 0), Quaternion.identity);
				temp.transform.rotation = new Quaternion (180, 0, 0, 1);
				GameState.setGameObjects ((int)x, (int)y, temp);
			}
		} else {
			Debug.Log ("No Object found");
			if (GameState.getObjectSelection () == GameState.ObjectSelect.None) {
				GameState.setObj ((int)x, (int)y, GameState.ObjectType.None);
				Destroy(GameState.getGameObject((int)x, (int)y));
				GameState.setGameObjects ((int)x, (int)y, null);
			}
		}

		BreadthFirstPath.Instance.updatePaths ();
	}
}
