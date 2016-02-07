using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	float speed = 16f;
	// Use this for initialization
	void Start () {
		var playerObject = GameObject.Find("player-character 1");
		Vector3 playerPos = playerObject.transform.position;
		Debug.Log("Current player position: " + playerPos);
		Vector3 pz = playerPos - transform.position;
		pz.z = 0;
		var ratiox = pz.x / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		var ratioy = pz.y / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		var rigid = GetComponent<Rigidbody2D>();
		rigid.velocity = new Vector2 (speed*ratiox, speed*ratioy);
		Debug.Log (speed * ratiox + " " + speed * ratioy);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Gets called when the object goes out of the screen
	void OnBecameInvisible() {
		// Destroy the bullet
		Destroy(gameObject);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
