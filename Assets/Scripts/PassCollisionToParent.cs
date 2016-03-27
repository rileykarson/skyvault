using UnityEngine;
using System.Collections;

public class PassCollisionToParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D collision) {
		//this.collider2D.("OnCollisionEnter2D",collision);
		//this.gameObject.
	}

	void OnCollisionEnter2D( Collision2D collision) {
		//this.collider2D.attachedRigidbody.SendMessage("OnCollisionEnter2D",collision);
	}
}
