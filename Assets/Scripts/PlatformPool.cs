using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformPool : MonoBehaviour
{
    const float LEVEL_PLATFORM_DIFFERENCE_Z = 10f;
    [SerializeField] LevelPlatform levelPlatformPrefab;
    [SerializeField] GameObject rampPlatformPrefab;
    [SerializeField] GameObject bonusPlatformPrefab;
    [SerializeField] Level level;
    [SerializeField] CollectablePool collectablePool;
    IObjectPool<LevelPlatform> levelPlatformPool;
    float zLastEndPointPos = 0f;
    GameObject rampPlatform;
    GameObject bonusPlatform;

    Vector3 spawnBoxPos;
    Vector3 spawnBoxMax;

    void Awake()
    {
        SpawnBonusArea();

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
        ActivateBonusPlatform();
        lPlatform.gameObject.SetActive(true);       
        lPlatform.Level = PlayerStats.Instance.PlayerLevel;
        lPlatform.Part = level.Part;
        lPlatform.RequiredColletablesToPass = level.SelectedLevel[level.Part-1].RequiredCollectablesToPass;       
        lPlatform.transform.position = Vector3.forward * SpawnPointZ();
        spawnBoxPos = lPlatform.SpawnBox.transform.position;
        zLastEndPointPos = lPlatform.EndPointZ;
        SpawnCollectables(level.SelectedLevel[level.Part - 1].SpawnedCollectables);
    }

    void ActivateBonusPlatform()
    {
        if (level.Part == 1)
        {
            bonusPlatform.transform.position = Vector3.forward * (zLastEndPointPos - 15f);
            bonusPlatform.SetActive(true);
        }
    }

    public void ActivateRampPlatform()
    {
        rampPlatform.SetActive(true);
        rampPlatform.transform.position = new Vector3(0, 4f, zLastEndPointPos + 5f);
        zLastEndPointPos += 55f;
    }

    void SpawnBonusArea()
    {
        rampPlatform = Instantiate(rampPlatformPrefab);
        rampPlatform.SetActive(false);
        bonusPlatform = Instantiate(bonusPlatformPrefab);
        bonusPlatform.SetActive(false);
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
