using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Attach this script to every pickup item
public class PickupItem : MonoBehaviour {

	public static int pickupCount = 0;

	public Text text; // set this to the uitext object for at least one of the pickup items in unity
	static Text textRef;  // keep track of the score display (static so you don't need to attach the uitext item to every pickupitem)

	// Use this for initialization
	void Start () {
		if (text!=null)textRef = text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		pickupCount++;
		if (textRef != null) textRef.text = "Score: " + pickupCount*1000;
		Destroy (gameObject);
	}
}
