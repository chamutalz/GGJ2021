using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D playerRigidbody;
	Animator playerAnimator;
	public float speed = 5f;
	bool hasLegs; //allows walk and jump
	bool rightHand; //allows picking up key
	bool torso; //allows crawl (bigger collider)
	[HideInInspector]
	public bool leftHand; //allows exit game
	Vector2 playerPosition;
	CapsuleCollider2D myCapsule;
	float inputX;
	bool facingRight;
	bool grounded;
	string animationTrigger;


    void Start()
    {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
		myCapsule = gameObject.GetComponent<CapsuleCollider2D>();
		facingRight = true;
		hasLegs = false;
		animationTrigger = "Idle";
    }

    void Update()
    {
		inputX = Input.GetAxisRaw("Horizontal");
		playerPosition = new Vector2(inputX, 0);
		if (inputX != 0 && !hasLegs && !rightHand && !torso)
			animationTrigger = "Roll";
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
					playerRigidbody.AddForce(new Vector2(0, 6.5f), ForceMode2D.Impulse);
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
		Debug.Log("animate(trigger) = " + trigger);
		playerAnimator.SetTrigger(trigger);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

	public bool AttachTorso()
	{
		animationTrigger = "Crawl";
		Vector2 newSize = new Vector2(2.5f, 2.5f);
		myCapsule.size = newSize;
		torso = true;
		return torso;
	}

	public bool AttachRightHand()
	{
		animationTrigger = "RightHandWalk";
		rightHand = true;
		return rightHand;
	}

	public bool AttachLeftHand()
	{
		leftHand = true;
		return leftHand;
	}

	public bool AttachLegs()
	{
		animationTrigger = "Walk";
		Vector2 newSize = new Vector2(2.2f, 4.3f);
		myCapsule.size = newSize;
		hasLegs = true;
		return hasLegs;
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
		if(otherCollider.gameObject.tag == "Torso")
		{
			AttachTorso();
			Destroy(otherCollider.gameObject);
		}
	}

}

