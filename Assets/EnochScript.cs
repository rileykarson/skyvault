﻿using UnityEngine;
using System.Collections;

public class EnochScript : MonoBehaviour {

	float speed = 8f;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey( KeyCode.Q )) {
			Instantiate(bullet, transform.position, Quaternion.identity);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(-Vector2.right * speed * Time.deltaTime);    
		}
		else if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);   
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.S)) {
			transform.Translate(-Vector2.up * speed * Time.deltaTime);  
		}
	}
}
