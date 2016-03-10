using UnityEngine;
using System.Collections;

public class SelfGravity : MonoBehaviour {

	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	public bool flipping = false;
	public GameObject particle;

	private GameObject particleActive = null;
	int cooldown = 0;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		cooldown = 0;
		body = gameObject.GetComponent<Rigidbody2D> ();
		m_GroundCheck = transform.Find("GroundCheck");
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders [i].gameObject != gameObject) {
				m_Grounded = true;
				flipping = false;
				if (particleActive != null) {
					Destroy (particleActive);
					particleActive = null;
				}
			}

		}
		if (Input.GetKey("q") && cooldown == 0 && m_Grounded) {
			//Debug.Log ("gravity halp");
			flipping = true;
			body.gravityScale *= -1;
			cooldown = 25;
			// Multiply the player's y local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.y *= -1;
			transform.localScale = theScale;
			particleActive = Instantiate(particle, transform.position, Quaternion.identity) as GameObject;
			particleActive.transform.parent = transform;

		} else if (cooldown > 0) {
			cooldown--;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
