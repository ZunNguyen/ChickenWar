using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTrackingWave : ProcessSlider
{
    public virtual void Slidering(int numDogCurrent, int numDogMax)
    {
        float valueText = numDogCurrent / numDogMax * 100;
        slider.value = valueText;
    }
}
