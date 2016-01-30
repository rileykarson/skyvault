using UnityEngine;
using System.Collections;

public class EnochScript : MonoBehaviour {

	public float speed = 16f;
    int bulletCooldown = 0;
	public GameObject bullet;

    float velocityX = 0;
    float velocityY = 0;
    bool onGround = true;

	// Use this for initialization
	void Start () {
	
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
        if (Input.GetKey (KeyCode.A)) {
            velocityX -= 0.05f;    
		}
		else if (Input.GetKey (KeyCode.D)) {
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

        if (!IsGrounded() && velocityY > -3)
        {
            velocityY -= .075f;
        }
        if (IsGrounded())
        {
            velocityY = 0;
            if (InGround())
            {
                while (InGround())
                {
                    transform.Translate(new Vector2(0, 0.05f));
                }

            }
        }

		if (Input.GetKey (KeyCode.W)) {
            if (IsGrounded() == true) velocityY = 1.5f;
            onGround = false;
		}
		else if (Input.GetKey (KeyCode.S)) {
			//transform.Translate(-Vector2.up * speed * Time.deltaTime);  
		}

        transform.Translate(new Vector2(velocityX, velocityY) * speed * Time.deltaTime);
        if(CloseBelow())
        {
            while (!IsGrounded())
            {
                transform.Translate(new Vector2(0, .05f));
            }
            velocityY = 0;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.01f, layerMask);
        Debug.DrawRay(transform.position, Vector2.down * 1.01f, Color.red);
        //Debug.Log(hit.collider.gameObject.name);
        return hit;
        //return Physics2D.Raycast(transform.position, Vector2.down, 1.01f, layerMask);
    }

    bool InGround()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, layerMask);
        Debug.DrawRay(transform.position, Vector2.down, Color.blue);
        //Debug.Log(hit.collider.gameObject.name);
        return hit;
    }

    bool CloseBelow()
    {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * 1.05f, 1, layerMask);
            Debug.DrawRay(transform.position, Vector2.down * 1.05f, Color.green);
            //Debug.Log(hit.collider.gameObject.name);
            return hit;
    }
}
