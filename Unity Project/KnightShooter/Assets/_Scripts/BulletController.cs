using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	
	PlatformController platform;

    public CharacterController2D spawnOrigin;
    private AudioSource audManager;
    public AudioClip destroySound;
    public AudioClip deathSound;
    public AudioClip collideSound;

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
                audManager.PlayOneShot(deathSound);
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
            audManager.PlayOneShot(destroySound);
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
            audManager.PlayOneShot(destroySound);
            Destroy (gameObject);
			Destroy (collision.gameObject);
		}
        if (collision.gameObject.tag == "IndestructiblePlat")
        {
            audManager.PlayOneShot(collideSound);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Projectile")
        {
            audManager.PlayOneShot(collideSound);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

	private IEnumerator FlashWait(float s)
	{
		yield return new WaitForSeconds (s);
		//platform.GetComponentInChildren<Renderer>().material.color = normalColor;
	}
}
