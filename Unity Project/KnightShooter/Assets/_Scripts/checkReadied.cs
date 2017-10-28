using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class checkReadied : MonoBehaviour {

    public CharMenuController P1View;
    public CharMenuController P2View;
    public CharMenuController P3View;
    public CharMenuController P4View;
    public Image startNotifier;

    // Use this for initialization
    void Start () {
        startNotifier.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if (P1View.readied && P2View.readied && P3View.readied && P4View.readied)
        if (P1View.readied || P2View.readied || P3View.readied || P4View.readied)
        {
            startNotifier.enabled = true;
        }

        if ((P1View.readied = false) && (P2View.readied = false) && (P3View.readied = false) && (P4View.readied = false))
        {
            startNotifier.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton7) && startNotifier.enabled)
        {
            //load random level scene
            //int p = UnityEngine.Random.Range(2, 4);
            SceneManager.LoadScene(3);
        }
    }
}
