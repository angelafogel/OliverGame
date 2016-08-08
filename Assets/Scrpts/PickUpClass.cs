using UnityEngine;
using System.Collections.Generic;

public class PickUpClass {

    public System.DateTime PlayerID;
    public System.DateTime DateTime;
    public int Score;
    public int PickUpRiskLevel;


    public PickUpClass()
    {
    }

	public PickUpClass(System.DateTime playerID, System.DateTime dateTime, int score, int pickUpRiskLevel)
    {
        this.PlayerID = playerID;
        this.DateTime = dateTime;
        this.Score = score;
        this.PickUpRiskLevel = pickUpRiskLevel;
    }
	
}
