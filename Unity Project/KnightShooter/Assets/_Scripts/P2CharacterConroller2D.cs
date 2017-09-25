﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class P2CharacterConroller2D : MonoBehaviour {

    private Rigidbody2D _rb;
    private bool _grounded = false;
    private bool _right = false;
    private bool _left = true;

    public UnityEvent levelEndEvent;
    public Rigidbody2D _shot;
    public bool _destructible = true;
    public float _acceleration = 20f;
    public float _maxSpeed = 10f;
    public float _jumpForce = 500f;
    public float _airControl = 0.5f;
    public float _shotSpeed = 800f;
    public float _horizontalVelocity;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalVelocity = Input.GetAxis("Horizontal_2");

        if (!_grounded)
        {
            _horizontalVelocity *= _airControl;
        }

		//use button 0 for pc
		//use button 16 for mac
        if (Input.GetKey(KeyCode.Joystick2Button0) && _grounded)
        {
            _rb.AddForce(new Vector2(_horizontalVelocity * _acceleration, _jumpForce));
            _grounded = false;
        }

        if (Mathf.Abs(_rb.velocity.x) < _maxSpeed)
        {
            _rb.AddForce(new Vector2(_horizontalVelocity * _acceleration, 0f));
            if (_horizontalVelocity < 0)
            {
                _right = false;
                _left = true;
            }
            if (_horizontalVelocity > 0)
            {
                _right = true;
                _left = false;
            }
        }

		//use button 2 for pc
		//use button 18 for mac
        if (Input.GetKeyDown(KeyCode.Joystick2Button2))
        {
            Rigidbody2D bullet = Instantiate(_shot, transform.position, transform.rotation) as Rigidbody2D;
            if (_right)
            {
                bullet.AddForce(new Vector2(_shotSpeed, 0f));
            }
            if (_left)
            {
                bullet.AddForce(new Vector2(_shotSpeed * -1, 0f));
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
