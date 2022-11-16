using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlatformPool platformPool;
    [SerializeField] Player playerPrefab;
    [SerializeField] Cinemachine.CinemachineVirtualCamera playerCam;
    [SerializeField] Level level;
    Player player;
    Vector3 playerSpawnPoint = new Vector3(0, 0.25f, 0);

    private void Awake()
    {
        GenerateLastLevel();
        level.Part = 0;
        playerSpawnPoint.z = platformPool.SpawnPointZ() - 8f;
        for (int i = 0; i < 3; i++)
        {
            level.Part++;
            platformPool.GetLevelPlatform();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    void GenerateLastLevel()
    {
        level.GenerateLevel(PlayerStats.Instance.LevelPart1, PlayerStats.Instance.LevelPart2, PlayerStats.Instance.LevelPart3);
    }

    void GenerateLevel()
    {
        level.GenerateLevel();
    }

    void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPoint, playerPrefab.transform.rotation);
        playerCam.Follow = player.transform;
        playerCam.LookAt = player.transform;
    }
}
