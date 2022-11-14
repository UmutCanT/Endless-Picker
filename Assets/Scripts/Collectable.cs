using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    CollectableTypes collectableType;

    public CollectableTypes CollectableType { get => collectableType; set => collectableType = value; }

    void OnSpawn(float scale, float posX, float posY, float posZ)
    {
        transform.localScale = Vector3.one * scale;
        transform.position = new Vector3(posX, posY, posZ);
    }
}
