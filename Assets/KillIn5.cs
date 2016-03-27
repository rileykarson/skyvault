using UnityEngine;
using System.Collections;

public class KillIn5 : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
