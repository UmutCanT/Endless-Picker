using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject levelFailedPanel;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] GameObject title;

    void Awake()
    {
        HideAllPanels();
    }

    void ShowOnStart()
    {
        startScreen.SetActive(true);
        title.SetActive(true);
    }

    void ShowFailScreen()
    {
        levelFailedPanel.SetActive(true);
    }

    void ShowLevelCompleteSsreen()
    {
        levelCompletePanel.SetActive(true);
    }

    void ShowInBetweenLevels()
    {
        startScreen.SetActive(true);
        title.SetActive(false);
    }

    void HideAllPanels()
    {
        startScreen.SetActive(false);
        title.SetActive(false);
        levelCompletePanel.SetActive(false);
        levelFailedPanel.SetActive(false);
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
