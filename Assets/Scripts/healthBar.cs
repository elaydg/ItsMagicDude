using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    void Start()
    {
        health = maxHealth; 
    }
    void Update()
    {
        if (healthSlider.value != health) 
        {
            healthSlider.value = health;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }
    }

    void takeDamage(float damage) 
    {
        health -= damage;
    }
}
