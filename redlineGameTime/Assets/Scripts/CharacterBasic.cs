using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterBasic : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    protected float allSpeed;
    [SerializeField] float weight = 3.0f;
    protected BenStiller1 benStiller;
    protected Vector2 movement, reverse;
    //rigidBody2d
    public bool yes, no, death, block;
    protected Transform transform;
    protected Rigidbody2D rigidbody;
    protected PolygonCollider2D polygonCollider;
    public float stun;
    protected BenStiller forHealth;
    [SerializeField] HealthManager healthBar;
    protected HealthManager allHealth;



    SpriteRenderer spriteRenderer;
    public void Awake()
    {
        yes = true;
        no = false;
        block = no;
        death = no;
        benStiller = new BenStiller1();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        stun = 0.0f;
        transform = GetComponent<Transform>();
        allSpeed = speed;
        reverse = -(movement);
        allHealth = healthBar;
        forHealth = new BenStiller();
        
        

    }

    public void OnEnable()
    {
        benStiller.Enable();
        forHealth.Enable();
    }

    public void OnDisable()
    {
        benStiller.Disable();
        forHealth.Disable();
    }

    public void Update()
    {
        if (stun <= 0.0f)
        {
            PlayerInput();
            stun = 0.0f;
            rigidbody.gravityScale = weight;
        }
        else
        {
            rigidbody.gravityScale = 0.0f;
            stun -= Time.deltaTime;
            //Debug.Log(stun);

        }

    }

    public virtual void PlayerInput()
    {
        reverse = -movement;
    }

    public void FixedUpdate()
    {
        if (stun <= 0.0f)
        {
            Move(speed);
        }
        else if(!(block))
        {
            KnockBack();
        }
    }
    public void Move(float speed)
    {
        if(!(movement == Vector2.left))
        {
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            rigidbody.MovePosition(rigidbody.position + movement * (speed/4)* Time.fixedDeltaTime);
        }
        
    }

    
    public void KnockBack()
    {
        rigidbody.MovePosition(rigidbody.position + reverse * speed * Time.fixedDeltaTime);
    }
}
