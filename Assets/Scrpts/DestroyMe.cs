using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour 
{

	public void SelfDestruct()
	{
		Destroy (gameObject);
	}
}
