using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject Player;
	public int counter;
	public Text counterText;
	public AudioClip[] audioClips;
	public AudioSource audioSource;
    void Start()
    {
		counter = 0;   
    }

    void Update()
    {
		counter = Mathf.FloorToInt(Time.timeSinceLevelLoad);
		counterText.text = counter.ToString();
    }
}
