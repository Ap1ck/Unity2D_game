using UnityEngine;
using System;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Transform _firePoint;

    private float _shotAnimationTime= 1.15f;
    private bool _canShoot = true;

    public static event Action<bool> OnShoot;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_canShoot)
            {
                OnShoot?.Invoke(true);
                StartCoroutine(Shooting());
            }
        }
    }

    public void Shoot()
    {
        Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }

    private IEnumerator Shooting()
    {
        StartShootingAnimation();
        yield return new WaitForSeconds(_shotAnimationTime);
        AnimationComplete();
    }

    private void StartShootingAnimation()
    {
        if (_canShoot)
        {
            _animator.SetBool("isShoot", true);
            _canShoot = false;
        }
    }

    private void AnimationComplete()
    {
        _animator.SetBool("isShoot", false);
        Shoot();
        _canShoot = true;
    }
}

