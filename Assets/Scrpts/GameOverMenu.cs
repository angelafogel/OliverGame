using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour 
{
	
	public Canvas gameOverSceneCanvas;
	public Button restartButton;
	public Button gameOverExitButton;
	
	void Start ()
	{
		gameOverSceneCanvas = gameOverSceneCanvas.GetComponent<Canvas> ();
		restartButton = restartButton.GetComponent<Button> ();
		gameOverExitButton = gameOverExitButton.GetComponent<Button> ();
	}
	
	public void RestartPress()
	{
		ScoreManager.SetZeroPoints ();
		Application.LoadLevel (1);
	}
	

	public void gameOverExit()
	{
		Application.LoadLevel (0);
	}
}