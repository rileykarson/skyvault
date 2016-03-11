using UnityEngine;
using System.Collections;

public class GaurdScript : MonoBehaviour {

	public Transform player;
	private int distance = 10;
	private bool playerCloseEnough = false;

	int bulletCooldown = 0;
	public GameObject bullet;
	public GameObject particle;

	private Vector3 frometh;
	private Vector3 untoeth;
	private float secondsForOneLength = 8f;

	// Use this for initialization
	void Start () {
		frometh = transform.position;
		untoeth = transform.position;
		untoeth.x += 11;
	}

	
	// Update is called once per frame
	void Update () {
        
		transform.position = Vector3.Lerp(frometh, untoeth,Mathf.SmoothStep(0f,1f,Mathf.PingPong(Time.time/secondsForOneLength, 1f)));


		if(Vector3.Distance(transform.position, player.position) < distance){
			playerCloseEnough = true;

			if (bulletCooldown == 0) {
				Instantiate(bullet, transform.position+(new Vector3(0, -.1f) *player.localScale.y + new Vector3(.60f,0,0)), Quaternion.identity);
				GameObject par = Instantiate(particle, transform.position+(new Vector3(0, -.1f) *player.localScale.y + new Vector3(.60f,0,0)) , Quaternion.identity) as GameObject;
				par.transform.parent = transform;
				bulletCooldown = 30;
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
