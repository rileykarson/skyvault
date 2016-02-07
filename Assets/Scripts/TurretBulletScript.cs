﻿using UnityEngine;
using System.Collections;

public class TurretBulletScript : MonoBehaviour {
	float speed = 16f;
	// Use this for initialization
	void Start () {
		var playerObject = GameObject.Find("player-character-alpha");
		Vector3 playerPos = playerObject.transform.position;
		Vector3 pz = playerPos - transform.position;
		pz.z = 0;
		var ratiox = pz.x / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		var ratioy = pz.y / (Mathf.Abs(pz.x) + Mathf.Abs(pz.y));
		var rigid = GetComponent<Rigidbody2D>();
		rigid.velocity = new Vector2 (speed*ratiox, speed*ratioy);
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
