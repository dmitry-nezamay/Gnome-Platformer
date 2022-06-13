using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawnPoint : MonoBehaviour
{
    public bool IsFree { get; private set; }

    public void SetFree()
    {
        IsFree = true;
    }

    public void SetOccupied()
    {
        IsFree = false;
    }
}
