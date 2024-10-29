using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public float maxStamina = 100f;
    public float staminaDecreaseRate = 10f;
    public float staminaRecoveryRate = 5f;

    private float currentStamina;
    public Slider staminaSlider;

    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        staminaSlider.value = currentStamina;
    }

    public void RecoverStamina()
    {
        currentStamina += staminaRecoveryRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        staminaSlider.value = currentStamina;
    }
    public void RestoreStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        staminaSlider.value = currentStamina;
    }
    public bool HasStamina(float amount)
    {
        return currentStamina >= amount;
    }
}
