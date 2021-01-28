using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
	public int partNumber;
	public string partName;
	[SerializeField]
	bool collected;

    void Start()
    {
		collected = false;   
    }

    void Update()
    {
        
    }
}
