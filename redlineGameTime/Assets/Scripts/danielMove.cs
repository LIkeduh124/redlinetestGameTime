using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class danielMove : CharacterBasic
{


    

    public void SetHealth(float healthChange)
    {

        //changes the health into the amount thats change


        allHealth.SetHealth(healthChange);

    }

    public override void PlayerInput()
    {
        if (GameData.Instance != null) { spriteRenderer.sprite = SetColor(!(GameData.Instance.sideCheck)); }
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
            SetHealth(-20);
            stun = .5f;
            reverse = (transform.position - other.transform.position);
        }
    }

}
