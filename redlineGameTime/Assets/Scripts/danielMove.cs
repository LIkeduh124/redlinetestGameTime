using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class danielMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private BenStiller benStiller;
    private Vector2 movement, reverse, knockBackDirection;
    //rigidBody2d

    private Rigidbody2D rigidbody;
    private PolygonCollider2D polygonCollider;
    private float stun;


    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        stun = 0.0f;

        reverse = -(movement);
        


    }

    private void OnEnable()
    {
        benStiller.Enable();
    }

    private void OnDisable()
    {
        benStiller.Disable();
    }

    private void Update()
    {
        if (stun <= 0.0f)
        {
            PlayerInput();
            stun = 0.0f;
            rigidbody.gravityScale = 1.0f;
        }
        else
        {
            rigidbody.gravityScale = 0.0f;
            stun -= Time.deltaTime;
            //Debug.Log(stun);

        }

    }

    private void FixedUpdate()
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

    private void PlayerInput()
    {
        //Defines how we move based on the values in our input map
        movement = benStiller.PlayerTwo.Movement.ReadValue<Vector2>();
        //Shows our inputs in the console
        
        //Debug.Log(movement);
    }

    private void Move(float speed)
    {
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
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
        knockBackDirection =
        ((Vector2)transform.position - (Vector2)other.transform.position).normalized;
        stun = .5f;
        
    }

    private void KnockBack()
    {
        rigidbody.MovePosition(rigidbody.position + knockBackDirection * speed * Time.fixedDeltaTime);
    }
}
