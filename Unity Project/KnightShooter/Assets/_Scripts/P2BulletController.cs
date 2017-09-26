using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 2")
        {
            return;
        }
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "DestructiblePlat"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "IndestructiblePlat")
        {
            Destroy(gameObject);
        }
    }
}
