using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Player player;
	public int counter;
	public Text counterText;
	public Text storyLineText;
	public GameObject storyCanvas;
	public GameObject gameOverCanvas;
	bool exitKey;
	public AudioClip[] audioClips;
	public AudioSource audioSource;
	StoryTexts storyTexts;

    void Start()
    {
		counter = 0;   
    }

    void Update()
    {
		counter = Mathf.FloorToInt(Time.timeSinceLevelLoad);
		counterText.text = counter.ToString();
		if (exitKey && player.leftHand)
		{
			GameOver();
		}
	}

	public void GameOver()
	{
		//gameOverCanvas.SetActive(true);
	}

	public void DisplayStory()
	{
		storyCanvas.SetActive(true);
		for (int i = 0; i < storyTexts.texts.Length;)
		{
			storyLineText.text = storyTexts.texts[i];
			if (Input.GetKeyDown("k"))
				i++;

		}

	}
}
