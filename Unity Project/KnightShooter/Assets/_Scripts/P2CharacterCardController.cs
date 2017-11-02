using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2CharacterCardController : MonoBehaviour
{
    public Image wins1;
    public Image wins2;
    public Image wins3;
    public Image rocket;
    public Image shotgun;
    public Image shield;
    private variableTracker varTrack;
    public CharacterController2D characterController;

    // Use this for initialization
    void Start()
    {
        varTrack = GameObject.Find("KeptVariables").GetComponent<variableTracker>();
        //characterController = GameObject.Find("Player 1").GetComponent<CharacterController2D>();
        wins1.enabled = false;
        wins2.enabled = false;
        wins3.enabled = false;
        rocket.enabled = false;
        shotgun.enabled = false;
        shield.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (varTrack.P2wins == 1)
        {
            wins1.enabled = true;
        }

        if (varTrack.P2wins == 2)
        {
            wins1.enabled = true;
            wins2.enabled = true;
        }

        if (varTrack.P2wins == 3)
        {
            wins1.enabled = true;
            wins2.enabled = true;
            wins3.enabled = true;
        }

        if (varTrack.P2wins == 0)
        {
            if (wins1.enabled == true)
            {
                wins1.enabled = false;
            }

            if (wins2.enabled == true)
            {
                wins2.enabled = false;
            }

            if (wins3.enabled == true)
            {
                wins3.enabled = false;
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
