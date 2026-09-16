using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Appears : MonoBehaviour
{
    protected BenStiller benStiller;
    protected Button toddHowad;
    protected SpriteRenderer spriteRenderer;
    protected float time;
    protected bool checker;
    protected Rigidbody2D rigidbody;
    protected CircleCollider2D polygonCollider;
   
    protected Transform joey;
    [SerializeField] GameObject father;
    protected Vector2 og, next, now;


    protected virtual void Awake()
    {
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
        toddHowad = GetComponent<Button>();
        checker = false;
        time = 0.0f;
        og = transform.position;
        now = og;
        rigidbody = GetComponent<RigidBody2D>();
        rigidbody.gravityScale = 0.0f;

    }

    protected virtual void OnEnable()
    {
        benStiller.Enable();
    }

    protected void OnDisable()
    {
        benStiller.Disable();
    }

    protected virtual void Update()
    {
        Appear();
        //CheckHeld();
        
        
    }

    protected virtual void Appear()
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

        if((time == 0)&&(benStiller.Combat.Attack.IsPressed()))
        {
            spriteRenderer.enabled = true;
            time =3.0f;
        }
        else if(time <= 0)
        {
            spriteRenderer.enabled = false;
            time = 0.0f;
        }
        else if((time<=3.0)&&(time>0))
        {
            time -= Time.deltaTime;
            
        }
        
    }

    /*
    private void CheckHeld()
    {
        if(benStiller.Combat.Attack.IsPressed())
        {
            checker = true;
        }
        else
        {
            checker = false;
        }

    }
    */
}
