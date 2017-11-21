using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardController : MonoBehaviour {

    public GameObject wins1;
    public GameObject wins2;
    public GameObject wins3;
    public Image rocket;
    public Image shotgun;
    public Image shield;
    private variableTracker varTrack;
    public CharacterController2D characterController;
    public Material glow;
    public Material unlit;
    public Text ammoCount;

    // Use this for initialization
    void Start () {
        varTrack = GameObject.Find("variableTracker").GetComponent<variableTracker>();
        //characterController = GameObject.Find("Player 1").GetComponent<CharacterController2D>();
        wins1.GetComponent<Renderer>().material = unlit;
        wins2.GetComponent<Renderer>().material = unlit;
        wins3.GetComponent<Renderer>().material = unlit;
        rocket.enabled = false;
        shotgun.enabled = false;
        shield.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.name == "CharacterCard1")
        {
            if (varTrack.P1wins == 1)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = unlit;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P1wins == 2)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P1wins == 3)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = glow;
            }

            if (varTrack.P1wins == 0)
            {
                if (wins1.GetComponent<Renderer>().material = glow)
                {
                    wins1.GetComponent<Renderer>().material = unlit;
                }

                if (wins2.GetComponent<Renderer>().material = glow)
                {
                    wins2.GetComponent<Renderer>().material = unlit;
                }

                if (wins3.GetComponent<Renderer>().material = glow)
                {
                    wins3.GetComponent<Renderer>().material = unlit;
                }
            }
        }

        if (this.name == "CharacterCard2")
        {
            if (varTrack.P2wins == 1)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = unlit;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P2wins == 2)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P2wins == 3)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = glow;
            }

            if (varTrack.P2wins == 0)
            {
                if (wins1.GetComponent<Renderer>().material = glow)
                {
                    wins1.GetComponent<Renderer>().material = unlit;
                }

                if (wins2.GetComponent<Renderer>().material = glow)
                {
                    wins2.GetComponent<Renderer>().material = unlit;
                }

                if (wins3.GetComponent<Renderer>().material = glow)
                {
                    wins3.GetComponent<Renderer>().material = unlit;
                }
            }
        }

        if (this.name == "CharacterCard3")
        {
            if (varTrack.P3wins == 1)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = unlit;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P3wins == 2)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P3wins == 3)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = glow;
            }

            if (varTrack.P3wins == 0)
            {
                if (wins1.GetComponent<Renderer>().material = glow)
                {
                    wins1.GetComponent<Renderer>().material = unlit;
                }

                if (wins2.GetComponent<Renderer>().material = glow)
                {
                    wins2.GetComponent<Renderer>().material = unlit;
                }

                if (wins3.GetComponent<Renderer>().material = glow)
                {
                    wins3.GetComponent<Renderer>().material = unlit;
                }
            }
        }

        if (this.name == "CharacterCard4")
        {
            if (varTrack.P4wins == 1)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = unlit;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P4wins == 2)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = unlit;
            }

            if (varTrack.P4wins == 3)
            {
                wins1.GetComponent<Renderer>().material = glow;
                wins2.GetComponent<Renderer>().material = glow;
                wins3.GetComponent<Renderer>().material = glow;
            }

            if (varTrack.P4wins == 0)
            {
                if (wins1.GetComponent<Renderer>().material = glow)
                {
                    wins1.GetComponent<Renderer>().material = unlit;
                }

                if (wins2.GetComponent<Renderer>().material = glow)
                {
                    wins2.GetComponent<Renderer>().material = unlit;
                }

                if (wins3.GetComponent<Renderer>().material = glow)
                {
                    wins3.GetComponent<Renderer>().material = unlit;
                }
            }
        }

        if (characterController.shield == true && shield.enabled == false)
        {
            shield.enabled = true;
        }

        if (characterController.shotType == "Shotgun" && shotgun.enabled == false)
        {
            shotgun.enabled = true;
        }

        if (characterController.shotType == "Rocket" && rocket.enabled == false)
        {
            rocket.enabled = true;
        }

        ammoCount.text = characterController.ammo.ToString();

        if (characterController.ammo == 0)
        {
            if (rocket.enabled == true)
            {
                rocket.enabled = false;
            }

            if (shotgun.enabled == true)
            {
                shotgun.enabled = false;
            }
        }

        if (characterController.shield == false)
        {
            if (shield.enabled == true)
            {
                shield.enabled = false;
            }
        }
    }
}
