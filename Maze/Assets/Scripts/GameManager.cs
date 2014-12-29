using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public MazeController mazePrefab;
	private MazeController mazeInstance;

	public Player playerPrefab;
	private Player playerInstance;

	// Use this for initialization
	private void Start () {
		StartCoroutine (BeginGame ());
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			RestartGame();		
		}
	}

	private IEnumerator BeginGame(){
		mazeInstance = Instantiate (mazePrefab) as MazeController;
		yield return StartCoroutine (mazeInstance.Generate ());

		playerInstance = Instantiate (playerPrefab) as Player;
		playerInstance.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
	}

	private void RestartGame(){
		StopAllCoroutines ();
		Destroy (mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);		
		}
		StartCoroutine (BeginGame ());
	}
}
