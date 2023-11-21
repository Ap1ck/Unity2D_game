using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidBody;

    private float _timeLiveBullet=1;

    private void Start()
    {
        _rigidBody.velocity = transform.right * _speed;
        StartCoroutine(BulletLive());
    }

    private IEnumerator BulletLive()
    {
        yield return new WaitForSeconds(_timeLiveBullet);
        Destroy(gameObject);
    }
}
