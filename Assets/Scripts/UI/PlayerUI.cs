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
        
    }

    void OnDisable()
    {
        
    }
    
    void BonusJumpUI()
    {
        levelText.gameObject.SetActive(false);
    }

    void LevelUiUpdate()
    {
        levelText.text = string.Format("Level: {0}", level.CurrentLevel); 
    }

    void PartUiUpdate()
    {
        partText.text = string.Format("Part: {0}", level.Part);
    }
}
