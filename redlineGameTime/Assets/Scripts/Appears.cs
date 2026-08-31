using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Appears : MonoBehaviour
{
    private BenStiller benStiller;
    private Button toddHowad;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        benStiller.Enable();
    }

    private void OnDisable()
    {
        benStiller.Disable();
    }

    private void Update()
    {
        Appear();
    }

    private void Appear()
    {
        if ((benStiller.Combat.Attack.IsPressed())&&spriteRenderer.enabled == true)
        {
            spriteRenderer.enabled = false;
        }
        else if((benStiller.Combat.Attack.IsPressed()) && spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;
        }
    }
}
