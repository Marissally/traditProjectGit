using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour {

    private Rigidbody2D _rb;
	private Animator _anim;
    private bool _grounded = false;
    private bool _right = true;
    private bool _left = false;

    public UnityEvent levelEndEvent;
    public Rigidbody2D _shot;
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
    public KeyCode jumpButton;
    public KeyCode shootButton;
    public string _horizontalControl;
    public string _verticalControl;
    public string walking;



    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();
		_anim = this.GetComponentInChildren<Animator> ();
		_anim.SetBool (walking, false);
	}
	
	// Update is called once per frame
	void Update () {
        _horizontalVelocity = Input.GetAxis(_horizontalControl);
        _verticalAim = Input.GetAxis(_verticalControl);

		if (_left) {
			this.GetComponentInChildren<SpriteRenderer> ().flipX = false;
		}
		if (_right) {
			this.GetComponentInChildren<SpriteRenderer> ().flipX = true;
		}
        if (!_grounded)
        {
            _horizontalVelocity *= _airControl;
        }
			
			

		//use button 0 for pc
		//use button 16 for mac
        if(Input.GetKeyDown(jumpButton) && _grounded)
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
				_anim.SetBool (walking, true);

            }
            if(_horizontalVelocity > 0)
            {
                _right = true;
                _left = false;
				_anim.SetBool (walking, true);

            }
			if (_horizontalVelocity == 0) {
				_anim.SetBool (walking, false);
			}

        }

		//use button 2 for pc
		//use button 18 for mac
        if (Input.GetKeyDown(shootButton))
        {
			if (shotType == "Default" || ammo == 0) 
			{
                shotType = "Default";
				Rigidbody2D bullet = Instantiate (_shot, transform.position, transform.rotation) as Rigidbody2D;
                bullet.GetComponent<BulletController>().spawnOrigin = this;
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

			if (shotType == "Shotgun" && ammo != 0) 
			{
				Rigidbody2D bullet = Instantiate (_shot, transform.position, transform.rotation) as Rigidbody2D;
				Rigidbody2D bullet2 = Instantiate (_shot, transform.position, transform.rotation) as Rigidbody2D;
				Rigidbody2D bullet3 = Instantiate (_shot, transform.position, transform.rotation) as Rigidbody2D;
                bullet.GetComponent<BulletController>().spawnOrigin = this;
                bullet2.GetComponent<BulletController>().spawnOrigin = this;
                bullet3.GetComponent<BulletController>().spawnOrigin = this;
                if (_verticalAim == 1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed));
					bullet2.AddForce(new Vector2(_shotSpeed, _shotSpeed));
					bullet3.AddForce(new Vector2(_shotSpeed * -1, _shotSpeed));
                }
                else if (_verticalAim == -1)
                {
                    bullet.AddForce(new Vector2(0f, _shotSpeed * -1));
					bullet2.AddForce(new Vector2(_shotSpeed, _shotSpeed * -1));
					bullet3.AddForce(new Vector2(_shotSpeed * -1, _shotSpeed * -1));
                }
                else if (_right) {
					bullet.AddForce (new Vector2 (_shotSpeed, _shotSpeed * _verticalAim));
                    if (_verticalAim != 0)
                    {
                        bullet2.AddForce(new Vector2(_shotSpeed, _shotSpeed * (_verticalAim * 2)));
                        bullet3.AddForce(new Vector2(_shotSpeed, _shotSpeed * (_verticalAim * -2)));
                    }
                    else
                    {
                        bullet2.AddForce(new Vector2(_shotSpeed, _shotSpeed / 2));
                        bullet3.AddForce(new Vector2(_shotSpeed, _shotSpeed / -2));
                    }
				}
				else if (_left) {
					bullet.AddForce (new Vector2 (_shotSpeed * -1, _shotSpeed * _verticalAim));
                    if (_verticalAim != 0)
                    {
                        bullet2.AddForce(new Vector2(_shotSpeed * -1, _shotSpeed * (_verticalAim * 2)));
                        bullet3.AddForce(new Vector2(_shotSpeed * -1, _shotSpeed * (_verticalAim * 2)));
                    }
                    else
                    {
                        bullet2.AddForce(new Vector2(_shotSpeed * -1, _shotSpeed / 2));
                        bullet3.AddForce(new Vector2(_shotSpeed * -1, _shotSpeed / -2));
                    }
				}
                ammo--;
			}

			if (shotType == "Rocket" && ammo != 0) 
			{
				Rigidbody2D bullet = Instantiate (_rocket, transform.position, transform.rotation) as Rigidbody2D;
                bullet.GetComponent<RocketController>().spawnOrigin = this;
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
                ammo--;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Powerup")
        {
            //check for powerup
            if (collision.gameObject.name == "shotgunPower(Clone)")
            {
                Destroy(collision.gameObject);
                shotType = "Shotgun";
                ammo = 12;
                shield = false;
            }

            if (collision.gameObject.name == "rocketPower(Clone)")
            {
                Destroy(collision.gameObject);
                shotType = "Rocket";
                ammo = 2;
                shield = false;
            }

            if (collision.gameObject.name == "shieldPower(Clone)")
            {
                Destroy(collision.gameObject);
                shield = true;
            }
        }
    }
}
