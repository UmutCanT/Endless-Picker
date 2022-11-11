using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour
{
    [SerializeField] LevelPlatform levelPlatform;
    int collectableCount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            collectableCount++;
            CheckCollectable();
        }
    }
    void OnEnable()
    {
        collectableCount = 0;
    }

    void CheckCollectable()
    {
        if (collectableCount >= levelPlatform.RequiredColletablesToPass)
        {
            StartCoroutine(levelPlatform.PassGranted());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
