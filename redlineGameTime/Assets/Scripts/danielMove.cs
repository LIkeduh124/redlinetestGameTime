using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class danielMove : CharacterBasic
{


    private bool ownColor = !(GameData.Instance.sideCheck);



    public override void PlayerInput()
    {
        spriteRenderer.color = SetColor(!(GameData.Instance.sideCheck));
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
            reverse = (transform.position - other.transform.position);
        }
    }

}
