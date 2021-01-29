using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public Transform playerTransform;
	float clampedx;
	float clampedy;
	public float XMIN, XMAX, YMIN, YMAX;
	public Vector3 offset;

    void Start()
    {
	
    }

    void Update()
    {
		clampedx = Mathf.Clamp(playerTransform.position.x, XMIN, XMAX);
		clampedy = Mathf.Clamp(playerTransform.position.y, YMIN, YMAX);
		transform.position = new Vector3(clampedx + offset.x, clampedy + offset.y, -10);
	}
}
