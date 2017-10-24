using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	Collider2D[] explodeRadius;
	// Use this for initialization
	void Start () {
		explodeRadius = new Collider2D[20];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
		if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "DestructiblePlat") || (collision.gameObject.tag == "IndestructiblePlat") || (collision.gameObject.tag == "DamagablePlat"))
        {
			if (collision.gameObject.name == "Player 1") {
				return;
			} 
			else {
				Destroy (gameObject);
			}
			Physics2D.OverlapCircle(transform.position, 1.5f, new ContactFilter2D(), explodeRadius);

			foreach (Collider2D o in explodeRadius) {
				if ((o.gameObject.tag == "Player") || (o.gameObject.tag == "DestructiblePlat") || (o.gameObject.tag == "DamagablePlat")) 
				{
					Destroy (o.gameObject);	
				}
			}
        }
    }
}
