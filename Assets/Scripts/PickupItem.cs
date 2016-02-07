using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {

	public static int pickupCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D collision){
		pickupCount++;
		print("number picked up: " + pickupCount);
		Destroy (gameObject);
	}
}
