using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject playerNormalUI;
    [SerializeField] GameObject playerBonusUI;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI partText;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] Level level;


    void Start()
    {
        LevelUiUpdate();
        PartUiUpdate();
    }

    void OnEnable()
    {
        GameManager.OnPartUpdate += PartUiUpdate;
        GameManager.OnLevelUpdate += LevelUiUpdate;
    }

    void OnDisable()
    {
        GameManager.OnPartUpdate -= PartUiUpdate;
        GameManager.OnLevelUpdate -= LevelUiUpdate;
    }

    void BonusJumpUI()
    {
        playerNormalUI.SetActive(false);
        playerBonusUI.SetActive(true);
    }

    void LevelUiUpdate()
    {
        levelText.text = string.Format("Level: {0}", level.CurrentLevel); 
    }

    void PartUiUpdate()
    {
        partText.text = string.Format("Part: {0}", level.CurrentPart);
    }
}
