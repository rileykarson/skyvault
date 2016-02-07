using UnityEngine;
using System.Collections;

public class EnochScript : MonoBehaviour {

	public float speed = 16f;
    int bulletCooldown = 0;
	public GameObject bullet;

    float velocityX = 0;
    float velocityY = 0;
    bool onGround = true;
	private Animator animator;

	// Use this for initialization
	void Start () {

		animator = this.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && bulletCooldown == 0) {
			Instantiate(bullet, transform.position + new Vector3(.60f,-.1f,0), Quaternion.identity);
            bulletCooldown = 30;
		}
        if (bulletCooldown > 0) {
            bulletCooldown--;
        }
			
    }

    void FixedUpdate()
    {

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		if (vertical > 0) {
			animator.SetInteger ("Direction", 2); // Stand still
		} 
		else if (vertical < 0) {
			animator.SetInteger ("Direction", 2); // Stand still
		} 
		else if (horizontal > 0 && velocityX != 0)
		{
			animator.SetInteger("Direction", 3); // Left animation
		}
		else if (horizontal < 0 && velocityX != 0)
		{
			animator.SetInteger("Direction", 1); // Right animation
		}


		if (velocityX == 0) {
			animator.SetInteger ("Direction", 2); // Stand still
		}
        if (velocityX > 0)
        {
            velocityX -= 0.025f;
            if (velocityX < 0) velocityX = 0;
        }
        if (velocityX < 0)
        {
            velocityX += 0.025f;
            if (velocityX > 0) velocityX = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocityX -= 0.05f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocityX += 0.05f;
        }
        if (velocityX >= 1)
        {
            velocityX = 1;
        }
        if (velocityX <= -1)
        {
            velocityX = -1;
        }
        transform.Translate(new Vector2(velocityX, 0) * speed * Time.deltaTime);
        if (IsGrounded() == true)
        {
            if (InGround())
            {
                transform.Translate(new Vector2(0, 1f));
                int layerMask = 1 << 8;
                layerMask = ~layerMask;
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 2, layerMask);
                //Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.down * 2);
                if (hit)
                {
                    float dist = -hit.distance + 1;
                    transform.Translate(new Vector2(0, dist));
                    velocityY = 0;
                }
            }
            
        } else {
            if (velocityY > -.8f) velocityY += -0.1f;
            var vec = new Vector2(0, velocityY * speed * Time.deltaTime);
            var vec2 = Vector2.down + vec;
            Ray2D ray = new Ray2D(transform.position, vec2);
            Ray2D ray2 = new Ray2D(transform.position, new Vector2(0,0));
            if (velocityY <= 0) {
                int layerMask = 1 << 8;
                layerMask = ~layerMask;
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 2, layerMask);
                //Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.down * 2);
                if (hit)
                {
                    float dist = -hit.distance + 1;
                    transform.Translate(new Vector2(0, dist));
                    velocityY = 0;
                }
                else
                {
                    transform.Translate(new Vector2(0, velocityY) * speed * Time.deltaTime);
                }
            } else
            {
                transform.Translate(new Vector2(0, velocityY) * speed * Time.deltaTime);
            }
            
        }
        if (Input.GetKey(KeyCode.W) && IsGrounded())
        {
            velocityY = 1.5f;
            transform.Translate(new Vector2(0, velocityY) * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(onGround);
        onGround = true;
        velocityY = 0;
    }

    bool IsGrounded(){
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, layerMask);
        Debug.DrawRay(transform.position, Vector2.down * 1.1f, Color.red);
        //Debug.Log(hit.collider.gameObject.name);
        return hit;
        //return Physics2D.Raycast(transform.position, Vector2.down, 1.01f, layerMask);
    }

    bool InGround()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, layerMask);
        //Debug.DrawRay(transform.position, Vector2.down, Color.blue);
        //Debug.Log(hit.collider.gameObject.name);
        return hit;
    }

    bool CloseBelow()
    {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * 1.05f, 1, layerMask);
            //Debug.DrawRay(transform.position, Vector2.down * 1.05f, Color.green);
            //Debug.Log(hit.collider.gameObject.name);
            return hit;
    }
}
