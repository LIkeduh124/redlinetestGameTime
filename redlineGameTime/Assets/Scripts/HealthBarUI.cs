using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public float MaxHealth, Health, GrayHealth, Width, Height;

    [SerializeField]
    private RectTransform healthbar;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = (health / MaxHealth) * Width;

        healthbar.sizeDelta = new Vector2(newWidth,Height);
    }
}
