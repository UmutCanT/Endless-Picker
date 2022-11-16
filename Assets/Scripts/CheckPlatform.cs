using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour
{
    [SerializeField] LevelPlatform levelPlatform;
    int collectableCount;
    bool isCheking = false;
    float checkTime = 2.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (!isCheking)
            {
                StartCoroutine(CheckCollectableCount());
            }
            collectableCount++;
        }
    }
    void OnEnable()
    {
        collectableCount = 0;
    }

    IEnumerator CheckCollectableCount()
    {
        isCheking = true;
        yield return new WaitForSeconds(checkTime);
        if (collectableCount >= levelPlatform.RequiredColletablesToPass)
        {
            levelPlatform.PassGranted();
        }
        isCheking = false;
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
