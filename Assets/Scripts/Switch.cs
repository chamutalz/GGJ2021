using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{	
	public bool on = false;
	public bool off = true;
	public bool pingSfx;
	public GameObject switchedOn;
	public GameObject switchedOff;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			on = !on;
			off = !off;
			pingSfx = true;
		}
	}

	private void Update()
	{
		switchedOn.SetActive(on);
		switchedOff.SetActive(off);
	}


}
