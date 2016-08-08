using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MENUButton : MonoBehaviour {

	public Slider volumeControl;

	//will use as target as volume button click
	//slider variable, volumeControl reference added to the empty GameObject volumeButtonResponder from the inspector
	//GameObject, volumeButtonResponder then added to ButtonScript from the inspector to link this on click script
	public void GetSliderVolume()

	{
		Debug.Log (volumeControl.value.ToString ());
	}
	//provides slider as a parameter
	//this allows Slider variable volumeControl to be added to Button script as a parameter instead of
	//statically adding to the volumeButtonResponder, provide it as parameter instead
	public void GetSliderVolume2(Slider volumeControl)
	{
		Debug.Log (volumeControl.value.ToString ());
	}



}
