using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelType/MobileSpawner")]
public class MobileSpawner : LevelTypes
{
    public override void Initiliaze()
    {
    }

    public override Vector3 SpawnFormation(BoxCollider boxCollider, int totalCollectable, int collectableOrder)
    {
        throw new System.NotImplementedException();
    }
}
