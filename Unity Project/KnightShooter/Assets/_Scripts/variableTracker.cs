using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class variableTracker : MonoBehaviour
{
    public List<GameObject> players;
    public List<GameObject> cards;
    public List<Text> textList;
    public string winText;
    public int P1wins;
    public int P2wins;
    public int P3wins;
    public int P4wins;
    public bool pointsDelivered;
    public bool P1enabled;
    public bool P2enabled;
    public bool P3enabled;
    public bool P4enabled;

    // Use this for initialization
    void Start ()
    {
        P1enabled = false;
        P2enabled = false;
        P3enabled = false;
        P4enabled = false;
        DontDestroyOnLoad(this);
        pointsDelivered = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
            cards = new List<GameObject>(GameObject.FindGameObjectsWithTag("Card"));

            if (P1enabled)
            {
                print("Enabled");
                players[0].SetActive(true);
                cards[0].SetActive(true);
            }
			for (int i = 0; i < players.Count; i++) {
				if (!P2enabled && players [i].name == "Player 2") {
					Destroy (players [i]);
				}

				if (!P3enabled && players [i].name == "Player 3") {
					Destroy (players [i]);
				}

				if (!P4enabled && players [i].name == "Player 4") {
					Destroy (players [i]);
				}
			}

			if (players.Count == 0) {
				winText = "Draw!! Press Start to continue";
				LevelEnd ();
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
	}

    public void LevelEnd()
    {
        //use button 7 for pc
        //use button 9 for mac
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button9))
        {
            if (P1wins == 3 || P2wins == 3 || P3wins == 3 || P4wins == 3)
            {
                pointsDelivered = false;
                P1wins = 0;
                P2wins = 0;
                P3wins = 0;
                P4wins = 0;
                SceneManager.LoadScene(0);
                print("Loaded");
            }

            else
            {
                pointsDelivered = false;
                SceneManager.LoadScene(3);
            }
        }
    }
}
