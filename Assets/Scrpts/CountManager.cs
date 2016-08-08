using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CountManager : MonoBehaviour {


	public static int pickupCount;

	public Text text;

	void Start()
	{
		text = GetComponent<Text> ();
		pickupCount = 0;

	}

	void Update ()
	{
		//updates the count text on the screen
		text.text = "" + pickupCount; 

		if (pickupCount == 10)
		{
			Application.LoadLevel (5);
		}

	}

	//allows anyone to access the score manager
	public static void AddCount (int count) 
	{
		pickupCount += count;
	}
	
}
