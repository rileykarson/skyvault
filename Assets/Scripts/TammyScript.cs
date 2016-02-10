using UnityEngine;
using System.Collections;

public class TammyScript : MonoBehaviour {

    int bulletCooldown = 0;
	public GameObject bullet;
	public GameObject particle;
	PlatformerCharacter2D player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<PlatformerCharacter2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
		if (Input.GetMouseButton(0) && bulletCooldown == 0) {
			Instantiate(bullet, transform.position + (new Vector3(0, -.1f) *player.getVerticalFlip() + new Vector3(.60f,0,0) * player.getFacingRight()), Quaternion.identity);
			GameObject par = Instantiate(particle, transform.position + (new Vector3(0, -.1f)*player.getVerticalFlip() + new Vector3(.60f,0,0) * player.getFacingRight()), Quaternion.identity) as GameObject;
			par.transform.parent = transform;
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
