using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTrackingWave : ProcessSlider
{
    public float valueText; 

    public virtual void Slidering(int numDogCurrent, int numDogMax)
    {
        valueText = (float)numDogCurrent / (float)numDogMax * 100;
        slider.value = valueText;
    }
}
