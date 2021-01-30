using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{

	public float speed;
	bool movingRight;
	public Transform groundDetection;
	RaycastHit2D patrolRay;

	void Update()
    {
		Patrol();

	}

	public void Patrol()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		patrolRay = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
		if (patrolRay.collider == false)
		{
			if (movingRight == true)
			{
				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;
			}
			else
			{
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;
			}
		}

	}


}
