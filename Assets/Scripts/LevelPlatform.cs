using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelPlatform : MonoBehaviour
{
    public static event Action OnPass;
    public static event Action OnFail;

    [SerializeField] GameObject gate;
    [SerializeField] GameObject progressGround;
    [SerializeField] Transform endPoint;
    [SerializeField] GameObject checkPoint;
    [SerializeField] BoxCollider spawnBox;

    int requiredColletablesToPass =  1;
    int spawnedCollectables = 0;
    IObjectPool<LevelPlatform> levelPlatformPool;


    public int RequiredColletablesToPass { get => requiredColletablesToPass; set => requiredColletablesToPass = value; }
    public float EndPointZ { get => endPoint.position.z; }
    public int SpawnedCollectables { get => spawnedCollectables; set => spawnedCollectables = value; }
    public BoxCollider SpawnBox { get => spawnBox; set => spawnBox = value; }

    public void SetPool(IObjectPool<LevelPlatform> pool)
    {
        levelPlatformPool = pool;
    }

    public void PassGranted()
    {        
        OnPass();
        gate.SetActive(false);
        progressGround.SetActive(true);
        checkPoint.SetActive(false);
    }

    public void PassDenied()
    {
        OnFail();
    }

    void ResetPlatform()
    {
        gate.SetActive(true);
        progressGround.SetActive(false);
        checkPoint.SetActive(true);
    }

    void OnDisable()
    {
        ResetPlatform();
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
