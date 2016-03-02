using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillScript : MonoBehaviour {

	public Text killText;
	private float _counter = 0;
	private bool _showText = true;
	public bool fl = false;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		//counter is increasing by deltaTime till to reach the trigger time
		_counter += Time.deltaTime;
		//after or equals 5 sec. show a simple GUIText
		if (_counter >= 8 && _showText) {
			_showText = false;
		}

		if (fl == true) {
			//
		}
	}

	void OnGUI()
	{
		//is ready to show the label?
		if (_showText)
		{
			var style = new GUIStyle {fontSize = 48, fontStyle = FontStyle.Bold};
			GUI.Label(new Rect(100, 100, 300, 100), "You Died :(", style);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		fl = true;
		if (collision.gameObject.tag == "Player") {
			OnGUI ();
			if (!_showText) {
				Application.LoadLevel ("StartScreen");
			}
		}
	}
		
}
