using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private static float _speed = 3;
    private static float _jumpForce = 10;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;

    public int CoinsCounter { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        CoinsCounter = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            CoinsCounter++;
            Destroy(coin.gameObject);
        }
    }

    public void OnMoveLeftRight(bool isMovingLeft)
    {
        Vector3 vector = new Vector3((isMovingLeft ? -1 : 1) * _speed * Time.deltaTime, 0, 0);
        transform.Translate(vector);
        _renderer.flipX = isMovingLeft;
    }

    public void OnMoveUp()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
    }
}
