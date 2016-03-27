using UnityEngine;
using System.Collections;

public class HitDestructibleBlock : MonoBehaviour {

	public GameObject crack2;

	// Use this for initialization
	void Start () {
		crack2 = GameObject.Find ("crack2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
			Destroy (gameObject);
			float x = gameObject.transform.position.x;
			float y = gameObject.transform.position.y;
			float z = gameObject.transform.position.z;
			Instantiate (crack2, new Vector3(x, y, z), Quaternion.identity);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
			Destroy (gameObject);
			float x = gameObject.transform.position.x;
			float y = gameObject.transform.position.y;
			float z = gameObject.transform.position.z;
			Instantiate (crack2, new Vector3(x, y, z), Quaternion.identity);
		}
	}
}
