using UnityEngine;

public class BackWall : Appears
{


    



    

    protected override void Update()
    {

        Appear();
        dad = this.allFather.GetComponent<Transform>().position;


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

        if ((time == 0) && (base.benStiller.Combat.Attack.IsPressed()))
        {


            Debug.Log(base.benStiller.Combat.Attack.IsPressed());
            spriteRenderer.enabled = true;
            polygonCollider.enabled = true;
            time = 1.0f;

        }
        else if (time <= 0)
        {

            spriteRenderer.enabled = false;
            polygonCollider.enabled = false;
            time = 0.0f;
            transform.position = dad - distance;

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


}
