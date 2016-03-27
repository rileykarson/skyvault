using UnityEngine;
using System.Collections;

public class AlexisScript : MonoBehaviour {

	public GameObject audioObj;
	public GameObject newImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		Instantiate (audioObj, transform.position, Quaternion.identity);
		var render = this.GetComponent<SpriteRenderer> ();
		Instantiate (newImage, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
