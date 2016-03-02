using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillScript : MonoBehaviour {

	IEnumerator OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Hazard")) {
			Application.LoadLevel ("YouLose");
			yield return new WaitForSeconds(5);
			Application.LoadLevel("StartScreen");
		}
	}
		
}
