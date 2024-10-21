using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _turboSpeed;
    private Rigidbody _rb;
    private Player _player;
    private Shooting _shooting;

    public Animator anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _shooting = GetComponent<Shooting>();
    }

    private void Start()
    {
        _turboSpeed = _player.speed * 1.2f;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameActive)
        {
            if (_player.user)
            {
                float horizontalInput = VariableJoystick.Instance.Horizontal;
                float verticalInput = VariableJoystick.Instance.Vertical;

                Vector3 movement = new Vector3(verticalInput, 0f, -1*horizontalInput).normalized;

                if (movement != Vector3.zero)
                    transform.rotation = Quaternion.LookRotation(movement);

                if (!_shooting.shooting)
                {
                    if (/*Input.GetKey(KeyCode.LeftShift)*/ ThrowButtonHandler.Instance.isButtonHold)  // Jika tombol Shift kiri ditekan
                        _rb.velocity = movement * _turboSpeed * Time.deltaTime;
                    else
                        _rb.velocity = movement * _player.speed * Time.deltaTime;
                }
                else
                {
                    _rb.velocity = Vector3.zero;
                }

                if(horizontalInput == 0 && verticalInput == 0)
                {
                    anim.Play("idle soccer");
                }
                else
                {
                    anim.Play("run soccer");
                }
            }
            else
            {
                if (_player.rb.velocity != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(_rb.velocity);
                    anim.Play("run soccer");
                }
                else
                {
                    anim.Play("idle soccer");
                }
                    
            }
        }
    }
}
