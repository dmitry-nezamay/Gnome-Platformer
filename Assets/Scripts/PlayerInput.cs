using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public static Action<string> OnPlayerInput;

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

        if (Input.GetKey(KeyCode.LeftArrow))
            Direction = Directions.Left;
        else if (Input.GetKey(KeyCode.RightArrow))
            Direction = Directions.Right;
        else if (Input.GetKey(KeyCode.UpArrow))
            Direction = Directions.Up;

        if (Direction != Directions.None)
            OnPlayerInput?.Invoke(Direction);
    }
}
