using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject capsule;
    [SerializeField] GameObject cylinder;
    [SerializeField] Rigidbody rb;
    const float forceMult = 0.45f;
    //[SerializeField] GameObject cone;

    public void OnSpawn(float scale, Vector3 pos)
    {
        transform.localScale = Vector3.one * scale;
        transform.position = pos;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerForce"))
        {
            rb.AddForce(Vector3.forward * forceMult, ForceMode.Impulse);
        }
    }

    public void CollectableTypeChanger(CollectableTypes collectableType)
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
