using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MOVE_DIRECTION
{
    STOP,
    LEFT,
    RIGHT
}

[CreateAssetMenu(fileName = "PlayerStates", menuName = "PragmaTechs/SO/Custom/PlayerStates", order = 1)]

public class PlayerStates : ScriptableObject
{
    public MOVE_DIRECTION playerMoveDirection;
    public bool isWalking;
    public bool isGrounded;
    public bool isIdle;
    public bool isJumping;
    public bool isRunning;
    public bool isPushing;
    public bool isCrouching;
    public bool isDead;

}
