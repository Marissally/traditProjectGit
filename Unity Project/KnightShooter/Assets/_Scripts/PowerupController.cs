using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PowerupController : MonoBehaviour {
    //0 is none
    //1 is shotgun
    //2 is rocket
    //3 is shield
    public Rigidbody2D _shotgunPower;
    public Rigidbody2D _rocketPower;
    public Rigidbody2D _shieldPower;
    public int currentPower = 0;
	public int timer = 30;
	private int baseTime;
	public List<Rigidbody2D> powerups= new List<Rigidbody2D>(4);
    private System.Random r;

    // Use this for initialization
    void Start () {
        baseTime = DateTime.UtcNow.Millisecond;
        powerups[1] = _shotgunPower;
        powerups[2] = _rocketPower;
        powerups[3] = _shieldPower;
	}
	
	// Update is called once per frame
	void Update () {
        int p = r.Next(1, 4);
        
        int check = DateTime.UtcNow.Millisecond - baseTime;
        if (check > timer && currentPower == 0)
        {
            Rigidbody2D powerup = Instantiate(powerups[p], transform.position, transform.rotation) as Rigidbody2D;
            baseTime = DateTime.UtcNow.Millisecond;
            check = 0;
        }
    }
}
