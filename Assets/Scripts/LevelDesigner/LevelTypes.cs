using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelTypes : ScriptableObject
{
    [SerializeField] string description;
    [SerializeField] int requiredCollectablesToPass;
    [SerializeField] int spawnedCollectables;
    [SerializeField] CollectableTypes[] collectableTypes;

    public int RequiredCollectablesToPass { get => requiredCollectablesToPass; }

    public abstract void Initiliaze();
}
