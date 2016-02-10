﻿using UnityEngine;
using System.Collections;

public class RigidRayAffectedFlipScript : MonoBehaviour {
	
	private Rigidbody2D body;


	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RayShot") {
			body.gravityScale *= -1;		
			transform.Rotate(new Vector3(0,0,180));

        }
    }
}
