using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void setMaxH(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health; //Starts at 100 Health
    }

    public void setHealth(int health)
    {
        healthSlider.value = health;
    }
}
