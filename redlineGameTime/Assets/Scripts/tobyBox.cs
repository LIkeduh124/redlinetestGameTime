using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private BenStiller benStiller;
    private Vector2 movement;
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
            Debug.Log(stun);
            KnockBack();
        }
        
    }

    private void FixedUpdate()
    {
        Move(speed);
        
    }

    private void PlayerInput()
    {
        //Defines how we move based on the values in our input map
        movement = benStiller.Shmovement.LeftandRight.ReadValue<Vector2>();
        //Shows our inputs in the console
        Debug.Log(movement);
    }

    private void Move(float speed)
    {
       rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.CompareTag("Floor")))
        {
            Move(-1*speed);
            stun = 3.0f;
        }
        
    }

    private void KnockBack()
    {
        rigidbody.MovePosition(-rigidbody.position);
    }
}
