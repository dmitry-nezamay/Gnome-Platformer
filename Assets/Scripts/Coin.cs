using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _maxLifeSpan;

    public CoinSpawnPoint Point { get; private set; }

    private void Awake()
    {
        Destroy(gameObject, _maxLifeSpan);
    }

    private void OnDestroy()
    {
        if (Point != null)
            Point.Free();
    }

    public void SetToPoint(CoinSpawnPoint point)
    {
        if (point != null)
        {
            Point = point;
            point.Occupy();
            transform.position = point.transform.position;
            transform.rotation = Quaternion.identity;
        }
    }
}
