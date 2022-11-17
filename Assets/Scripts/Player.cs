using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnChangeToNormal;

    PlayerStates playerState;
    [SerializeField] GameObject forceArea;

    public PlayerStates PlayerState { get => playerState; set => playerState = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerStates.stopped;
    }

    void OnEnable()
    {
        LevelPlatform.OnPass += ChangeStateToNormal;
        LevelPlatform.OnFail += ChangeStateToStop;
        CheckPoint.OnCheck += ChangeStateToStop;
        CheckPoint.OnCheck += ForceActivator;
        BonusCheck.OnLevelComplete += ChangeStateToStop;
    }

    void OnDisable()
    {
        LevelPlatform.OnPass -= ChangeStateToNormal;
        LevelPlatform.OnFail -= ChangeStateToStop;
        CheckPoint.OnCheck -= ChangeStateToStop;
        CheckPoint.OnCheck -= ForceActivator;
        BonusCheck.OnLevelComplete -= ChangeStateToStop;
    }

    public void ChangeStateToNormal()
    {
        OnChangeToNormal();
        forceArea.SetActive(false);
        playerState = PlayerStates.normal;
        GetComponent<PlayerController>().enabled = true;
    }

    void ChangeStateToStop()
    {
        playerState = PlayerStates.stopped;
        GetComponent<PlayerController>().CanDrag = false;
        GetComponent<PlayerController>().enabled = false;
    }

    void ForceActivator()
    {
        forceArea.SetActive(true);
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
