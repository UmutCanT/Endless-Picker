using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelType/MobileSpawner")]
public class MobileSpawner : LevelTypes
{
    public override float SpawnFormation(Vector3 pos, int n)
    {
        return pos.z - 4f + n * 0.1f;
    }
}
