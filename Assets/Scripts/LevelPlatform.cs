using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlatform : MonoBehaviour
{
    [SerializeField] GameObject gate;
    [SerializeField] GameObject progressGround;
    int requiredColletablesToPass =  1;
    float waitTimeToPass = .5f;

    public int RequiredColletablesToPass { get => requiredColletablesToPass; set => requiredColletablesToPass = value; }

    public IEnumerator PassGranted()
    {
        yield return new WaitForSeconds(waitTimeToPass);
        gate.SetActive(false);
        progressGround.SetActive(true);
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
