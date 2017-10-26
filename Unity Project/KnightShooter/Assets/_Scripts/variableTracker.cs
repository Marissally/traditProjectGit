using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class variableTracker : MonoBehaviour {

    public List<GameObject> players;
    public List<Text> textList;
    public string winText;
    public int P1wins;
    public int P2wins;
    public int P3wins;
    public int P4wins;
    public bool pointsDelivered;

    // Use this for initialization
    void Start () {
        GameObject keptVariables = GameObject.Find("KeptVariables");
        DontDestroyOnLoad(keptVariables);
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        pointsDelivered = false;
    }

    // Update is called once per frame
    void Update () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (players.Count == 0)
        {
            winText = "Draw!! Press Start to continue";
            LevelEnd();
        }
        if (players.Count == 1)
        {
            if (players[0].name == "Player 1")
            {
                winText = "Player 1 Wins!! Press Start to continue";
                if (!pointsDelivered)
                {
                    P1wins += 1;
                    pointsDelivered = true;
                }
                LevelEnd();
            }
            if (players[0].name == "Player 2")
            {
                winText = "Player 2 Wins!! Press Start to continue";
                if (!pointsDelivered)
                {
                    P2wins += 1;
                    pointsDelivered = true;
                }
                LevelEnd();
            }
            if (players[0].name == "Player 3")
            {
                winText = "Player 3 Wins!! Press Start to continue";
                if (!pointsDelivered)
                {
                    P3wins += 1;
                    pointsDelivered = true;
                }
                LevelEnd();
            }
            if (players[0].name == "Player 4")
            {
                winText = "Player 4 Wins!! Press Start to continue";
                if (!pointsDelivered)
                {
                    P4wins += 1;
                    pointsDelivered = true;
                }
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
            if (P1wins == 3 || P2wins == 3 || P3wins == 3 || P4wins == 3)
            {
                pointsDelivered = false;
                P1wins = 0;
                P2wins = 0;
                P3wins = 0;
                P4wins = 0;
                SceneManager.LoadScene(0);
            }

            else
            {
                pointsDelivered = false;
                SceneManager.LoadScene(2);
            }
        }
    }
}
