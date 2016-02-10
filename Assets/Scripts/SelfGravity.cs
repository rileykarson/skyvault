using UnityEngine;
using System.Collections;

public class SelfGravity : MonoBehaviour {

	int cooldown = 0;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		cooldown = 0;
		body = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		if (Input.GetKey("q") && cooldown == 0) {
			//Debug.Log ("gravity halp");
			body.gravityScale *= -1;
			cooldown = 25;
			// Multiply the player's y local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.y *= -1;
			transform.localScale = theScale;
		} else if (cooldown > 0) {
			cooldown--;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
