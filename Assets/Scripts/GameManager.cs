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
        level.GenerateLevel();
        PlayerStats.Instance.PlayerPart = 0;
        playerSpawnPoint.z = platformPool.SpawnPointZ() - 8f;
        for (int i = 0; i < 3; i++)
        {
            PlayerStats.Instance.PlayerPart++;
            platformPool.GetLevelPlatform();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPoint, playerPrefab.transform.rotation);
        playerCam.Follow = player.transform;
        playerCam.LookAt = player.transform;
    }
}
