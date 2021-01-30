using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Player player;
	public Switch switched;
	public GameObject door2;
	public int counter;
	public Text counterText;
	public Text storyLineText;
	public GameObject storyCanvas;
	public GameObject gameOverCanvas;
	public AudioClip[] audioClips;
	public AudioSource audioSource;
	bool stopText;
	int bodyPart;
	bool torso, legs, rightHand, leftHand;
	bool isText;
	int whichText;

    void Start()
    {
		StartCoroutine(DisplayStory());
		
	}

	void Update()
	{
		counter = Mathf.FloorToInt(Time.timeSinceLevelLoad);
		counterText.text = "Time alone: " + counter.ToString();
		isText = player.displayText;
		whichText = player.textKey;
		torso = player.torso;
		legs = player.hasLegs;
		rightHand = player.rightHand;
		leftHand = player.leftHand;
		bodyPart = player.bodyPart;
		stopText = player.stopText;
		door2.SetActive(switched.off);
		if (isText)
		{
			DisplayOtherTexts(whichText);
		}
		if (stopText)
		{
			StopText();
		}
		if (switched.pingSfx)
		{
			switched.pingSfx = false;
			audioSource.PlayOneShot(audioClips[1], 0.7f);

		}
		if(player.door1 == false)
		{
			audioSource.PlayOneShot(audioClips[0], 0.6f);
			player.door1 = true;
		}
		if (player.game && player.leftHand)
		{
			GameOver();
		}
	}

	public void GameOver()
	{
		gameOverCanvas.SetActive(true);
		counterText.text = "Too long...";
	}

	IEnumerator DisplayStory()
	{
		yield return new WaitForSeconds(1);
		storyCanvas.SetActive(true);
		for (int i = 0; i < StoryTexts.texts.Length; i++)
		{
			storyLineText.text = StoryTexts.texts[i];
			yield return waitForKeyPress(KeyCode.K);
		}

		yield return waitForKeyPress(KeyCode.K);
		storyCanvas.SetActive(false);
	}

	private IEnumerator waitForKeyPress(KeyCode key)
	{
		bool done = false;
		while (!done)
		{
			if (Input.GetKeyDown(key))
			{
				done = true;
			}
			yield return null;
		}
	}

	public void DisplayOtherTexts(int whichText)
	{
		storyCanvas.SetActive(true);
		storyLineText.text = StoryTexts.otherTexts[whichText];
		isText = false;
	} 
	public void StopText()
	{
		storyCanvas.SetActive(false);

	}

	public void RestartLevel()
	{
		SceneManager.LoadScene("Level1");
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
