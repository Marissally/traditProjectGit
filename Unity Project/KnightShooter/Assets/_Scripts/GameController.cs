using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public List<GameObject> players;
    public List<Text> textList;
    public string winText;
    private int P1wins;
    private int P2wins;
    public bool pointsDelivered;

    // Use this for initialization
    void Start () {
        GameObject canvas = GameObject.Find("Canvas");
        DontDestroyOnLoad(canvas);
        Text[] textList = canvas.GetComponentsInChildren<Text>();
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        pointsDelivered = false;
        textList[2].enabled = false;
    }
	
	// Update is called once per frame
    void OnGUI ()
    {
        textList[0].text = P1wins.ToString();
        textList[1].text = P2wins.ToString();
        textList[2].text = winText;
    }

    // Update is called once per frame
    void Update () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (players.Count == 0)
        {
            winText = "Draw!! Press Start to continue";
            textList[2].enabled = true;
            LevelEnd();
        }
        if (players.Count == 1)
        {
            if (players[0].name == "Player 1")
            {
                winText = "Player 1 Wins!! Press Start to continue";
                textList[2].enabled = true;
                if (!pointsDelivered)
                { P1wins += 1; pointsDelivered = true; }
                LevelEnd();
            }
            if (players[0].name == "Player 2")
            {
                winText = "Player 2 Wins!! Press Start to continue";
                textList[2].enabled = true;
                if (!pointsDelivered)
                { P2wins += 1; pointsDelivered = true; }
                LevelEnd();
            }
        }
	}

    public void LevelEnd()
    {
        //use button 7 for pc
        //use button 9 for mac
        if (Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Joystick2Button9))
        {
            SceneManager.LoadScene(0);
            textList[2].enabled = false;
        }
    }
}
