using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Info1Scene : MonoBehaviour {


		public void Info1ExitButtonPress()
		{
			Application.LoadLevel (1);
			
		}

	public void Info2ExitButtonPress()
	{
		Application.LoadLevel (3);
		
	}
}