using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;




public class testPHP : MonoBehaviour {

    private string insertURL = "http://localhost:10080/DB_test/Insert.php";

    // Use this for initialization
    void Start ()
    {
       
            StartCoroutine(InsertData());
	}

    IEnumerator InsertData()
    {

        foreach (PickUpClass pickUp in PickListMgr.pickupList)
        {
            WWWForm form = new WWWForm();

            form.AddField("UnityID", pickUp.PlayerID.ToString("yyyyMMddHmmss"));
            form.AddField("UnityCollectionTime", pickUp.DateTime.ToString("H:mm:ss"));
            form.AddField("UnityScore", pickUp.Score);
            form.AddField("UnityRiskLevel", pickUp.PickUpRiskLevel);

            WWW webRequest = new WWW(insertURL, form);
            yield return webRequest;

            if (webRequest.error != null)
            {
                Debug.Log("there was an error posting data" + webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.text);
            }
        }
    }
}
