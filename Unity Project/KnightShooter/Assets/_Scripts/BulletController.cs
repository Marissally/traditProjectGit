using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	
	PlatformController platform;

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
			platform = collision.gameObject.GetComponent<PlatformController> ();
			if (platform.durability > 0) {
				platform.durability--;
                Destroy (gameObject);
				Color32 materialColor = platform.GetComponentInChildren<Renderer> ().material.color;
				materialColor.b = materialColor.g = materialColor.r -= 30;
				platform.GetComponentInChildren<Renderer> ().material.color = materialColor;
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

	private IEnumerator FlashWait(float s)
	{
		yield return new WaitForSeconds (s);
		//platform.GetComponentInChildren<Renderer>().material.color = normalColor;
	}
}
