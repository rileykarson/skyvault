using UnityEngine;
using System.Collections;

public class onLevelLoad : MonoBehaviour {

	public string level;
	public string nextlevel;

	// Use this for initialization
	void Start () {
		State.thislevel = level;
		State.nextlevel = nextlevel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
