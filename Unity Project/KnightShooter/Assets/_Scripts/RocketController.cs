using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	public GameObject explo;
	public Animator _anim;

	Collider2D[] explodeRadius;
    public CharacterController2D spawnOrigin;

	// Use this for initialization
	void Start () {
		explodeRadius = new Collider2D[20];
		_anim = explo.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
		if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "DestructiblePlat") || (collision.gameObject.tag == "IndestructiblePlat") || (collision.gameObject.tag == "DamagablePlat"))
        {
			if (collision.gameObject.tag == "Player")
            {
               	CharacterController2D player = collision.gameObject.GetComponent<CharacterController2D>();
				if (player == spawnOrigin) {
					return;
				}
            } 
			Destroy (gameObject);
			GameObject explosion = Instantiate (explo, transform.position, transform.rotation);
			//_anim.SetBool (pop, true);
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
