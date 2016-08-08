using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuScript : MonoBehaviour 
{
	
	public Canvas exitCanvas;
	public Canvas instruction1Canvas;
	public Canvas instruction2Canvas;
	public Button startButton;
	public Button exitButton;
	public Button info1Button;
	public Button info2Button;
	
	void Start ()
	{
		exitCanvas = exitCanvas.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		exitCanvas.enabled = false;
		instruction1Canvas.enabled = false;
		instruction2Canvas.enabled = false;
	}
	
	public void ExitPress()
	{
		exitCanvas.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
		info1Button.enabled = false;
	}
	
	public void NoPress()
	{
		exitCanvas.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
		info1Button.enabled = false;
	}
	
	public void StartLevel()
	{
		Application.LoadLevel (6);
	}
	
	public void ExitGame()
	{
		Application.Quit ();
	}
	
	public void Info1Press()
	{
		instruction1Canvas.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
		info1Button.enabled = false;
	}

	public void Info2Press()
	{
		instruction2Canvas.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
		info1Button.enabled = false;
		info2Button.enabled = false;
	}
	
	public void InfoExitButtonPress()
	{
		instruction1Canvas.enabled = false;
		instruction2Canvas.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
		info1Button.enabled = true;
		info2Button.enabled = true;
	}
	
}