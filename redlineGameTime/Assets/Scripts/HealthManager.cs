using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    //set variables for health and size. (height goes unchanged but is added to maintain its appearance.
    public float Health, MaxHealth, Width, Height;
    //serialized fields for rec transform
    [SerializeField]
    private RectTransform healthBar;

    public void Awake()
    {
        
        SetMaxHealth(MaxHealth);
    }

    public void SetMaxHealth(float maxHealth)
    {
        //sets the health value to the MaxHealth
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;

        float newWidth = (Health / MaxHealth) * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);

    }
}
