using UnityEngine;
using System.Collections;

public class PassCollisionToParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D collision) {
		AcidFlip acid = GetComponentInParent<AcidFlip>();
		acid.collision2 (collision);
	}

	void OnCollisionEnter2D( Collision2D collision) {
		AcidFlip acid = GetComponentInParent <AcidFlip>();
		acid.collision2 (collision);
	}
}
