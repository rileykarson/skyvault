using UnityEngine;
using System.Collections;

public class onGooHit : MonoBehaviour {

	public GameObject goo;
	public GameObject acid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "MovingGoo") {
			Vector3 playerPos = transform.position;
			Destroy(gameObject);
			GameObject obj = Instantiate (goo, playerPos, Quaternion.identity) as GameObject;
			Vector3 theScale = obj.transform.localScale;
			Vector3 thePosition = obj.transform.position;
			if (collision.transform.position.y <= thePosition.y){
				theScale.y *= -1;
				obj.transform.localScale = theScale;
			}
		}
		else if (collision.gameObject.tag == "MovingAcid") {
			Vector3 playerPos = transform.position;
			Destroy(gameObject);
			GameObject obj = Instantiate (acid, playerPos, Quaternion.identity) as GameObject;
			Vector3 theScale = obj.transform.localScale;
			Vector3 thePosition = obj.transform.position;
			if (collision.transform.position.y <= thePosition.y){
				theScale.y *= -1;
				obj.transform.localScale = theScale;
			}
		}
	}
}
