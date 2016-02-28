using UnityEngine;
using System.Collections;

public class LevelFinished : MonoBehaviour {

	public string SceneName;
	private Animator m_Anim;
	private int countdown = 51;

	// Use this for initialization
	void Start () {
		m_Anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		if (countdown == 0) {
			Application.LoadLevel (SceneName);
		}
		if (countdown == 40) {
			m_Anim.SetFloat ("Door_Open", 1);
		}
		if (countdown < 51){
			countdown--;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			if (countdown == 51) {
				countdown--;
			}
		}
	}
}
