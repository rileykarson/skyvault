using UnityEngine;
using System.Collections;

public class RayScript : MonoBehaviour {
	float speed = 16f;
	// Use this for initialization
	void Start () {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		pz.z = 0;
		var ratiox = pz.x / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		var ratioy = pz.y / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		var rigi = GetComponent<Rigidbody2D>();
		rigi.velocity = new Vector2 (speed*ratiox, speed*ratioy);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Gets called when the object goes out of the screen
	void OnBecameInvisible() {  
		// Destroy the bullet 
		Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
    	if (collision.gameObject.tag != "Player") {
    		Destroy(gameObject);
    	}
    }
}
