using UnityEngine;
using System.Collections;

public class RayAffectedScript : MonoBehaviour {

	public float flippedY = 5;

	private bool flipped = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RayShot") {
        	if (flipped) {
        		transform.Translate(new Vector2(0, flippedY) * -1);
        	} else {
        		transform.Translate(new Vector2(0, flippedY));
        	}
        	flipped = !flipped;	
        }
    }
}
