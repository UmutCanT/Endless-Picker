using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelType/NormalSpawn")]
public class NormalSpawn : LevelTypes
{
    public override void Initiliaze()
    {
        throw new System.NotImplementedException();
    }

    public override Vector3 SpawnFormation(BoxCollider boxCollider, int totalCollectable, int collectableOrder)
    {
        //if(collectableOrder < totalCollectable / 2)
        //{
        //    return Vector3(2.5f - (float)(collectableOrder * 10 / totalCollectable), 1.5f, totalCollectable);
        //}
        return Vector3.zero;
    }


    void ZigZag()
    {

    }
}
