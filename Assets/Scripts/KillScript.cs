using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
			Application.LoadLevel("StartScreen");
		}
	}
		
}
