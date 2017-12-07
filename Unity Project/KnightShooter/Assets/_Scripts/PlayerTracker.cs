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
		varTrack = GameObject.FindObjectOfType<variableTracker> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (P1View.readied == true) {
			print ("p1 readied");
			varTrack.P1enabled = true;
			print ("p1 enabled");
		} else {
			varTrack.P1enabled = false;
		}

		if (P2View.readied == true) {
			print ("p2 readied");
			varTrack.P2enabled = true;
		} else {
			varTrack.P2enabled = false;
		}

		if (P3View.readied == true) {
			print ("p3 readied");
			varTrack.P3enabled = true;
		} else {
			varTrack.P3enabled = false;
		}

		if (P4View.readied == true) {
			print ("p4 readied");
			varTrack.P4enabled = true;
		} else {
			varTrack.P4enabled = false;
		}
    }
}
