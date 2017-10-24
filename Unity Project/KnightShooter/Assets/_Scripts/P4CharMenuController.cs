using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P4CharMenuController : MonoBehaviour {

	private GameObject startButton;
	public bool readied;
	public Image readyImage;
	public GameObject Player;
	private LoadScene SceneLoader;

	// Use this for initialization
	void Start ()
    {
		readied = false;
		//readyImage = GameObject.Find ("readyImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Joystick4Button0))
        {
			readyImage.color = new Color32 (200, 200, 200, 100);
        }

		if (Input.GetKeyUp (KeyCode.Joystick4Button0)) 
		{
			readied = true;
			readyImage.color = new Color32 (220, 220, 220, 100);
			Player.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.Joystick4Button1) && readied == true) 
		{
			readied = false;
			readyImage.color = new Color32 (255, 255, 255, 100);
			Player.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Joystick4Button1)) 
		{
			SceneLoader.LoadByIndex (0);
		}
	}
}
