using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _maxLifeSpan;

    public float LifeSpan { get; private set; }
    public CoinSpawnPoint Point { get; private set; }

    public void SetToPoint(CoinSpawnPoint point)
    {
        if (point != null)
        {
            Point = point;
            point.SetOccupied();
            transform.position = point.transform.position;
            transform.rotation = Quaternion.identity;
        }
    }

    private void Awake()
    {
        LifeSpan = 0;
    }

    private void Update()
    {
        LifeSpan += Time.deltaTime;

        if (LifeSpan > _maxLifeSpan)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (Point != null)
            Point.SetFree();
    }
}
