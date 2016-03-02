using UnityEngine;
using System.Collections;


public class TurretScript : MonoBehaviour {

	int bulletCooldown = 0;
	public GameObject bullet;
	private Animator m_Anim;
	public GameObject playerObject;
	public bool fixedTurret = false;

	// Use this for initialization
	void Start () {
		bulletCooldown = 0;
		if (!fixedTurret) {
			m_Anim = GetComponent<Animator>();
		}
		playerObject = GameObject.Find("player-character");
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		float xCoord = 0;
		float yCoord = 0;
		float zCoord = 0;
		bool turretEnabled = false;

		Vector3 playerPos = playerObject.transform.position;
		Vector3 line = playerPos - transform.position;
		Vector3 forward = transform.forward;

		Vector2 line2D;
		line2D.x = line.x;
		line2D.y = line.y;

		Vector2 forward2D;
		forward2D.x = forward.x + 1;
		forward2D.y = forward.y;

		float angle = Vector2.Angle(line2D, forward2D);
		if (fixedTurret == true) {
			xCoord = -0.6f;
			yCoord = 0.1f;
			turretEnabled = (angle > 135) && (angle < 180);
		} else {

			turretEnabled = Vector3.Distance (playerPos, transform.position) < 10;

			if (line2D.y < 0) {
				if (line2D.x > 0) {
					xCoord = 0.48f;
					yCoord = 0.4f;
					m_Anim.SetFloat ("Blend", 7);
				} else {
					xCoord = -0.48f;
					yCoord = 0.4f;
					m_Anim.SetFloat ("Blend", 1);
				}
			} else if (angle > 135) {
				xCoord = -0.48f;
				yCoord = 0.4f;
				m_Anim.SetFloat("Blend", 1);
			} else if (angle > 117) {
				xCoord = -0.32f;
				yCoord = 0.46f;
				m_Anim.SetFloat("Blend", 2);
			} else if (angle > 99) {
				xCoord = -0.16f;
				yCoord = 0.52f;
				m_Anim.SetFloat("Blend", 3);
			} else if (angle > 81) {
				xCoord = 0;
				yCoord = 0.58f;
				m_Anim.SetFloat("Blend", 4);
			} else if (angle > 63) {
				xCoord = 0.16f;
				yCoord = 0.52f;
				m_Anim.SetFloat("Blend", 5);
			} else if (angle > 45) {
				xCoord = 0.32f;
				yCoord = 0.46f;
				m_Anim.SetFloat("Blend", 6);
			} else {
				xCoord = 0.48f;
				yCoord = 0.4f;
				m_Anim.SetFloat("Blend", 7);
			}
		}
		if (bulletCooldown == 0) {
			if (turretEnabled) {
				Instantiate (bullet, transform.position + new Vector3 (xCoord, yCoord, zCoord), Quaternion.identity);
				bulletCooldown = 100;
			}
		}
		else {
			bulletCooldown--;
		}
	}
		
}
