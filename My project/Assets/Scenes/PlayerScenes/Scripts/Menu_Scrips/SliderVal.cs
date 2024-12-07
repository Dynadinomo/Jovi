using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVal : MonoBehaviour
{
    public float sliderToVal(Slider slider)
    {
        return slider.value;
    }
    public void valToSlider(Slider slider, float val)
    {
        slider.value = val;
    }
}
