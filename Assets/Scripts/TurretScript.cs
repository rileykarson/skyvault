using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	int bulletCooldown = 0;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		bulletCooldown = 0;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (bulletCooldown == 0) {
			var playerObject = GameObject.Find("player-character-alpha");
			Vector3 playerPos = playerObject.transform.position;
			Vector3 line = playerPos - transform.position;


			Instantiate (bullet, transform.position + new Vector3(-0.58f, 0.4f, 0), Quaternion.identity);
			bulletCooldown = 100;
		}
		else {
			bulletCooldown--;
		}
	}
		
}
