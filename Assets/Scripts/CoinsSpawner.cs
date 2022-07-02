using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Linq;
using System;

public class CoinsSpawner : MonoBehaviour
{
    private static Random _random = new Random();

    [SerializeField] private GameObject _spawnPoints;
    [SerializeField] private float _periodicity;

    private WaitForSeconds _delay;
    private CoinSpawnPoint[] _points;

    private void Awake()
    {
        _delay = new WaitForSeconds(_periodicity);
        _points = _spawnPoints.GetComponentsInChildren<CoinSpawnPoint>();
        StartCoroutine(CreateCoins());
    }

    private IEnumerator CreateCoins()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            CoinSpawnPoint[] freePoints = _points.Where(point => point.CoinInPoint == null).OrderBy(point => _random.Next()).ToArray();

            if (freePoints.Length > 0)
                freePoints[0].SpawnCoin();

            yield return _delay;
        }
    }
}
