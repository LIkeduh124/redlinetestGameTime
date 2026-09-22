using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BackWall : Appears
{



    private danielMove cobyBox;
    bool block, pressed;
    
    

    protected override void Update()
    {
        cobyBox = GetComponentInParent<danielMove>();
        Appear();
        dad = this.allFather.GetComponent<Transform>().position;

        block = cobyBox.block;

    }



    protected override void Appear()
    {
        /*
         * Toggleable
        if (((benStiller.Combat.Attack.IsPressed()) && spriteRenderer.enabled == true)&&(checker==false))
        {
            spriteRenderer.enabled = false;
        }
        else if (((benStiller.Combat.Attack.IsPressed()) && spriteRenderer.enabled == false) && (checker == false))
        {
            spriteRenderer.enabled = true;
        }
        */

        if (((time == 0) && (base.benStiller.Combat.Attarck.IsPressed()))&&pressed == false)
        {


            Debug.Log(base.benStiller.Combat.Attarck.IsPressed());
            spriteRenderer.enabled = true;
            polygonCollider.enabled = true;
            time = 1.0f;
            pressed = true;
            

        }
        else if (time <= 0)
        {

            spriteRenderer.enabled = false;
            polygonCollider.enabled = false;
            time = 0.0f;
            transform.position = dad - distance;
            pressed = false;

        }
        else if ((time <= 1.0) && (time > 0))
        {
            time -= Time.deltaTime;
            Move(5f);

        }

    }

    protected virtual void Move(float speed)
    {
        rigidbody.MovePosition(rigidbody.position + Vector2.left * speed * Time.fixedDeltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("AbeLincoln"))
        {
            Debug.Log(other.gameObject.name);
            if(other.gameObject.GetComponent<tobyBox>().block == true)
            {
                time = 0.0f;
            }
        }
    }

    

}
