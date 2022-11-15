using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CollectablePool : MonoBehaviour
{
    [SerializeField] Collectable collectable;
    [SerializeField] Level level;
    IObjectPool<Collectable> collectablePool;

    private void Awake()
    {
        collectablePool = new ObjectPool<Collectable>(
            CreateCollectable,
            OnGet,
            OnRelease
            );
    }

    private Collectable CreateCollectable()
    {
        Collectable col = Instantiate(collectable);
        return col;
    }
    private void OnGet(Collectable col)
    {
        col.gameObject.SetActive(true);
        col.CollectableTypeChanger(level.SelectedLevel[level.Part-1].CollectableType);
        col.OnSpawn(level.SelectedLevel[level.Part - 1].ScaleMult, level.SelectedLevel[level.Part-1].SpawnPos);
    }

    public void CollectableOnSpawn()
    {

    }

    private void OnRelease(Collectable obj)
    {
        throw new NotImplementedException();
    }

    public void GetCollectable()
    {
        collectablePool.Get();
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

public enum CollectableTypes
{
    Capsule,
    Cube,
    Cone,
    Sphere,
    Cylinder
}

public enum Behaviour
{
    Normal,
    SpawnLittleOnes,
    Chopper
}
