using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string levelToLoad;

	public void loadLevel(){
		Application.LoadLevel(levelToLoad);

	}
}