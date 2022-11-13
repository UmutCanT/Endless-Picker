using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelDesigner : ScriptableObject
{
    [SerializeField] int requiredCollectablesToPass;
    [SerializeField] int spawnedCollectables;

    public abstract void Initiliaze();
}
