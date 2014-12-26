using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public MazeController mazePrefab;
	private MazeController mazeInstance;

	// Use this for initialization
	private void Start () {
		BeginGame ();
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			RestartGame();		
		}
	}

	private void BeginGame(){
		mazeInstance = Instantiate (mazePrefab) as MazeController;
		StartCoroutine(mazeInstance.Generate ());
	}

	private void RestartGame(){
		StopAllCoroutines ();
		Destroy (mazeInstance.gameObject);
		BeginGame ();
	}
}
