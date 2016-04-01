using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour {

	private Animator m_Anim;
	private int countdown = 51;

	// Use this for initialization
	void Start () {
		m_Anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		if (countdown == 0) {
			m_Anim.SetFloat ("Door_Open", 2);
		}
		if (countdown == 40) {
			m_Anim.SetFloat ("Door_Open", 1);
		}
		if (countdown < 51){
			countdown--;
		}
	}

	IEnumerator OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			if (countdown == 51) {
				countdown--;
			}
			yield return new WaitForSeconds (1);
			UnityEngine.SceneManagement.SceneManager.LoadScene("YouWin");
		}
	}
}
