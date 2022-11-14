using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField] int level;
    [SerializeField] LevelTypes[] levelPart1;
    [SerializeField] LevelTypes[] levelPart2;
    [SerializeField] LevelTypes[] levelPart3;
    LevelTypes[] selectedLevel = new LevelTypes[3];
    int[] lastLevel = new int[3];

    public LevelTypes[] SelectedLevel { get => selectedLevel; set => selectedLevel = value; }
    public int[] LastLevel { get => lastLevel; set => lastLevel = value; }

    public void GenerateLevel()
    {
        int part1 = Random.Range(0, levelPart1.Length);
        lastLevel[0] = part1;
        selectedLevel[0] = levelPart1[part1];

        int part2 = Random.Range(0, levelPart2.Length);
        lastLevel[1] = part2;
        selectedLevel[1] = levelPart2[part2];

        int part3 = Random.Range(0, levelPart3.Length);
        lastLevel[2] = part3;
        selectedLevel[2] = levelPart3[part3];
    }
}