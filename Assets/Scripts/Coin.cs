using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    private static float _maxLifeSpan = 5f;

    public static event Action<Coin> Destroyed;

    private void Awake()
    {
        Destroy(gameObject, _maxLifeSpan);
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }
}
