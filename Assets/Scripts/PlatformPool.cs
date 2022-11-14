using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformPool : MonoBehaviour
{
    const float LEVEL_PLATFORM_DIFFERENCE_Z = 10f;
    [SerializeField] LevelPlatform levelPlatformPrefab;
    [SerializeField] Level level;
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
        return levelPlatform;
    }

    void OnGet(LevelPlatform lPlatform)
    {        
        lPlatform.gameObject.SetActive(true);
        Debug.Log(PlayerStats.Instance.PlayerLevel);        
        lPlatform.Level = PlayerStats.Instance.PlayerLevel;
        lPlatform.Part = level.Part;
        lPlatform.RequiredColletablesToPass = level.SelectedLevel[lPlatform.Part-1].RequiredCollectablesToPass;
        lPlatform.transform.position = new Vector3(0, 0, SpawnPointZ());
        zLastEndPointPos = lPlatform.EndPointZ;
    }

    void OnRelease(LevelPlatform lPlatform)
    {
        lPlatform.gameObject.SetActive(false);      
    }

    public float SpawnPointZ()
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
