using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    //set variables for health and size. (height goes unchanged but is added to maintain its appearance.
    public float Health, MaxHealth, Width, Height, currentHealth;
    //serialized fields for rec transform
    [SerializeField]
    private RectTransform healthBar;
    private float maxWidth;
    

    public void Awake()
    {
        Height = 50;
        Width = 200;
        Debug.Log(healthBar.sizeDelta.x);
        
        maxWidth = Width;
        
        Debug.Log(maxWidth);

        SetMaxHealth(MaxHealth);
        currentHealth = MaxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        //sets the health value to the MaxHealth
        MaxHealth = maxHealth;
        
        
    }

    public void SetHealth(float health)
    {

        if (!(Health <= 0))
        {
            Debug.Log(Health);
            if ((currentHealth + health) >= 0)
            {
                Health = health + currentHealth;
            }
            else if ((health + currentHealth) < 0)
            {
                Health = 0;
            }

            currentHealth = Health;
            Debug.Log(Health);
            float healthPercentage = (Health / MaxHealth);
            float newWidth = (healthPercentage * maxWidth);

            healthBar.sizeDelta = new Vector2(newWidth, Height);
        }

    }
}
