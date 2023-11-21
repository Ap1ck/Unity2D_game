using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Canvas _loseCanvas;
    public LayerMask LayerPlayer;

    private PlayerMovement _playerMovement;
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    private float _horizontalMovement;

    private bool _canMove = true;
    private bool _facingRight = true;
    private bool _freezRotation = false;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerHealthComponent.OnDied += ForbidToMove;
        ZoneManager.OnDestroy += DeletedPlayer;
    }

    private void OnDisable()
    {
        PlayerHealthComponent.OnDied -= ForbidToMove;
        ZoneManager.OnDestroy -= DeletedPlayer;
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxis(GlobalStringVariors.Horizontal);
        bool isJumpPressed = Input.GetButtonDown(GlobalStringVariors.Jump);

        if (_canMove)
        {
            if (!_freezRotation)
            {
                if (_horizontalMovement > 0 && !_facingRight)
                {
                    Flip();
                }
                else if (_horizontalMovement < 0 && _facingRight)
                {
                    Flip();
                }
            }

            _animator.SetFloat("Speed", Mathf.Abs(_horizontalMovement));
            _playerMovement.Move(_horizontalMovement, isJumpPressed);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _canMove = false;
            StartCoroutine(IcanMove());
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void ForbidToMove()
    {
        _rigidBody.simulated = false;
        _freezRotation = true;
    }

    private void DeletedPlayer()
    {
        Destroy(gameObject);
    }

    private IEnumerator IcanMove()
    {
        yield return new WaitForSeconds(1.15f);
        _canMove = true;
    }
}
