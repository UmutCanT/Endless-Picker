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

    void Awake()
    {
        SpawnBonusArea();

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
        ActivateBonusPlatform();
        lPlatform.gameObject.SetActive(true);
        lPlatform.RequiredColletablesToPass = level.SelectedLevel[level.Part-1].RequiredCollectablesToPass;       
        lPlatform.transform.position = Vector3.forward * SpawnPointZ();
        zLastEndPointPos = lPlatform.EndPointZ;
        SpawnCollectables(level.SelectedLevel[level.Part - 1].SpawnedCollectables, lPlatform.transform.position);
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

    void SpawnCollectables(int numberOfCollectables, Vector3 pos)
    {
        for (int i = 0; i < numberOfCollectables; i++)
        {
            if (i <= numberOfCollectables)
            {
                level.SelectedLevel[level.Part - 1].SpawnPos = new Vector3(-1f, 1.5f, pos.z -8.5f + i);
            }else
                level.SelectedLevel[level.Part - 1].SpawnPos = new Vector3(1f, 1.5f, pos.z - 8.5f + i);
            collectablePool.GetCollectable();
        }     
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
