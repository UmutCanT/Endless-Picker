using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CollectablePool : MonoBehaviour
{
    [SerializeField] Collectable collectable;
    IObjectPool<Collectable> collectablePool;

    private void Awake()
    {
        collectablePool = new ObjectPool<Collectable>(
            CreateSphere,
            OnGetSphere,
            OnReleaseSphere
            );
    }

    private Collectable CreateSphere()
    {
        Collectable col = Instantiate(collectable);
        return col;
    }
    private void OnGetSphere(Collectable obj)
    {
        throw new NotImplementedException();
    }

    private void OnReleaseSphere(Collectable obj)
    {
        throw new NotImplementedException();
    }

    public void GetSphere()
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
