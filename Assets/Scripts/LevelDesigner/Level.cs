using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField] int currentLevel;
    [SerializeField] int part;
    [SerializeField] LevelTypes[] levelPart1;
    [SerializeField] LevelTypes[] levelPart2;
    [SerializeField] LevelTypes[] levelPart3;
    LevelTypes[] selectedLevel = new LevelTypes[3];
    int[] lastLevel = new int[3];
    int currentPart;

    public LevelTypes[] SelectedLevel { get => selectedLevel; set => selectedLevel = value; }
    public int[] LastLevel { get => lastLevel; set => lastLevel = value; }
    public int Part { get => part; set => part = value; }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int CurrentPart { get => currentPart; set => currentPart = value; }

    int Part1 => Random.Range(0, levelPart1.Length);
    int Part2 => Random.Range(0, levelPart2.Length);
    int Part3 => Random.Range(0, levelPart3.Length);

    public void GenerateLevel(int part1, int part2, int part3)
    {
        lastLevel[0] = part1;
        selectedLevel[0] = levelPart1[part1];

        lastLevel[1] = part2;
        selectedLevel[1] = levelPart2[part2];

        lastLevel[2] = part3;
        selectedLevel[2] = levelPart3[part3];
    }

    public void GenerateLevel()
    {
        GenerateLevel(Part1, Part2, Part3);
    }
}