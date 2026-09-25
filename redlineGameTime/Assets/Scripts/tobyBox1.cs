using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class tobyBox1 : CharacterBasic
{


    public float health, maxHealth;
    private bool isHeld = false;

    private SpriteRenderer spriteRenderer;

    

    public void SetHealth(float healthChange)
    {
        
        //changes the health into the amount thats change

        
        allHealth.SetHealth(healthChange);
        
    }







    public override void PlayerInput()
    {
        //Defines how we move based on the values in our input map
        movement = base.benStiller.Shmovement.LeftandRight.ReadValue<UnityEngine.Vector2>();
        //Shows our inputs in the console
        if(movement == UnityEngine.Vector2.left)
        {
            block = true;
        }
        else
        {
            block = false;
        }

        if((forHealth.HPTest.LowerHealth.IsPressed())&&(isHeld ==false))
        {
            isHeld = true;
            SetHealth(-20);
        }
        else if(!(forHealth.HPTest.LowerHealth.IsPressed()))
        {
            isHeld= false;
        }

        reverse = -(movement);
        
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((((collision.gameObject.CompareTag("Floor")))))
        {
            Debug.Log(collision.gameObject.name);

        }
        else if (((collision.gameObject.CompareTag("AbeHitbox"))) ||(collision.collider.isTrigger))
            
        {
            Debug.Log(collision.gameObject.name);
        }
        else
        {
            stun = .5f;
        }

        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.CompareTag("AbeHitbox")))
        {
            SetHealth(-20);
            stun = .5f;
            reverse = (transform.position - other.transform.position);
        }
    }

    

}
