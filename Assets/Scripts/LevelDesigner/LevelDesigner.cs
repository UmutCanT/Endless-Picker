using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelDesigner : ScriptableObject
{
    [SerializeField] string description;
    [SerializeField] int requiredCollectablesToPass;
    [SerializeField] int spawnedCollectables;
    [SerializeField] CollectableTypes[] collectableTypes;

    public abstract void Initiliaze();
}
