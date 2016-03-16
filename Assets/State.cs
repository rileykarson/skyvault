using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

	public static int score;
	public static int currentScore;

	public static string thislevel;
	public static string nextlevel;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static int getScore(){
		return (score + currentScore);
	}

	public static void loselevel(){
		currentScore = -1000;
	}

	public static void addScore(int s){
		currentScore += s;
	}

	public static void nextLevel(){
		score += currentScore;
		currentScore = 0;
	}
}
