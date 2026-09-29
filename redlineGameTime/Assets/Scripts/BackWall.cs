using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BackWall : Appears
{



   
    bool block, pressed;
    
    

    protected override void FixedUpdate()
    {
        dad = this.allFather.GetComponent<Transform>().position;
        Debug.Log("The time is " + time);
        Appear();
        

        

    }

    private void Update()
    {
        Debug.Log("");
    }


    protected override void Appear()
    {
      

        if (time <= 0)
        {

            spriteRenderer.enabled = false;
            polygonCollider.enabled = false;
            time = 0.0f;
            transform.position = dad - distance;
            pressed = false;

        }
        else if (time > 0)
        {
            spriteRenderer.enabled = true;
            polygonCollider.enabled = true;
            time -= Time.fixedDeltaTime;
            Debug.Log("Time is now " + time);
            Move(5.0f);

        }

    }

    protected virtual void Move(float speed)
    {

        rigidbody.MovePosition(rigidbody.position + Vector2.left * speed * Time.fixedDeltaTime);
        Debug.Log(Time.fixedDeltaTime);

    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("AbeLincoln"))
        {
            Debug.Log(other.gameObject.GetComponent<tobyBox1>().block);
            if(other.gameObject.GetComponent<tobyBox1>().block == true)
            {
                time = 0.0f;
            }
        }
    }

    */

}
