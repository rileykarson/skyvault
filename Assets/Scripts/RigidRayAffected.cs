using UnityEngine;
using System.Collections;

public class RigidRayAffected : MonoBehaviour {

	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called onc e per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "RayShot") {
			body.gravityScale *= -1;
			body.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*-1, transform.localScale.z);
		}
	}
}
