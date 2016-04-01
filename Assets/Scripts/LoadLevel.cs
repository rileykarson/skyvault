using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public string levelToLoad;

	public void loadLevel(){
		if (levelToLoad == "StartScene") {
			State.score = 0;
			State.currentScore = 0;
		}
		SceneManager.LoadScene(levelToLoad);
	}
}