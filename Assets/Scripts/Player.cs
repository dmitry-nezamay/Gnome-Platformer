using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static float _speed = 3;
    private static float _jumpForce = 10;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public int CoinsCounter { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        CoinsCounter = 0;
    }

    private void Update()
    {
        Vector3 vector = new Vector3();
        float deltaTime = Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vector = new Vector3(-1 * _speed * deltaTime, 0, 0);
            transform.Translate(vector);
            _renderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vector = new Vector3(_speed * deltaTime, 0, 0);
            transform.Translate(vector);
            _renderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            CoinsCounter++;
            Debug.Log($"������� {CoinsCounter} �����");
            Destroy(coin.gameObject);
        }
        else if (collision.TryGetComponent<Enemy>(out Enemy enemy)) 
        {
            Debug.Log("���������!");
        }
    }
}