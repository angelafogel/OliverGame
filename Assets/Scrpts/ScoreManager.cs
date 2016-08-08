using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public bool negPoints;
	public bool pos2000Points;

	public Text text;


	void Start()
	{
		text = GetComponent<Text> ();
		score = 0;

	}

	void Update ()
	{
		//updates the score text on the screen
		text.text = "" + score; 
		negPoints = AtNegativePoints ();

		if (score >= 2000)
		{
            Application.LoadLevel (4);
			ScoreMgr2.score = score;
        }

		if (negPoints == true) 
		{
            Application.LoadLevel (2);
		} 
	
	}

	//allows anyone to access the score manager
	public static void AddPoints (int points) 
	{
		score += points;
	}
	
	public bool AtNegativePoints()
	{
		return (score < -50);
	}

	public static void SetZeroPoints()
	{
		score = 0;

	}
}
