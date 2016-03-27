using UnityEngine;
using System.Collections;

public class DestroyDestructibleBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
			Destroy (gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
			Destroy (gameObject);
		}
	}
}
