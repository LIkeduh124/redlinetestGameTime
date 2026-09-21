using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterBasic : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    protected float allSpeed;
    [SerializeField] float weight = 3.0f;
    protected BenStiller benStiller;
    protected Vector2 movement, reverse;
    //rigidBody2d
    protected bool yes, no, death, block;
    protected Transform transform;
    protected Rigidbody2D rigidbody;
    protected PolygonCollider2D polygonCollider;
    public float stun;
   

    SpriteRenderer spriteRenderer;
    public void Awake()
    {
        yes = true;
        no = false;
        block = no;
        death = no;
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        stun = 0.0f;
        transform = GetComponent<Transform>();
        allSpeed = speed;
        reverse = -(movement);

    }

    public void OnEnable()
    {
        benStiller.Enable();
    }

    public void OnDisable()
    {
        benStiller.Disable();
    }

    public void Update()
    {
        if ((stun <= 0.0f)||block)
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
        else
        {
            KnockBack();
        }
    }
    public void Move(float speed)
    {
        if(!(movement = Vector2.Left))
        {
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            rigidbody.MovePosition(rigidbody.position + movement * (speed/2)* Time.fixedDeltaTime);
        }
        
    }

    
    public void KnockBack()
    {
        rigidbody.MovePosition(rigidbody.position + reverse * speed * Time.fixedDeltaTime);
    }
}
