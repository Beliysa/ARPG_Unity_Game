using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider; //this will store our slider in health bar
    public Gradient gradient; //to change the color of our health bar
    public Image fill;

    public void SetMaxHealth(int health)
    {
       // slider.maxValue = health;
       // slider.value = health;// to sure that our slider starts from the max amount of health
        fill.color = gradient.Evaluate(1f); //set green color at our max
    }
    
    //to add a color from our gradient at a specific point 
    // this fun will set the health on that slider
    public void SetHealth(float health)
    {
        slider.value = health; //so after this, our script will find the slider that we drag it in the component in unity section and adjust the value to the one we set
        fill.color = gradient.Evaluate(slider.normalizedValue);//normalizedValue to normalize the value between 0-1

    }
}
