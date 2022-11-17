using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour
{
    [SerializeField] LevelPlatform levelPlatform;
    int collectableCount;
    bool isCheking = false;
    float checkTime = 2f;

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
        else
        {
            levelPlatform.PassDenied();
        }
        isCheking = false;
    }
}
