using UnityEngine;
using System.Collections;

public class GooParticle : MonoBehaviour {

	public GameObject particle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Instantiate (particle, transform.position, Quaternion.identity);
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		Instantiate (particle, transform.position, Quaternion.identity);
	}
}
