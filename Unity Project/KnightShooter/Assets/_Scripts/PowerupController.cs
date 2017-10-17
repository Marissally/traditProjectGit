using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerupController : MonoBehaviour {
    //0 is none
    //1 is shotgun
    //2 is rocket
    //3 is shield
    public Rigidbody2D _shotgunPower;
    public Rigidbody2D _rocketPower;
    public Rigidbody2D _shieldPower;
    public int currentPower = 0;
	public int timer = 30000000;
	private int baseTime;
	public List<Rigidbody2D> powerups= new List<Rigidbody2D>(4);

    // Use this for initialization
	void Start () {
        baseTime = DateTime.UtcNow.Millisecond;
        powerups.Add(_shotgunPower);
        powerups.Add(_rocketPower);
        powerups.Add(_shieldPower);
	}
	
	// Update is called once per frame
	void Update () {
		int p = UnityEngine.Random.Range(1, 3);
        
        int check = DateTime.UtcNow.Millisecond - baseTime;
        if (check > timer && currentPower == 0)
        {
            Rigidbody2D powerup = Instantiate(powerups[p], transform.position, transform.rotation) as Rigidbody2D;
            baseTime = DateTime.UtcNow.Millisecond;
            check = 0;
			currentPower = p;
        }
    }
}
