using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class danielMove : CharacterBasic
{


    



    public override void PlayerInput()
    {
        base.movement = base.benStiller.PlayerTwo.Movement.ReadValue<Vector2>();
        reverse = -(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((((collision.gameObject.CompareTag("Floor")))))
        {
            Debug.Log(collision.gameObject.name);

        }
        else if ((collision.gameObject.CompareTag("DanielHitbox")))

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
        if (!(other.CompareTag("DanielHitbox")))
        {
            stun = .5f;
            reverse = (other.GetComponent<Transform>().ReadValue<Vector2>() - transform.ReadValue<Vector2>());
        }
    }

}
