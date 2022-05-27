using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxShield(int shield)
    {
        
        slider.maxValue = shield;
        slider.value = shield;

        //fill.color = gradient.Evaluate(1f);
    }
    public void SetShield(int shield)
    {
        slider.value = shield;
        // we use normalied value because the gradient goes from 0 to 1 and our character
        // life goes to 0 to 100, so we want to normalize to change the gradient in the right way
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
