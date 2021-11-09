using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSettings : MonoBehaviour
{
    [System.NonSerialized]
    public static int playerHealthStart = 10;
    [System.NonSerialized]
    public static int cactiOnScreenStart = 0;
    [System.NonSerialized]
    public static int cactiAllowed = 10;
    [System.NonSerialized]
    public static int waterAmountStart = 5;
    [System.NonSerialized]
    public static int scoreTotalStart = 0;
    [System.NonSerialized]
    public static float secondsToMaxDifficulty = 120;
    [System.NonSerialized]
    public static float minSpeed = 0.5F;
    [System.NonSerialized]
    public static float maxSpeed = 3;
}
