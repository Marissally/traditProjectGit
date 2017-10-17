using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour {

    private Rigidbody2D _rb;
    private bool _grounded = false;
    private bool _right = true;
    private bool _left = false;

    public UnityEvent levelEndEvent;
    public Rigidbody2D _shot;
	public Rigidbody2D _shotgun;
	public Rigidbody2D _rocket;
	public int ammo;
	public bool shield = false;
    public bool _destructible = true;
    public float _acceleration = 20f;
    public float _maxSpeed = 10f;
    public float _jumpForce = 500f;
    public float _airControl = 0.5f;
    public float _shotSpeed = 800f;
    public float _horizontalVelocity;
    public float _verticalAim;
	public string shotType = "Default";



    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        _horizontalVelocity = Input.GetAxis("Horizontal_1");
        _verticalAim = Input.GetAxis("Vertical_1");

		if (_left) {
			GetComponentInChildren<SpriteRenderer> ().flipX = false;
		}
		if (_right) {
			GetComponentInChildren<SpriteRenderer> ().flipX = true;
		}
        if (!_grounded)
        {
            _horizontalVelocity *= _airControl;
        }
			

		//use button 0 for pc
		//use button 16 for mac
        if(Input.GetKeyDown(KeyCode.Joystick1Button0) && _grounded)
        {
            _rb.AddForce(new Vector2(_horizontalVelocity * _acceleration, _jumpForce));
            _grounded = false;
        }

        if(Mathf.Abs(_rb.velocity.x) < _maxSpeed)
        {
            _rb.AddForce(new Vector2(_horizontalVelocity * _acceleration, 0f));
            if(_horizontalVelocity < 0)
            {
                _right = false;
                _left = true;
            }
            if(_horizontalVelocity > 0)
            {
                _right = true;
                _left = false;
            }
        }

		//use button 2 for pc
		//use button 18 for mac
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
			if (shotType == "Default") 
			{
				Rigidbody2D bullet = Instantiate (_shot, transform.position, transform.rotation) as Rigidbody2D;
                if (_verticalAim == 1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed));
                }
                else if (_verticalAim == -1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed * -1));
                }
				else if (_right) {
					bullet.AddForce (new Vector2 (_shotSpeed, _shotSpeed * _verticalAim));
				}
				else if (_left) {
					bullet.AddForce (new Vector2 (_shotSpeed * -1, _shotSpeed * _verticalAim));
				}
			}

			if (shotType == "Shotgun") 
			{
				Rigidbody2D bullet = Instantiate (_shotgun, transform.position, transform.rotation) as Rigidbody2D;
                if (_verticalAim == 1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed));
                }
                else if (_verticalAim == -1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed * -1));
                }
                else if (_right) {
					bullet.AddForce (new Vector2 (_shotSpeed, _shotSpeed * _verticalAim));
				}
				else if (_left) {
					bullet.AddForce (new Vector2 (_shotSpeed * -1, _shotSpeed * _verticalAim));
				}
			}

			if (shotType == "Rocket") 
			{
				Rigidbody2D bullet = Instantiate (_rocket, transform.position, transform.rotation) as Rigidbody2D;
                if (_verticalAim == 1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed));
                }
                else if (_verticalAim == -1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed * -1));
                }
                else if (_right) {
					bullet.AddForce (new Vector2 (_shotSpeed, _shotSpeed * _verticalAim));
				}
				else if (_left) {
					bullet.AddForce (new Vector2 (_shotSpeed * -1, _shotSpeed * _verticalAim));
				}
			}
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.point.y < transform.position.y - 0.5f)
            {
                _grounded = true;
            }
        }
    }
}
