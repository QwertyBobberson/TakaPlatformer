using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
	[SerializeField] Button startButton;
	[SerializeField] Button quitButton;
	[SerializeField] Text HighScoreText;

	[SerializeField] int gameScene;

	private void Start()
	{
		startButton.onClick.AddListener(LoadGame);
		quitButton.onClick.AddListener(CloseGame);
		HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
	}

	private void LoadGame()
	{
		SceneManager.LoadScene(gameScene);
	}

	private void CloseGame()
	{
		Application.Quit();
	}

}