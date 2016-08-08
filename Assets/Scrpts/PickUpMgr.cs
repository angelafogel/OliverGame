using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUpMgr: MonoBehaviour {

    public static System.DateTime PlayerID;

    

    public Text text;


    void Start()
    {
        text = GetComponent<Text>();
        PlayerID = System.DateTime.Now;

    }

    void Update()
    {
        //updates average risk text on the screen
        text.text = "" + PickListMgr.pickupList.PickUpAverage();
    }
}
