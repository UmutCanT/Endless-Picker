using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField] int level;
    [SerializeField] LevelTypes[] levelTypes;

    public LevelTypes[] LevelTypes { get => levelTypes; set => levelTypes = value; }
}