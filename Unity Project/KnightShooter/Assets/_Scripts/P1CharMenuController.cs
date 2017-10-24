using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P1CharMenuController : MonoBehaviour {

    private GameObject startButton;
	public bool readied;
	public Image readyImage;
	public GameObject Player;
	private LoadScene SceneLoader;
	private P2CharMenuController P2View;
	private P3CharMenuController P3View;
	private P4CharMenuController P4View;

	// Use this for initialization
	void Start ()
    {
		readied = false;
		//readyImage = GameObject.Find ("readyImage").GetComponent<Image>();
		P2View = GameObject.Find ("P2View").GetComponent<P2CharMenuController>();
		P3View = GameObject.Find ("P3View").GetComponent<P3CharMenuController>();
		P4View = GameObject.Find ("P4View").GetComponent<P4CharMenuController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Joystick1Button16))
        {
			readyImage.color = new Color32 (200, 200, 200, 100);
        }

		if (Input.GetKeyUp (KeyCode.Joystick1Button16)) 
		{
			readied = true;
			readyImage.color = new Color32 (220, 220, 220, 100);
			Player.SetActive(true);
		}

		//if all readied
		if (readied && P2View.readied && P3View.readied && P4View.readied)
		{
			//load random level scene
			int p = UnityEngine.Random.Range(2, 4);
			SceneLoader.LoadByIndex (p);
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button1) && readied == true) 
		{
			readyImage.color = new Color32 (255, 255, 255, 100);
			readied = false;
			Player.SetActive(false);
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) 
		{
			SceneLoader.LoadByIndex (0);
		}
	}
}
