﻿using UnityEngine;
using System.Collections;

public class DestroyCollectibles : MonoBehaviour {

	public int LittleBaloonPoints;
	public int BigBaloonPoints;
	public int AstroidSmallPoints;
	public int AstroidSmallPointsNeg;
	public int AstroidLargePoints;
	public int AstroidLargePointsNeg;
	public int AstroidLargeRisk;
	public int AstroidSmallRisk;
	public int BalloonRisk;
	private int randomNumber = 0;
	private int randomPosition = 0;
	private int probabilitySelection = 0;
	public GameObject[] RandomBagPositionArray;
	public GameObject AstroidLarge;
	public GameObject AstroidSmall;
	public GameObject PointEffect;
	public GameObject BalloonEffect;
	public GameObject Points125NegObject;
	public GameObject Points100PosObject;
	public GameObject Points10NegObject;
	public GameObject Points1000PosObject;

	// 0 for AstroidLarge, 1 for AstroidSmall
	private int bagSize;
	
	
	//populate array to give 20% probability of choosing 0 = -10 pts
	public int[] ProbabilityArray20 = new int[] {0,1,1,1,1};
	
	//populate array to give 50% probability of choosing 0 = -10 pts
	public int[] ProbabilityArray50 = new int[] {0,1};
	
	void OnTriggerEnter2D (Collider2D coll)
	{

		if (coll.tag == "MovingPlatform") 
		{
			transform.position = coll.transform.position;
			
		}  
		if (coll.tag == "LittleBalloon") 
		{
			//updates the points parameter for the AddPoints method in the ScoreManager
			//with the LittleBalloonPoints field created in this script
			//the little balloon has a much smaller collider that has an offset to immitate a 
			//smaller probability of a gain
			ScoreManager.AddPoints (LittleBaloonPoints);
			PickListMgr.pickupList.Add(PickUpMgr.PlayerID, System.DateTime.Now, ScoreManager.score, BalloonRisk);
			Instantiate (BalloonEffect, transform.position, transform.rotation);
			Destroy (coll.gameObject);
			
		}  
		if (coll.tag == "BigBalloon") 
		{
			//updates the points parameter for the AddPoints method in the ScoreManager
			//with the BigBalloonPoints field created in this script
			ScoreManager.AddPoints (BigBaloonPoints);
			PickListMgr.pickupList.Add(PickUpMgr.PlayerID, System.DateTime.Now, ScoreManager.score, BalloonRisk);
			Instantiate (BalloonEffect, transform.position, transform.rotation);
			Destroy (coll.gameObject);
			
		}  
		if (coll.tag == "AstroidLarge") 
		{
			//selects at random an index to select from the probability array
			//random.range(min(inclusive), max(exclusive))
			randomNumber = Random.Range (0, 5);

			//sets bagSize variable for large bag for call to the SpawnRandom method
			bagSize = 0;

			//assigns value at ProbabilityArray20 index to public GameObject[] BalloonArray;probabilitySelection variable
			//for an array of size 5 containing 4 1's, there is 20% probability of 0 being selected
			probabilitySelection = ProbabilityArray20 [randomNumber];
			
			//updates the points parameter for the AddPoints method in the ScoreManager
			//with the AstoidSmallPoints field created in this scriptScoreManager.AddPoints (pointsToAdd)
			//or the negative counterpart, depending on the selection from the probability array
			if(probabilitySelection == 1)
			{
				ScoreManager.AddPoints (AstroidLargePoints);
				PickListMgr.pickupList.Add(PickUpMgr.PlayerID, System.DateTime.Now, ScoreManager.score, AstroidLargeRisk);
				Instantiate (PointEffect, transform.position, transform.rotation);
				Destroy (coll.gameObject);
				Instantiate (Points100PosObject, transform.position, transform.rotation);
				SpawnRandom(bagSize); 
			}
			
			//updates the points parameter for the AddPoints method in the ScoreManager 
			//with the negative value of the AstoidLargePoints field less 10%
			if(probabilitySelection == 0)
			{
				ScoreManager.AddPoints (AstroidLargePointsNeg);
				PickListMgr.pickupList.Add(PickUpMgr.PlayerID, System.DateTime.Now, ScoreManager.score, AstroidLargeRisk);
				Instantiate (PointEffect, transform.position, transform.rotation);
				Destroy (coll.gameObject);
				Instantiate (Points10NegObject, transform.position, transform.rotation);
				SpawnRandom(bagSize);
			}

			
		}
		
		if (coll.tag == "AstroidSmall") 
		{
			
			//sets bagSize variable for large bag for call to the SpawnRandom method
			bagSize = 1;

			//selects at random an index to select from the probability array
			//random.range(min(inclusive), max(exclusive))
			randomNumber = Random.Range (0, 2);
			
			//assigns value at ProbabilityArray20 index to public GameObject[] BalloonArray;probabilitySelection variable
			//for an array of size 5 containing 4 1's, there is 20% probability of 0 being selected
			probabilitySelection = ProbabilityArray50 [randomNumber];
			
			//updates the points parameter for the AddPoints method in the ScoreManager
			//with the BagOfDoughSmallPoints field created in this scriptScoreManager.AddPoints (pointsToAdd)
			//or the negative counterpart, depending on the selection from the probability array
			if(probabilitySelection == 1)
			{
				ScoreManager.AddPoints (AstroidSmallPoints);
				PickListMgr.pickupList.Add(PickUpMgr.PlayerID, System.DateTime.Now, ScoreManager.score, AstroidSmallRisk);
				Instantiate (PointEffect, transform.position, transform.rotation);
				Destroy (coll.gameObject);
				Instantiate (Points1000PosObject, transform.position, transform.rotation);
				SpawnRandom(bagSize);
			}
			
			//updates the points parameter for the AddPoints method in the ScoreManager 
			//with the negative value of the BagOfDoughLargePoints field less 10%
			if(probabilitySelection == 0)
			{
				ScoreManager.AddPoints (AstroidSmallPointsNeg);
				PickListMgr.pickupList.Add(PickUpMgr.PlayerID, System.DateTime.Now, ScoreManager.score, AstroidSmallRisk);
				Instantiate (PointEffect, transform.position, transform.rotation);
				Destroy (coll.gameObject);
				Instantiate (Points125NegObject, transform.position, transform.rotation);
				SpawnRandom(bagSize);
			}
			
		}  
		else
			return;
	}

