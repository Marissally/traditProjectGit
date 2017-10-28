using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {

    public CharMenuController P1View;
    public CharMenuController P2View;
    public CharMenuController P3View;
    public CharMenuController P4View;
    public variableTracker varTrack;

	// Use this for initialization
	void Start ()
    {
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (P1View.readied == true)
        {
            print("readied");
            varTrack.P1enabled = true;
            print("enabled");
        }

        if (P2View.readied == true)
        {
            varTrack.P2enabled = true;
        }

        if (P3View.readied == true)
        {
            varTrack.P3enabled = true;
        }

        if (P4View.readied == true)
        {
            varTrack.P4enabled = true;
        }
    }
}
