using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStates playerState;

    public PlayerStates PlayerState { get => playerState; set => playerState = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerStates.stopped;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum PlayerStates
{
    bonusRampJump,
    proppelerPowerUp,
    normal,
    stopped
}
