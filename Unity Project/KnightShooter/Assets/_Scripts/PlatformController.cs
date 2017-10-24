using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public bool _destructible = true;
	public int durability = 3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (durability == 0) {
			Destroy (gameObject);
		}
	}
}
