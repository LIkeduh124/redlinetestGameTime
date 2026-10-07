using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BackWall : Appears
{



   
    
    
    

    protected override void FixedUpdate()
    {
        
        Appear();
        dad = this.allFather.GetComponent<Transform>().position;
        Debug.Log("The time is " + time);

        

    }

    private void Update()
    {
        //Debug.Log("");
    }


    protected override void Appear()
    {
        Debug.Log("This is running");

        if (time <= 0)
        {

            spriteRenderer.enabled = false;
            polygonCollider.enabled = false;
            time = 0.0f;
            transform.position = dad - distance;
            

        }
        else
        {
            spriteRenderer.enabled = true;
            polygonCollider.enabled = true;
            time -= Time.fixedDeltaTime;
            Debug.Log("Time is now " + time);
            Move(5.0f);
            Debug.Log("Should be moving now");

        }

    }

    protected virtual void Move(float speed)
    {
        Debug.Log(speed);
        transform.position = (transform.position + Vector3.left*speed*Time.fixedDeltaTime);
        Debug.Log("Motion Detected");

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
