using UnityEngine;
using System.Collections;

public class onLose : MonoBehaviour {

	public string level = "StartScreen";

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(5);
		Application.LoadLevel(level);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
