using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Diagnostics;

public class Appears : MonoBehaviour
{
    protected BenStiller1 benStiller;
    protected Button toddHowad;
    protected SpriteRenderer spriteRenderer;
    protected float time;
    protected bool checker;
    protected Rigidbody2D rigidbody;
    protected CircleCollider2D circleCollider;
    protected BoxCollider2D polygonCollider;
   
    protected Transform joey;
    [SerializeField] GameObject father;
    protected GameObject allFather;
    protected Vector2 dad, son, distance;


    protected virtual void Awake()
    {
        benStiller = new BenStiller1();
        spriteRenderer = GetComponent<SpriteRenderer>();
        toddHowad = GetComponent<Button>();
        checker = false;
        time = 0.0f;
        polygonCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0.0f;
        allFather = father;
        dad = father.GetComponent<Transform>().position;
        son = GetComponent<Transform>().position;
        distance = dad - son;

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
