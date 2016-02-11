using UnityEngine;
using System.Collections;

public class GooFlip : MonoBehaviour {


	public float midYOffset = 2.5f;
	public float endYOffset = 5;

	public float flippedY = 5;

	private float initialY;
	private float midY;
	private float endY;

	public GameObject go;
	public Sprite plain;
	public GameObject noGoo;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "RayShot") {

			Vector3 playerPos = transform.position;
			float xCoord = playerPos.x;
			float yCoord;
			float zCoord = playerPos.z;

			GameObject g;
			Rigidbody2D body;
			if (transform.localScale.y >= 0) {
				yCoord = playerPos.y + 1.1f;
				g = (GameObject)Instantiate (go, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity);
				body = g.GetComponent<Rigidbody2D> ();
				body.gravityScale *= -1;
			} else {
				yCoord = playerPos.y - 1.1f;
				g = (GameObject)Instantiate (go, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity);
				body = g.GetComponent<Rigidbody2D> ();
			}

			Destroy(gameObject);
			Instantiate (noGoo, playerPos, Quaternion.identity);

		}
	}
}
