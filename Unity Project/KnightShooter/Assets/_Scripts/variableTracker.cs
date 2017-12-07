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
    private List<GameObject> projectiles;
    public string winText;
    public int P1wins;
    public int P2wins;
    public int P3wins;
    public int P4wins;
	public int p;
    public bool pointsDelivered;
    public bool P1enabled;
    public bool P2enabled;
    public bool P3enabled;
    public bool P4enabled;
	public bool winDone;
	public bool P1winning;
	public bool P2winning;
	public bool P3winning;
	public bool P4winning;
	public KeyCode startButton;


    // Use this for initialization
    void Start ()
    {
        P1enabled = false;
        P2enabled = false;
        P3enabled = false;
        P4enabled = false;
		P1winning = false;
		P2winning = false;
		P3winning = false;
		P4winning = false;
        DontDestroyOnLoad(this);
        pointsDelivered = false;
		winDone = false;
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) 
		{
			startButton = KeyCode.JoystickButton7;
		}
		if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) 
		{
			startButton = KeyCode.JoystickButton9;
		}
		p = checkReadied.GetP();
    }

    // Update is called once per frame
    void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex == p)
        {
            players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
            cards = new List<GameObject>(GameObject.FindGameObjectsWithTag("Card"));

			if (players.Count == 0) {
				winText = "Draw!! Press Start to continue";
				if (!pointsDelivered) {
					pointsDelivered = true;
				}
				if (winDone) 
				{
					LevelEnd();
				}
			}

            else if (P1enabled)
            {
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
				
			if (P1wins > P2wins && P1wins > P3wins && P1wins > P4wins) 
			{
				P1winning = true;
				P2winning = false;
				P3winning = false;
				P4winning = false;
			} 

			else if (P2wins > P1wins && P2wins > P3wins && P2wins > P4wins) 
			{
				P1winning = false;
				P2winning = true;
				P3winning = false;
				P4winning = false;
			} 

			else if (P3wins > P1wins && P3wins > P2wins && P3wins > P4wins) 
			{
				P1winning = false;
				P2winning = false;
				P3winning = true;
				P4winning = false;
			} 

			else if (P4wins > P1wins && P4wins > P2wins && P4wins > P3wins) 
			{
				P1winning = false;
				P2winning = false;
				P3winning = false;
				P4winning = true;
			}

            if (players.Count == 1)
            {
                projectiles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Projectile"));
                for (int i = 0; i < projectiles.Count; i++)
                {
                    Destroy(projectiles[i]);
                }
                if (players[0].name == "Player 1")
                {
                    winText = "Player 1 Wins!! Press Start to continue";
                    if (!pointsDelivered)
                    {
                        P1wins += 1;
                        pointsDelivered = true;
                    }
					if (winDone) 
					{
						LevelEnd();
					}
                }
                if (players[0].name == "Player 2")
                {
                    winText = "Player 2 Wins!! Press Start to continue";
                    if (!pointsDelivered)
                    {
                        P2wins += 1;
                        pointsDelivered = true;
                    }
					if (winDone) 
					{
						LevelEnd();
					}
                }
                if (players[0].name == "Player 3")
                {
                    winText = "Player 3 Wins!! Press Start to continue";
                    if (!pointsDelivered)
                    {
                        P3wins += 1;
                        pointsDelivered = true;
                    }
					if (winDone) 
					{
						LevelEnd();
					}
                }
                if (players[0].name == "Player 4")
                {
                    winText = "Player 4 Wins!! Press Start to continue";
                    if (!pointsDelivered)
                    {
                        P4wins += 1;
                        pointsDelivered = true;
                    }
					if (winDone) 
					{
						LevelEnd();
					}
                }
            }
        }
	}

    public void LevelEnd()
    {
        //use button 7 for pc
        //use button 9 for mac
		if (Input.GetKeyDown(startButton))
        {
            if (P1wins == 3 || P2wins == 3 || P3wins == 3 || P4wins == 3)
            {
                pointsDelivered = false;
                P1wins = 0;
                P2wins = 0;
                P3wins = 0;
                P4wins = 0;
				Destroy (gameObject);
                SceneManager.LoadScene(0);
                print("Loaded");
            }

            else
            {
				p = UnityEngine.Random.Range(2, 4);
                pointsDelivered = false;
				SceneManager.LoadScene(p);
            }
        }
    }
}
