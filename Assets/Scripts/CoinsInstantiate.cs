using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CoinsInstantiate : MonoBehaviour
{
    private static Random _random = new Random();

    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private GameObject _coinSpawnPoints;
    [SerializeField] private float _periodicity;

    private WaitForSeconds _delay;
    private CoinSpawnPoint[] _points;

    private IEnumerator CreateCoins()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            bool isFreePoint = false;

            foreach (CoinSpawnPoint point in _points)
                isFreePoint = isFreePoint || point.IsFree;

            if (isFreePoint)
            {
                CoinSpawnPoint point = null;
                bool gotFreePoint = false;

                while (gotFreePoint == false)
                {
                    int pointIndex = _random.Next(0, _points.Length);
                    point = _points[pointIndex];
                    gotFreePoint = point.IsFree;
                }

                Coin newCoin = Instantiate(_coinPrefab);
                newCoin.SetToPoint(point);
            }

            yield return _delay;
        }
    }

    private void Awake()
    {
        _delay = new WaitForSeconds(_periodicity);
        _points = _coinSpawnPoints.GetComponentsInChildren<CoinSpawnPoint>();

        foreach (CoinSpawnPoint point in _points)
            point.SetFree();

        StartCoroutine(CreateCoins());
    }
}
