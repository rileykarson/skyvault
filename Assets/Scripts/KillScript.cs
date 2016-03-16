using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillScript : MonoBehaviour {

	public bool godmode = false;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!godmode) {
			if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Hazard")) {
				State.nextlevel = State.thislevel;
				State.loselevel ();
				SceneManager.LoadScene("YouLose");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (!godmode) {
			if (collision.gameObject.layer == LayerMask.NameToLayer ("Hazard")) {
				State.nextlevel = State.thislevel;
				State.loselevel ();
				SceneManager.LoadScene("YouLose");
			}
		}
	}
}