	void SpawnRandom(int BagSizeVar)
	{

		if (BagSizeVar == 0) {
			//randomly selects index id for BagOfDoughPositionArray
			randomPosition = Random.Range (0, 5); 
			//Checks that random.position is not at the current player position
			//if true selects new randomPosition
			while (RandomBagPositionArray[randomPosition].transform.position == transform.position) {
				randomPosition = Random.Range (0, 5);
			}
			
			//instantiates a new BagOfDough game object for the scene
			GameObject Astroid = Instantiate (AstroidLarge) as GameObject; 
			
			//randomly assigns a location for the new BagOfDough depending on the randomly selected
			//RandomBagPositions represented by empty game objects in the RandomBagPositionArray fields
			Astroid.transform.position = RandomBagPositionArray [randomPosition].transform.position; 
			
		}

		if (BagSizeVar == 1) {
			//randomly selects index id for BagOfDoughPositionArray
			randomPosition = Random.Range (5, 8); 
			
			//Checks that random.position is not at the current player position
			//if true selects new randomPosition
			while (RandomBagPositionArray[randomPosition].transform.position == transform.position) {
				randomPosition = Random.Range (5, 8);
			}
			
			//instantiates a new BagOfDough game object for the scene
			GameObject Astroid = Instantiate (AstroidSmall) as GameObject; 
			
			//randomly assigns a location for the new BagOfDough depending on the randomly selected
			//RandomBagPositions represented by empty game objects in the RandomBagPositionArray fields
			Astroid.transform.position = RandomBagPositionArray [randomPosition].transform.position; 
			
		}
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}
