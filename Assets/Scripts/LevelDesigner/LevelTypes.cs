using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelTypes : ScriptableObject
{
    [SerializeField] string description;
    [SerializeField] int requiredCollectablesToPass;
    [SerializeField] int spawnedCollectables;
    [SerializeField] CollectableTypes collectableType;
    [SerializeField] float scaleMult;
    BoxCollider spawnArea;
    Vector3 spawnPos;

    public int RequiredCollectablesToPass { get => requiredCollectablesToPass; }
    public int SpawnedCollectables { get => spawnedCollectables; }
    public CollectableTypes CollectableType { get => collectableType; }
    public float ScaleMult { get => scaleMult; }
    public BoxCollider SpawnArea { get => spawnArea; set => spawnArea = value; }
    public Vector3 SpawnPos { get => spawnPos; set => spawnPos = value; }

    public abstract float SpawnFormation(Vector3 pos, int n);
}
