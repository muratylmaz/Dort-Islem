using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VibrationManager
{
    public static void Vibrate()
    {
        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            Haptic.VibrateNormal();
        }
    }
}
