using UnityEngine;
using System.Collections;

public class onLose : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(5);
		Application.LoadLevel("StartScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
