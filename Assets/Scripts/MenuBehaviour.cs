using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
	public GameObject aboutCanvas;

	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void About()
	{
		aboutCanvas.SetActive(true);
	}

	public void CloseAbout()
	{
		aboutCanvas.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
