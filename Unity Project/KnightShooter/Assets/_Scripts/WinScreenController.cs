using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour {

    public List<GameObject> border;
	public Material borderM;
    public Material P1glow;
    public Material P2glow;
    public Material P3glow;
    public Material P4glow;
    private variableTracker varTracker;
	private bool transformed;

    // Use this for initialization
    void Start () {
		varTracker = GameObject.Find("variableTracker").GetComponent<variableTracker>();
        border = new List<GameObject>(GameObject.FindGameObjectsWithTag("IndestructiblePlat"));
    }
	
	// Update is called once per frame
	void Update () {
		if (varTracker.pointsDelivered && !varTracker.winDone) 
		{
            if (varTracker.winText == "Player 1 Wins!! Press Start to continue")
            {
                border.GetComponent<Renderer>().material = P1glow;
            }

            if (varTracker.winText == "Player 2 Wins!! Press Start to continue")
            {
                border.GetComponent<Renderer>().material = P2glow;
            }

            if (varTracker.winText == "Player 3 Wins!! Press Start to continue")
            {
                border.GetComponent<Renderer>().material = P3glow;
            }

            if (varTracker.winText == "Player 4 Wins!! Press Start to continue")
            {
                border.GetComponent<Renderer>().material = P4glow;
            }

            print("changed");
			varTracker.winDone = true;
			}
		}
	}
}
