using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class tobyBox : CharacterBasic
{
    [SerializeField] private float speed = 5.0f;

    
    

    private SpriteRenderer spriteRenderer;
    

    

    


    public override void PlayerInput()
    {
        //Defines how we move based on the values in our input map
        movement = base.benStiller.Shmovement.LeftandRight.ReadValue<Vector2>();
        //Shows our inputs in the console
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
            stun = .5f;
            reverse = (transform.position - other.transform.position);
        }
    }


}
