using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D playerRigidbody;
	Animator playerAnimator;
	public float speed = 5f;
	bool hasLegs; //allows walk and jump
	bool rightHand; //allows hang
	[HideInInspector]
	public bool leftHand; //allows climbing ladders and exit game
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
		playerAnimator = GetComponent<Animator>();
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
		animationTrigger = "Roll";
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
		playerAnimator.SetTrigger(trigger);
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
		animationTrigger = "Walk";
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
			Destroy(otherCollider.gameObject);
		}
		if(otherCollider.gameObject.tag == "RightHand")
		{
			AttachRightHand();
			Destroy(otherCollider.gameObject);
		}
		if (otherCollider.gameObject.tag == "Legs")
		{
			AttachLegs();
			Destroy(otherCollider.gameObject);
		}
	}

}

