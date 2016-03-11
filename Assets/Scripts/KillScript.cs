using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillScript : MonoBehaviour {

	public bool godmode = false;

	IEnumerator OnCollisionEnter2D(Collision2D collision)
	{
		if (!godmode) {
			if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Hazard")) {
				Application.LoadLevel ("YouLose");
				yield return new WaitForSeconds (5);
				Application.LoadLevel ("StartScreen");
			}
		}
	}

	IEnumerator OnTriggerEnter2D(Collider2D collision)
	{
		if (!godmode) {
			if (collision.gameObject.layer == LayerMask.NameToLayer ("Hazard")) {
				Application.LoadLevel ("YouLose");
				yield return new WaitForSeconds (5);
				Application.LoadLevel ("StartScreen");
			}
		}
	}
}
