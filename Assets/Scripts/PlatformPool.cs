using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] LevelPlatform levelPlatformPrefab;
    IObjectPool<LevelPlatform> levelPlatformPool;

    void Awake()
    {
        levelPlatformPool = new ObjectPool<LevelPlatform>(
            CreateLevelPlatform,
            OnGet,
            OnRelease
            );
    }
   
    private LevelPlatform CreateLevelPlatform()
    {
        LevelPlatform levelPlatform = Instantiate(levelPlatformPrefab);
        levelPlatform.SetPool(levelPlatformPool);
        return levelPlatform;
    }

    private void OnGet(LevelPlatform lPlatform)
    {
        lPlatform.gameObject.SetActive(true);
    }

    private void OnRelease(LevelPlatform lPlatform)
    {
        lPlatform.gameObject.SetActive(false);      
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
