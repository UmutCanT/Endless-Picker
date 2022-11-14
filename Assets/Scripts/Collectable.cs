using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject capsule;
    [SerializeField] GameObject cylinder;
    //[SerializeField] GameObject cone;

    CollectableTypes collectableType;

    public CollectableTypes CollectableType { get => collectableType; set => collectableType = value; }

    void OnSpawn(float scale, float posX, float posY, float posZ)
    {
        transform.localScale = Vector3.one * scale;
        transform.position = new Vector3(posX, posY, posZ);
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        cube.SetActive(false);
        cylinder.SetActive(false);
        capsule.SetActive(false);
        sphere.SetActive(false);
    }

    public void CollectableTypeChanger()
    {
        switch (collectableType)
        {
            case CollectableTypes.Capsule:
                capsule.SetActive(true);
                break;
            case CollectableTypes.Cube:
                cube.SetActive(true);
                break;
            case CollectableTypes.Cone:
                //cone.SetActive(false);
                break;
            case CollectableTypes.Sphere:
                sphere.SetActive(true);
                break;
            case CollectableTypes.Cylinder:
                cylinder.SetActive(true);
                break;
            default:
                break;
        }
    }
}
