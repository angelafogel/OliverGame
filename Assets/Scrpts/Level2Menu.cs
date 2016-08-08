using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level2Menu : MonoBehaviour 
{
	
	public Canvas gameOverSceneCanvas;
	public Button restartButton;
	public Button level2ExitButton;
	
	void Start ()
	{
		gameOverSceneCanvas = gameOverSceneCanvas.GetComponent<Canvas> ();
		restartButton = restartButton.GetComponent<Button> ();
		level2ExitButton = level2ExitButton.GetComponent<Button> ();
	}
	
	public void GoPress()
	{
		Application.LoadLevel (7);
	}

	public void RestartPress()
	{
		Application.LoadLevel (1);
	}
	

	public void Level2Exit()
	{
		Application.LoadLevel (0);
	}
}