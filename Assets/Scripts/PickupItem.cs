using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Attach this script to every pickup item
public class PickupItem : MonoBehaviour {

	public int value = 1000;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		State.addScore(value);
		Destroy (gameObject);
	}
}
