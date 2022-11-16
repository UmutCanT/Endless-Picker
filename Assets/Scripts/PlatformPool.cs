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
    [SerializeField] CollectablePool collectablePool;
    IObjectPool<LevelPlatform> levelPlatformPool;
    float zLastEndPointPos = 0f;
    Vector3 spawnBoxPos;
    Vector3 spawnBoxMax;

    void Awake()
    {
        levelPlatformPool = new ObjectPool<LevelPlatform>(
            CreateLevelPlatform,
            OnGet,
            OnRelease
            );

        spawnBoxMax = levelPlatformPrefab.SpawnBox.bounds.max;
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
        lPlatform.RequiredColletablesToPass = level.SelectedLevel[level.Part-1].RequiredCollectablesToPass;       
        lPlatform.transform.position = new Vector3(0, 0, SpawnPointZ());
        spawnBoxPos = lPlatform.SpawnBox.transform.position;
        zLastEndPointPos = lPlatform.EndPointZ;
        SpawnCollectables(level.SelectedLevel[level.Part - 1].SpawnedCollectables);
    }

    void SpawnCollectables(int numberOfCollectables)
    {
        for (int i = 0; i < numberOfCollectables; i++)
        {
            if (i <= numberOfCollectables)
            {
                level.SelectedLevel[level.Part - 1].SpawnPos = Bounds(numberOfCollectables, i, true);
            }else
                level.SelectedLevel[level.Part - 1].SpawnPos = Bounds(numberOfCollectables, i, false);
            collectablePool.GetCollectable();
        }     
    }

    Vector3 Bounds(int numberOfCollectables, int order, bool side)
    {
        float xMax = spawnBoxPos.x + spawnBoxMax.x;
        float xMin = spawnBoxPos.x - spawnBoxMax.x;
        float zMax = spawnBoxPos.z + spawnBoxMax.z;
        float zMin = spawnBoxPos.z - spawnBoxMax.z;

        float xDifference = (4 * spawnBoxMax.x) / (float)numberOfCollectables;
        float zDifference = (4 * spawnBoxMax.z) / (float)numberOfCollectables;
        if (side)
        {
            return new Vector3(xMax - ((float)order * xDifference), 2f, zMax - ((float)order * zDifference));
        } else
            return new Vector3(xMin + ((float)(order - numberOfCollectables/2 ) * xDifference), 2f, zMax - ((float)order * zDifference));
        
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
