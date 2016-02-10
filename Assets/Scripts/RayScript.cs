using UnityEngine;
using System.Collections;

public class RayScript : MonoBehaviour {
	public float speed = 16f;
	public GameObject particle;
	// Use this for initialization
	Rigidbody2D rigi;


	void Start () {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		pz.z = 0;
		var ratiox = pz.x / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		var ratioy = pz.y / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		rigi = GetComponent<Rigidbody2D>();
		rigi.velocity = new Vector2 (speed*ratiox, speed*ratioy);
		Vector2 moveDirection = rigi.velocity;
		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
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
			Instantiate(particle, transform.position, Quaternion.identity);
    	}
    }
}
