using UnityEngine;
using System.Collections;

public class RayAffectedScript : MonoBehaviour {
	
	public float midYOffset = 2.5f;
	public float endYOffset = 5;

	public float flippedY = 5;

	private float initialY;
	private float midY;
	private float endY;

	private int state = 1;

	// Use this for initialization
	void Start () {
		initialY = transform.position.y;
		midY = transform.position.y + midYOffset;
		endY = transform.position.y + endYOffset;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == -1 && transform.position.y != endY) {
			transform.Translate (new Vector2 (0, 1));
		} else if (state == 1 && transform.position.y != initialY) {
			transform.Translate (new Vector2 (0, -1));
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RayShot") {
        	if (state == 1) {
        		//transform.Translate(new Vector2(0, flippedY));
				state = -1;
        	} else {
        		//transform.Translate(new Vector2(0, flippedY) * -1);
				state = 1;
        	}
        }
    }
}
