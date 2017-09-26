using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public List<GameObject> players;
    public string winText;
    private int P1wins;
    private int P2wins;
    public bool showText = false;
    private GUIStyle winStyle = new GUIStyle();
    public bool pointsDelivered;

    // Use this for initialization
    void Start () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        showText = false;
        pointsDelivered = false;
        
    }
	
	// Update is called once per frame
    void OnGUI ()
    {
        winStyle.fontSize = 50;
        GUI.Box(new Rect(10, 10, 100, 100), (P1wins.ToString()),winStyle);
        GUI.Box(new Rect(1875, 10, 100, 100), (P2wins.ToString()),winStyle);
        if (showText)
        {
            GUI.TextField(new Rect(460, 300, 1000, 100), winText);
        }
    }
	void Update () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (players.Count == 0)
        {
            winText = "Draw!! Press A to continue";
            showText = true;
            LevelEnd();
        }
        if (players.Count == 1)
        {
            if (players[0].name == "Player 1")
            {
                winText = "Player 1 Wins!! Press A to continue";
                showText = true;
                if (!pointsDelivered)
                { P1wins += 1; pointsDelivered = true; }
                LevelEnd();
            }
            if (players[0].name == "Player 2")
            {
                winText = "Player 2 Wins!! Press A to continue";
                showText = true;
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
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            SceneManager.LoadScene(0);
            showText = false;
        }
    }
}
