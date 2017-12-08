using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VertMenuController : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;
    public AudioClip movementSound;
    public AudioClip confirmSound;
    public AudioClip cancelSound;
    private AudioSource audManager;
    private bool buttonSelected;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetAxisRaw("Vertical_1") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            audManager.PlayOneShot(movementSound);
            buttonSelected = true;
        }
	}

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
