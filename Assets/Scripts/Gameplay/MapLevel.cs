using UnityEngine;
using System.Collections;

public class MapLevel : MonoBehaviour
{
    public enum Level
    {
        none,
        level_001,
        level_002,
        level_003,
        level_004,
        level_005,
        level_006,
        level_007,
        level_008,
        level_009,
        level_010,
        level_011,
        level_012,
        level_013,
        level_014,
        level_015,
        level_016,
        level_017,
        level_018,
        level_019,
        level_020,
    }

    public static string[] LevelNames =
    {
        "",
        "level_001",
        "level_002",
        "level_003",
        "level_004",
        "level_005",
        "level_006",
        "level_007",
        "level_008",
        "level_009",
        "level_010",
        "level_011",
        "level_012",
        "level_013",
        "level_014",
        "level_015",
        "level_016",
        "level_017",
        "level_018",
        "level_019",
        "level_020",
    };

    public static string[] NiceLevelNames =
{
        "",
        "Level 1",
        "Level 2",
        "Level 3",
        "Level 4",
        "Level 5",
        "Level 6",
        "Level 7",
        "Level 8",
        "Level 9",
        "Level 10",
        "Level 11",
        "Level 12",
        "Level 13",
        "Level 14",
        "Level 15",
        "Level 16",
        "Level 17",
        "Level 18",
        "Level 19",
        "Level 20",
    };

    public static string LevelToLoad = "level_001";

    public static void SetLevelToLoad(Level TheLevel)
    {
        LevelToLoad = LevelNames[(int)TheLevel];
    }
}
