using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    private static float _maxLifeSpan = 5f;

    public static Action<Coin> OnDestroyed;

    private void Awake()
    {
        Destroy(gameObject, _maxLifeSpan);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
