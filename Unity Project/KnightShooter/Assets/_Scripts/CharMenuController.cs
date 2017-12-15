using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharMenuController : MonoBehaviour {

    private GameObject startButton;
	public bool readied;
	public Image readiedImage;
    public Text readyText;
	public SpriteRenderer Player;
	public SpriteRenderer face;
    public KeyCode confirm;
    public KeyCode cancel;

	// Use this for initialization
	void Start ()
    {
		face.enabled = false;
        readiedImage.enabled = false;
		readied = false;
        Player.enabled = false;

        //readyImage = GameObject.Find ("readyImage").GetComponent<Image>();
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (this.name == "P1View")
            {
                confirm = KeyCode.Joystick1Button0;
                cancel = KeyCode.Joystick1Button1;
            }

            if (this.name == "P2View")
            {
                confirm = KeyCode.Joystick2Button0;
                cancel = KeyCode.Joystick2Button1;
            }

            if (this.name == "P3View")
            {
                confirm = KeyCode.Joystick3Button0;
                cancel = KeyCode.Joystick3Button1;
            }

            if (this.name == "P4View")
            {
                confirm = KeyCode.Joystick4Button0;
                cancel = KeyCode.Joystick4Button1;
            }
        }

        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
        {
            if (this.name == "P1View")
            {
                confirm = KeyCode.Joystick1Button16;
                cancel = KeyCode.Joystick1Button17;
            }

            if (this.name == "P2View")
            {
                confirm = KeyCode.Joystick2Button16;
                cancel = KeyCode.Joystick2Button17;
            }

            if (this.name == "P3View")
            {
                confirm = KeyCode.Joystick3Button16;
                cancel = KeyCode.Joystick3Button17;
            }

            if (this.name == "P4View")
            {
                confirm = KeyCode.Joystick4Button16;
                cancel = KeyCode.Joystick4Button17;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(confirm))
        {
			readyText.color = new Color32 (200, 200, 200, 100);
        }

		if (Input.GetKeyUp (confirm)) 
		{
			Player.enabled = true;
			readied = true;
            readyText.color = new Color32 (220, 220, 220, 100);
			face.enabled = true;
            readiedImage.enabled = true;
            readyText.enabled = false;
		}

		if (Input.GetKeyDown (cancel)) 
		{
            readyText.color = new Color32(210, 210, 210, 100);
            readiedImage.color = new Color32(210, 210, 210, 100);
        }

        if (Input.GetKeyUp (cancel))
        {
            readyText.color = new Color32(255, 255, 255, 100);
            readiedImage.color = new Color32(255, 255, 255, 100);

            if (readied == true)
            {
                readied = false;
                Player.enabled = false;
                readiedImage.enabled = false;
                readyText.enabled = true;
            }

            else
            {
                Destroy(GameObject.FindObjectOfType<variableTracker>().gameObject);
                SceneManager.LoadScene(0);
            }
        }
	}
}
