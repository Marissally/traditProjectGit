using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public CharacterController2D spawnOrigin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterController2D player = collision.gameObject.GetComponent<CharacterController2D>();
            if (player != spawnOrigin)
            {
                if (player.shield == true)
                {
                    player.shield = false;
                }
                else
                {
                    Destroy(collision.gameObject);
                }
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "DamagablePlat")
        {
			PlatformController platform = collision.gameObject.GetComponent<PlatformController> ();
			if (platform.durability > 0) {
				platform.durability--;
                Destroy (gameObject);
                //print(platform.GetComponent<Renderer>().material.color);
                //platform.GetComponent<Renderer>().material.color = collideColor;
                //yield return new WaitForSeconds(.1f);
                //platform.GetComponent<Renderer>().material.color = normalColor;
                //yield return new WaitForSeconds(.1f);
            }
        }
		if (collision.gameObject.tag == "DestructiblePlat") 
		{
			Destroy (gameObject);
			Destroy (collision.gameObject);
		}
        if (collision.gameObject.tag == "IndestructiblePlat")
        {
            Destroy(gameObject);
        }
    }
}
