using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
	public GameObject aboutCanvas;
	public AudioSource menuAudioSource;

	public void StartGame()
	{
		menuAudioSource.Play();
		SceneManager.LoadScene("Level1");
	}

	public void About()
	{
		menuAudioSource.Play();
		aboutCanvas.SetActive(true);
	}

	public void CloseAbout()
	{
		menuAudioSource.Play();
		aboutCanvas.SetActive(false);
	}

	public void Quit()
	{
		menuAudioSource.Play();
		Application.Quit();
	}
}
