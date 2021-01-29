using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D playerRigidbody;
	Animator playerAnimator;
	public float speed = 5f;
	bool hasLegs;
	bool rightHand;
	bool leftHand;
	Vector2 playerPosition;
	float inputX;
	bool facingRight;
	bool grounded;
	string animationTrigger;
	public int bodyPartCollected = 0; // change to bodypart
	//public GameObject[] bodyparts;

    void Start()
    {
		playerRigidbody = GetComponent<Rigidbody2D>();
		facingRight = true;
		hasLegs = false;
    }

    void Update()
    {
		inputX = Input.GetAxisRaw("Horizontal");
		playerPosition = new Vector2(inputX, 0);
		Move(hasLegs);
		Animate(animationTrigger);
		Flip();
    }

	public void Move(bool legs)
	{
		transform.Translate(playerPosition * speed * Time.deltaTime);
		if(legs)
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

	public void Animate(string trigger)
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

	public bool AttachRightHand()
	{
		rightHand = true;
		return rightHand;
	}

	public bool DetachRightHand()
	{
		rightHand = false;
		return rightHand;
	}

	public bool AttachLeftHand()
	{
		leftHand = true;
		return leftHand;
	}

	public bool DetachLeftHand()
	{
		leftHand = false;
		return leftHand;
	}

	public bool AttachLegs()
	{
		hasLegs = true;
		return hasLegs;
	}

	public bool DetachLegs()
	{
		return false;
	}

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.gameObject.tag == "LeftHand")
		{
			AttachLeftHand();
		}
		if(otherCollider.gameObject.tag == "RightHand")
		{
			AttachRightHand();
		}
		if(otherCollider.gameObject.tag == "Legs")
		{
			AttachLegs();
		}
	}
}

