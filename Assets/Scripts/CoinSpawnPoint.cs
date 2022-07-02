using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    public Coin CoinInPoint { get; private set; }

    private void Awake()
    {
        CoinInPoint = null;
    }

    public void Free(Coin destroyedCoin)
    {
        if (CoinInPoint == destroyedCoin)
        {
            CoinInPoint = null;
            Coin.OnDestroyed -= Free;
        }
    }

    public void SpawnCoin()
    {
        CoinInPoint = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        Coin.OnDestroyed += Free;
    }
}
