using UnityEngine;
using System.Collections;

public class GaurdScript : MonoBehaviour {

	public Transform player;
	private int distance = 10;
	private bool playerCloseEnough = false;

	int bulletCooldown = 0;
	public GameObject bullet;
	public GameObject particle;

	private Rigidbody2D m_Rigidbody2D;
	private Animator animator;

	private Vector3 frometh;
	private Vector3 untoeth;
	private float secondsForOneLength = 8f;

	private float old_x;

	private int facing_right;
	private int facing_left;

	// Use this for initialization
	void Start () {
		frometh = transform.position;
		untoeth = transform.position;
		untoeth.x += 11;
		animator = this.GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		old_x = transform.position.x;
		facing_right = 1;
		facing_left = 0;
	}

	
	// Update is called once per frame
	void Update () {
        
		transform.position = Vector3.Lerp(frometh, untoeth,Mathf.SmoothStep(0f,1f,Mathf.PingPong(Time.time/secondsForOneLength, 1f)));

		if (old_x > transform.position.x) {
			animator.SetInteger ("Direction", 3); // LEft
			//animator.SetFloat ("Direction", 2);
			facing_right = 0;
			facing_left = 1;
		} else if (old_x < transform.position.x) {
			animator.SetInteger ("Direction", 2); // Right
			//animator.SetFloat ("Direction", 1);
			facing_right = 1;
			facing_left = 0;
		} else {
			animator.SetInteger ("Direction", 1);
		}
		old_x = transform.position.x;
			
		if(Vector3.Distance(transform.position, player.position) < distance){
			playerCloseEnough = true;

			if (bulletCooldown == 0) {
				Instantiate(bullet, transform.position+(new Vector3(0, -.1f) *player.localScale.y + new Vector3(.60f,0,0) * facing_right + new Vector3(-.60f,0,0) * facing_left), Quaternion.identity);
				GameObject par = Instantiate(particle, transform.position+(new Vector3(0, -.1f) *player.localScale.y + new Vector3(.60f,0,0) * facing_right + new Vector3(-.60f,0,0) * facing_left) , Quaternion.identity) as GameObject;
				par.transform.parent = transform;
				bulletCooldown = 50;
			}
			if (bulletCooldown > 0) {
				bulletCooldown--;
			}   


		}else{
			playerCloseEnough = false;
		}
    }

    void FixedUpdate()
    {



    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }


}
