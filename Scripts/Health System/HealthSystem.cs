using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;

    public float invincibleTime = 1.0f;
    private bool isInvincible;
    private float coolDownTime;

    public Slider healthBar;
    public event Action playerInjured;
    public event Action playerDead;
    public event Action playerNormal;

    private void Update()
    {
        healthBar.value = health;
    }

    public void HealthUpdate(int hP)
    {
        health += hP;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health < 0) 
        {
            health = 0;
            return;
        }
        isInvincible = true;
        coolDownTime = invincibleTime;
        HealthCheck();
    }

    private void OnTriggerStay(Collider other)
    {
        Timer();
        if (!isInvincible)
        {

            if (other.tag == "Damage")
            {
                HealthUpdate(-5);
            }
            if (other.tag == "Heal")
            {
                HealthUpdate(10);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            HealthUpdate(-5);
        }
    }
    void Timer()
    {
        if (isInvincible)
        {
            coolDownTime -= Time.deltaTime;
            if (coolDownTime < 0)
            {
                isInvincible = false;
            }
        }
    }
    void HealthCheck()
    {
        if (health < 40)
        {
            playerInjured?.Invoke();
            if (health <= 0)
            {
                playerDead?.Invoke();
            }
        }
        else
        {
            playerNormal?.Invoke();
        }
    }
    
}
