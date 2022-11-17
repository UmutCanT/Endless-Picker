using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnPartUpdate;
    public static event Action OnLevelUpdate;

    [SerializeField] PlatformPool platformPool;
    [SerializeField] Player playerPrefab;
    [SerializeField] Cinemachine.CinemachineVirtualCamera playerCam;
    [SerializeField] Level level;
    Player player;
    Vector3 playerSpawnPoint = new Vector3(0, 0.25f, 0);

    private void Awake()
    {
        GenerateLastLevel();
        playerSpawnPoint.z = platformPool.SpawnPointZ() - 8f;
        GeneratePlatform();
        MoveRamp();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void OnEnable()
    {
        NextLevelPoint.OnLevelPass += GenerateLevel;
        RampPoint.OnJump += MoveRamp;
        LevelPlatform.OnPass += PartPassed;
    }

    void OnDisable()
    {
        NextLevelPoint.OnLevelPass -= GenerateLevel;
        RampPoint.OnJump += MoveRamp;
        LevelPlatform.OnPass -= PartPassed;
    }

    public void LevelCompleted()
    {
        player.transform.position = Vector3.forward * (platformPool.SpawnPointZ() - 8f);
    }

    void GenerateLastLevel()
    {
        level.CurrentLevel = PlayerStats.Instance.PlayerLevel;
        OnLevelUpdate();
        level.GenerateLevel(PlayerStats.Instance.LevelPart1, PlayerStats.Instance.LevelPart2, PlayerStats.Instance.LevelPart3);
    }

    void GenerateLevel()
    {
        level.GenerateLevel();
        level.CurrentLevel++;
        OnLevelUpdate();
        GeneratePlatform();
    }

    void GeneratePlatform()
    {
        level.Part = 0;
        level.CurrentPart = 0;
        OnPartUpdate();
        for (int i = 0; i < 3; i++)
        {
            level.Part++;
            platformPool.GetLevelPlatform();
        }
    }

    void MoveRamp()
    {
        platformPool.ActivateRampPlatform();
    }

    void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPoint, playerPrefab.transform.rotation);
        playerCam.Follow = player.transform;
        playerCam.LookAt = player.transform;
    }

    void PartPassed()
    {
        level.CurrentPart++;
        OnPartUpdate();
    }
}
