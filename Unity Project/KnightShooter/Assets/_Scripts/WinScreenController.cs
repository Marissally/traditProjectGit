using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenController : MonoBehaviour {


	public Image wins1;
	public Image wins2;
	public Image wins3;
	public Image charBody;
	public Image charFace;
	public Image border;
	public CharacterCardController card;
	private variableTracker varTracker;
	private bool transformed;

	// Use this for initialization
	void Start () {
		varTracker = GameObject.Find("variableTracker").GetComponent<variableTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		if (varTracker.pointsDelivered && !varTracker.winDone) 
		{
			//this.transform.position = new Vector3 (230);
			transformed = true;
			if (transformed) 
			{
				if (card.wins1.enabled) 
				{
					wins1.enabled = true;
				}
				if (card.wins2.enabled) 
				{
					wins2.enabled = true;
				}
				if (card.wins3.enabled) 
				{
					wins3.enabled = true;
				}
				varTracker.winDone = true;
			}
		}
	}
}
