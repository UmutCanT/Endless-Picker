using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformPool : MonoBehaviour
{
    const float LEVEL_PLATFORM_DIFFERENCE_Z = 20f;
    [SerializeField] LevelPlatform levelPlatformPrefab;
    IObjectPool<LevelPlatform> levelPlatformPool;
    float zLastEndPointPos = 0f;

    void Awake()
    {
        levelPlatformPool = new ObjectPool<LevelPlatform>(
            CreateLevelPlatform,
            OnGet,
            OnRelease
            );
    }
   
    LevelPlatform CreateLevelPlatform()
    {
        LevelPlatform levelPlatform = Instantiate(levelPlatformPrefab);
        levelPlatform.SetPool(levelPlatformPool);
        zLastEndPointPos = levelPlatform.EndPointZ;
        return levelPlatform;
    }

    void OnGet(LevelPlatform lPlatform)
    {
        lPlatform.transform.position = new Vector3(0, 0, zSpawnPoint());
        lPlatform.gameObject.SetActive(true);        
    }

    void OnRelease(LevelPlatform lPlatform)
    {
        lPlatform.gameObject.SetActive(false);      
    }

    public float zSpawnPoint()
    {
        return zLastEndPointPos + LEVEL_PLATFORM_DIFFERENCE_Z;
    }


    public void GetLevelPlatform()
    {
        levelPlatformPool.Get();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
