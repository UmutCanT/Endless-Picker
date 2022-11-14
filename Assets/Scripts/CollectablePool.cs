using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CollectablePool : MonoBehaviour
{
    [SerializeField] Collectable sphere;
    IObjectPool<Collectable> spherePool;

    private void Awake()
    {
        spherePool = new ObjectPool<Collectable>(
            CreateSphere,
            OnGetSphere,
            OnReleaseSphere
            );
    }

    private Collectable CreateSphere()
    {
        Collectable sphereCol = Instantiate(sphere);
        sphereCol.CollectableType = CollectableTypes.Sphere;
        return sphereCol;
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
        spherePool.Get();
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
