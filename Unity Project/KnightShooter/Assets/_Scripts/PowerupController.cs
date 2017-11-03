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
    public int timer = 15;
	public DateTime baseTime;
    public TimeSpan check;
	public List<Rigidbody2D> powerups = new List<Rigidbody2D>(4);

    // Use this for initialization
	void Start () {
        baseTime = DateTime.UtcNow;
		powerups.Add(new Rigidbody2D());
        powerups.Add(_shotgunPower);
        powerups.Add(_rocketPower);
        powerups.Add(_shieldPower);
	}
	
	// Update is called once per frame
	void Update () {
		int p = UnityEngine.Random.Range(1, 4);

        check = DateTime.UtcNow.Subtract(baseTime);
        if (check.Seconds > timer && currentPower == 0)
        {
            Rigidbody2D powerup = Instantiate(powerups[p], transform.position, transform.rotation) as Rigidbody2D;
            baseTime = DateTime.UtcNow;
			currentPower = p;
            timer = 30;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Powerup")
        {
            currentPower = 0;
        }
    }
}
