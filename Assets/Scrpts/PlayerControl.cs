using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	Animator anim;
	float speed = 2f;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	

	// Update is called once per frame
	void Update () 
	{
		Movement ();
	}

	void Movement () 
	{

		anim.SetFloat ("StateSpeed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if(Input.GetAxisRaw ("Horizontal") > 0) //Horizontal looks for a,d or left right arrows
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0); //flip to face the correct direction
		}

		if(Input.GetAxisRaw ("Horizontal") < 0) //Horizontal looks for a,d or left right arrows
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180); //flip to face the correct direction

		}

		if(Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
		{
			transform.Translate (Vector3.up * 8f * Time.deltaTime);
		}


	}
}
