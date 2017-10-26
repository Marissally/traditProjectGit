using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    private variableTracker varTrack;
    public Text winMessage;
    public Text P1Wins;
    public Text P2Wins;


	// Use this for initialization
	void Start () {
        varTrack = GameObject.Find("KeptVariables").GetComponent<variableTracker>();
        winMessage.enabled = false;
	}

    void OnGUI ()
    {
        winMessage.text = varTrack.winText;
        P1Wins.text = varTrack.P1wins.ToString();
        P2Wins.text = varTrack.P2wins.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if(varTrack.pointsDelivered)
        {
            winMessage.enabled = true;
        }

        if(varTrack.pointsDelivered == false)
        {
            winMessage.enabled = false;
        }
	}
}
