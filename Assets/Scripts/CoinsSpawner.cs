using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CoinsSpawner : MonoBehaviour
{
    private static Random _random = new Random();

    [SerializeField] private Coin _prefab;
    [SerializeField] private GameObject _spawnPoints;
    [SerializeField] private float _periodicity;

    private WaitForSeconds _delay;
    private CoinSpawnPoint[] _points;

    private void Awake()
    {
        _delay = new WaitForSeconds(_periodicity);
        _points = _spawnPoints.GetComponentsInChildren<CoinSpawnPoint>();

        foreach (CoinSpawnPoint point in _points)
            point.Free();

        StartCoroutine(CreateCoins());
    }

    private IEnumerator CreateCoins()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            bool isAnyFreePoint = false;

            foreach (CoinSpawnPoint point in _points)
                isAnyFreePoint = isAnyFreePoint || point.IsFree;

            if (isAnyFreePoint)
            {
                CoinSpawnPoint point = null;
                bool gotFreePoint = false;

                while (gotFreePoint == false)
                {
                    int pointIndex = _random.Next(0, _points.Length);
                    point = _points[pointIndex];
                    gotFreePoint = point.IsFree;
                }

                Coin newCoin = Instantiate(_prefab);
                newCoin.SetToPoint(point);
            }

            yield return _delay;
        }
    }
}
