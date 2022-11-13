using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    int playerLevel;
    int playerPart;
    [SerializeField] Level selectedLevel;
    readonly string levelKey = "LevelKey";

    public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public Level SelectedLevel { get => selectedLevel; set => selectedLevel = value; }
    public int PlayerPart { get => playerPart; set => playerPart = value; }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else if(Instance != this)
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey(levelKey))
        {
            PlayerPrefs.SetInt(levelKey, 1);
            playerLevel = 1;
        }
        playerLevel = PlayerPrefs.GetInt(levelKey);

    }
}
