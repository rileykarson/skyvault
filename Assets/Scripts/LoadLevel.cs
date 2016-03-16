using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public string levelToLoad;

	public void loadLevel(){
		SceneManager.LoadScene(levelToLoad);

	}
}