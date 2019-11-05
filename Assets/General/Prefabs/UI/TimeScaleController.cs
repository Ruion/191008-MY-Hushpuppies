﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleController : GameSettingEntity
{
    public Slider slider;

    public void ChangeTimeScale()
    {
        Time.timeScale = slider.value;
    }
}
