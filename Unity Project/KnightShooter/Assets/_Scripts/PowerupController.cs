using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PowerupController : MonoBehaviour {
	//0 is none
	//1 is shotgun
	//2 is rocket
	//3 is shield
	public int currentPower = 0;
	public int timer = 30;
	public int baseTime;
	public List<int> powerups= new List<int>(4);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int Countdown () {
		
	}
}
