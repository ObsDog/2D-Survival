using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival : MonoBehaviour
{
    public Animator animator;

    [Header("Player Hunger")]
    public float MaxHunger = 100f;
    public float Hunger = 0f;
    public float HungerOT = 0.65f;
    public Slider HungerSlider;

    [Header("Player Thirst")]
    public float MaxThirst = 100f;
    public float Thirst = 0f;
    public float ThirstOT = 0.08f;
    public Slider ThirstSlider;

    [Header("Player Health")]
    public float MaxHealth = 100f;
    public float currentHealth;
    public Slider HealthSlider;


    private void Start()
    {
        currentHealth = MaxHealth;
    }

    void Update()
    {
        Hunger = Hunger - HungerOT * Time.deltaTime;
        Thirst = Thirst - ThirstOT * Time.deltaTime;

        UpdateSlider();

        if(Hunger <= 0)
        {
            Hunger = 0;
        }
        if(Thirst <= 0)
        {
            Thirst = 0;
        }
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
    
    public void UpdateSlider()
    {
        HungerSlider.value = Hunger / MaxHunger;
        ThirstSlider.value = Thirst / MaxThirst;
        HealthSlider.value = currentHealth / MaxHealth;
    }

    public void PlayerHealth(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            GetComponent<GameOverPerson>().TakeDeath();
        }
    }
}
