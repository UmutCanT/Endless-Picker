using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlatformPool platformPool;
    [SerializeField] Player playerPrefab;
    [SerializeField] Cinemachine.CinemachineVirtualCamera playerCam;
    Player player;
    Vector3 playerSpawnPoint = Vector3.zero;

    private void Awake()
    {
        playerSpawnPoint.z = platformPool.zSpawnPoint() - 8f;
        for (int i = 0; i < 3; i++)
        {
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
        player = Instantiate(playerPrefab, playerSpawnPoint, Quaternion.identity);
        playerCam.Follow = player.transform;
        playerCam.LookAt = player.transform;
    }
}
