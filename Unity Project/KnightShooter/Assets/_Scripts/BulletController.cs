using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {
            return;
        }
        if (collision.gameObject.name == "Player 2")
        {
            P2CharacterConroller2D player2 = collision.gameObject.GetComponent<P2CharacterConroller2D>();
            if (player2.shield == true)
            {
                player2.shield = false;
            }
            else
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "DestructiblePlat")
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
