using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatScript : MonoBehaviour {

	public Vector3 origin;
	public float amp;

	// Use this for initialization
	void Start () {
		origin = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		print (Mathf.Sin (Time.time));
		this.transform.position = new Vector3(origin.x, origin.y + .25f + (Mathf.Sin (Time.time) * amp), origin.z);
    }
}
