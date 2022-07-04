using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public static event Action<string> Input;

    public static class Directions
    {
        public const string None = nameof(None);
        public const string Left = nameof(Left);
        public const string Right = nameof(Right);
        public const string Up = nameof(Up);
    }

    private void Update()
    {
        string Direction = Directions.None;

        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            Direction = Directions.Left;
        else if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            Direction = Directions.Right;
        else if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
            Direction = Directions.Up;

        if (Direction != Directions.None)
            Input?.Invoke(Direction);
    }
}
