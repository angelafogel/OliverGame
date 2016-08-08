using UnityEngine;
using System.Collections;

public class DestroyGOall : MonoBehaviour {

	private int missedLittleBalloon = 0;
	private int missedBigBalloon = 0;
	public GameObject player;
	public GameObject player1;
	public GameObject spawnTransform;
	public int deathDeduction;
	public GameObject DeathEffect;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.tag == "LittleBalloon") 
		{
			Destroy (coll.gameObject);
			missedLittleBalloon = missedLittleBalloon + 1;
		} 
		if (coll.tag == "BigBalloon") 
		{
			Destroy (coll.gameObject);
			missedBigBalloon = missedBigBalloon + 1;
		} 
		if (coll.tag == "Player") 
		{
			Instantiate (DeathEffect, transform.position, transform.rotation);
			Destroy (coll.gameObject);
			GameObject spawnPlayer = Instantiate (player) as GameObject; 
			spawnPlayer.transform.position = spawnTransform.transform.position;
			ScoreManager.AddPoints (deathDeduction);

		} if (coll.tag == "Player1") 
		{
			Instantiate (DeathEffect, transform.position, transform.rotation);
			Destroy (coll.gameObject);
			GameObject spawnPlayer = Instantiate (player1) as GameObject; 
			spawnPlayer.transform.position = spawnTransform.transform.position;
			ScoreMgr2.AddPoints (deathDeduction);
			
		} 
		else
			return;
	}
}
