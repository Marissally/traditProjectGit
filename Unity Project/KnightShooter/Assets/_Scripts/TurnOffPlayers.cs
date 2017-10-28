using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPlayers : MonoBehaviour {

    public List<GameObject> players;
    public GameObject P1Card;
    public GameObject P2Card;

    // Use this for initialization
    void Start () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        players[0].SetActive(false);
        players[1].SetActive(false);
        players[2].SetActive(false);
        players[3].SetActive(false);
        P1Card.SetActive(false);
        P2Card.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
