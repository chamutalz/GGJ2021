using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D playerRigidbody;
	Animator playerAnimator;
	public float speed = 5f;
	Vector2 playerPosition;
	float inputX;
	bool facingRight;
	bool grounded;
	public int bodyPartCollected = 0; // change to bodypart
	public GameObject[] bodyparts;

    void Start()
    {
		playerRigidbody = GetComponent<Rigidbody2D>();
		facingRight = true;
    }

    void Update()
    {
		inputX = Input.GetAxisRaw("Horizontal");
		playerPosition = new Vector2(inputX, 0);
		Move(bodyPartCollected);
		Animate();
		Flip();
    }

	public void Move(int bodyPart)
	{
		transform.Translate(playerPosition * speed * Time.deltaTime);
		if(bodyPart > 1)
		{
			if (Input.GetKeyDown("space"))
			{
				if (grounded)
				{
					playerRigidbody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
					grounded = !grounded;
				}
			}

		}
	}

	public void Flip()
	{
		if(facingRight && inputX < 0 || !facingRight && inputX > 0)
		{
			facingRight = !facingRight;
			Vector3 mirror = transform.localScale;
			mirror.x *= -1;
			transform.localScale = mirror;
		}
	}

	public void Animate()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}
}
