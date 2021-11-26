using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour 
{

	[SerializeField] int menuSceneIndex;
	[SerializeField] int maxHealth;

	[SerializeField] Text scoreText;
	[SerializeField] Image healthBox;

	[SerializeField] Sprite[] hearts;

	public int health;
	public int score;

	public bool gameOver;

	private void Start()
	{
		health = maxHealth;
		Time.timeScale = 1;
		gameOver = false;
	}

	public void Update()
	{
		health = Mathf.Clamp(health, 0, 4);
		scoreText.text = "Score: " + score;
		healthBox.sprite = hearts[health];
		if (health <= 0)
		{
			gameOver = true;
			SetHighScore();
			Invoke("LoadMenu", 3f);
		}
	}

	private void SetHighScore()
	{
		if (score > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", score);
		}
	}

	private void LoadMenu()
	{
		SceneManager.LoadScene(menuSceneIndex, LoadSceneMode.Single);
	}
}