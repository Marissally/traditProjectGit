using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public List<GameObject> players;

    public Text winText;
    // Use this for initialization
    void Start () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (players.Count == 0)
        {
            winText.text = "Draw!! Press A to continue";
            LevelEnd();
        }
        if (players.Count == 1)
        {
            if (players[0].name == "Player 1")
            {
                winText.text = "Player 1 Wins!! Press A to continue";
                LevelEnd();
            }
            if (players[0].name == "Player 2")
            {
                winText.text = "Player 2 Wins!! Press A to continue";
                LevelEnd();
            }
        }
	}

    public void LevelEnd()
    {
        //use button 7 for pc
        //use button 9 for mac
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            SceneManager.LoadScene(0);
        }
    }
}
