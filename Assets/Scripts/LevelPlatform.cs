using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelPlatform : MonoBehaviour
{
    public static event Action OnPass;

    [SerializeField] GameObject gate;
    [SerializeField] GameObject progressGround;
    [SerializeField] Transform endPoint;
    GameManager gameManager;

    int requiredColletablesToPass =  1;
    float waitTimeToPass = 2f;
    IObjectPool<LevelPlatform> levelPlatformPool;


    public int RequiredColletablesToPass { get => requiredColletablesToPass; set => requiredColletablesToPass = value; }

    public float EndPointZ { get => endPoint.position.z; }

    //void Awake()
    //{
    //    gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    //}


    public void SetPool(IObjectPool<LevelPlatform> pool)
    {
        levelPlatformPool = pool;
    }

    public IEnumerator PassGranted()
    {
        yield return new WaitForSeconds(waitTimeToPass);
        OnPass();
        gate.SetActive(false);
        progressGround.SetActive(true);
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
