using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private static float _speed = 3;

    [SerializeField] private GameObject _path;

    private SpriteRenderer _spriteRenderer;
    private PathPoint[] _points;
    private PathPoint _nextPoint;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = _path.GetComponentsInChildren<PathPoint>();

        if (_points.Length > 0)
            _nextPoint = _points[0];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPoint.transform.position, _speed * Time.deltaTime);
        _spriteRenderer.flipX = (transform.position.x > _nextPoint.transform.position.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PathPoint>(out PathPoint point))
        {
            if (point == _nextPoint)
            {
                int currentIndex = Array.IndexOf(_points, point);

                if (currentIndex != -1)
                {
                    int nextIndex = (currentIndex == _points.Length - 1) ? 0 : currentIndex + 1;
                    _nextPoint = _points[nextIndex];
                }
            }
        }
    }
}
