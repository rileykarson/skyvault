using UnityEngine;
using System.Collections;

public class onLose : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		State.nextLevel ();
		yield return new WaitForSeconds(5);
		UnityEngine.SceneManagement.SceneManager.LoadScene (State.nextlevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
