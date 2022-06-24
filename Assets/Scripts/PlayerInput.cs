using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            _player.OnMoveLeftRight(true);
        else if (Input.GetKey(KeyCode.RightArrow))
            _player.OnMoveLeftRight(false);
        else if (Input.GetKey(KeyCode.UpArrow))
            _player.OnMoveUp();
    }
}
