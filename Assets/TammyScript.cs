using UnityEngine;
using System.Collections;

public class TammyScript : MonoBehaviour {

    int bulletCooldown = 0;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
		if (Input.GetMouseButton(0) && bulletCooldown == 0) {
			Instantiate(bullet, transform.position + new Vector3(.60f,-.1f,0), Quaternion.identity);
			bulletCooldown = 30;
		}
		if (bulletCooldown > 0) {
			bulletCooldown--;
		}   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
