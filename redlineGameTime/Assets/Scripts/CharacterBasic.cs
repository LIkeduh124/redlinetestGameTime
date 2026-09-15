using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterBasic : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    BenStiller benStiller;
    Vector2 movement, reverse;
    //rigidBody2d

    Rigidbody2D rigidbody;
    PolygonCollider2D polygonCollider;
    public float stun;


    SpriteRenderer spriteRenderer;
    public void Awake()
    {
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        stun = 0.0f;

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

    public void PlayerInput()
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
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((((collision.gameObject.CompareTag("Floor")))))
        {
            Debug.Log(collision.gameObject.name);

        }
        else
        {
            stun = .5f;
        }
    }
    public void KnockBack()
    {
        rigidbody.MovePosition(rigidbody.position + reverse * speed * Time.fixedDeltaTime);
    }
}
