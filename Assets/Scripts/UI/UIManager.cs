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

    void Start()
    {
        ShowOnStart();
    }

    private void OnEnable()
    {
        BonusCheck.OnLevelComplete += ShowLevelCompleteScreen;
        LevelPlatform.OnFail += ShowFailScreen;
        Player.OnChangeToNormal += HideAllPanels;
    }

    private void OnMouseDown()
    {
        HideAllPanels();
    }

    private void OnDisable()
    {
        BonusCheck.OnLevelComplete -= ShowLevelCompleteScreen;
        LevelPlatform.OnFail -= ShowFailScreen;
        Player.OnChangeToNormal -= HideAllPanels;

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

    void ShowLevelCompleteScreen()
    {
        levelCompletePanel.SetActive(true);
    }

    public void ShowInBetweenLevels()
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

}
