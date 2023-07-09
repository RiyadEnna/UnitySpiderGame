using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(int health){
        Debug.Log(health);
        slider.maxValue=health;
        slider.value = health;
    }

    public void SetCurrentHealth(int currentHealth){
        Debug.Log(currentHealth);
        slider.value = currentHealth;
    }

}