using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    int playerLevel;
    int levelPart1;
    int levelPart2;
    int levelPart3;
    [SerializeField] Level selectedLevel;
    readonly string levelKey = "LevelKey";
    readonly string levelpartKey1 = "partKey1";
    readonly string levelpartKey2 = "partKey2";
    readonly string levelpartKey3 = "partKey3";

    public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public Level SelectedLevel { get => selectedLevel; set => selectedLevel = value; }
    public int LevelPart1 { get => levelPart1; set => levelPart1 = value; }
    public int LevelPart2 { get => levelPart2; set => levelPart2 = value; }
    public int LevelPart3 { get => levelPart3; set => levelPart3 = value; }

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
        levelPart1 = PlayerPrefs.GetInt(levelpartKey1, 0);
        levelPart2 = PlayerPrefs.GetInt(levelpartKey2, 0);
        levelPart3 = PlayerPrefs.GetInt(levelpartKey3, 0);
    }
}
