using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KactiSettings : MonoBehaviour
{
    [System.NonSerialized]
    public static string[] cactiTypesArr = {"normal_cacti", "left_cacti", "right_cacti", "dead_cacti", "tumbleweed", "fire_cacti"};
    [System.NonSerialized]
    public static int[] spawnChanceArr = {        50,          67,            85,             93,           98,           100}; // spawnChance
    [System.NonSerialized]
    public static int[] cactiHealthArr = {        1,           1,             1,              1,            2,            4}; // cactiHealth
    [System.NonSerialized]
    public static int[] cactiPointsArr = {        1,           2,             2,              3,            4,            5}; // cactiPoints
}
