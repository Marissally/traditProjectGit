using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharMenuController : MonoBehaviour {

    private GameObject startButton;
	public bool readied;
	public Image readyImage;
	public GameObject Player;
	private LoadScene SceneLoader;
    public KeyCode confirm;
    public KeyCode cancel;

	// Use this for initialization
	void Start ()
    {
		readied = false;
		//readyImage = GameObject.Find ("readyImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(confirm))
        {
			readyImage.color = new Color32 (200, 200, 200, 100);
        }

		if (Input.GetKeyUp (confirm)) 
		{
			readied = true;
			readyImage.color = new Color32 (220, 220, 220, 100);
			Player.SetActive(true);
		}

		if (Input.GetKeyDown (cancel)) 
		{
            if (readied == true)
            {
                readyImage.color = new Color32(255, 255, 255, 100);
                readied = false;
                Player.SetActive(false);
            }

            else
            {
                SceneLoader.LoadByIndex(0);
            }
		}
	}
}
