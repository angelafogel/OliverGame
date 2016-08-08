using UnityEngine;
using System.Collections;

public class SpawnNeg : MonoBehaviour {

	private Vector3 start;
	public float speed = 3f; 
	public float distance = 4f;
	public GameObject[] BalloonArray;
	private float rePosition = 0;
	public float spawnCountDown = 0f;
	public float spawnStartTime = 0f;
	public float spawnDelay = 3f;

	// Use this for initialization
	void Start () 
	{
		//the start position equals the position of the object the script is attached to
		start = transform.position; 

	}

	void SpawnObjects ()
	{
		//randomizes the selection of objects in BalloonArray
		int randomBalloon = Random.Range (0, 2); 
	
		//creates another instance of our balloon object from the array
		GameObject balloons = Instantiate (BalloonArray [randomBalloon]) as GameObject; 
	
		// locates the new ballon wherever our spawner object is located
		balloons.transform.position = transform.position; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		rePosition = Mathf.PingPong (Time.time * speed, distance) - (distance / 2f);

		//transform.position = new Vector3 (rePosition, start.y, start.z); //start position is wherever the spawner object is in the scene
		transform.position = new Vector3(rePosition, start.y, start.z);

		spawnCountDown = Time.time - spawnStartTime;

		if (spawnCountDown >= spawnDelay) 
		{
			spawnStartTime = Time.time;
			spawnCountDown = 0;
			SpawnObjects ();
		}
	}
}
