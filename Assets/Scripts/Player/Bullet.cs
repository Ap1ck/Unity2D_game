using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody.velocity = transform.right * _speed;
    }
}
