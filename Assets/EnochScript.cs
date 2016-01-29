using UnityEngine;
using System.Collections;

public class EnochScript : MonoBehaviour {

	float speed = 16f;
    int bulletCooldown = 0;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && bulletCooldown == 0) {
			Instantiate(bullet, transform.position + new Vector3(.60f,-.1f,0), Quaternion.identity);
            bulletCooldown = 30;
		}
        if (bulletCooldown > 0) {
            bulletCooldown--;
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
