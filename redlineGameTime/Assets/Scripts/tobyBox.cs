using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private BenStiller benStiller;
    private Vector2 movement;
    //rigidBody2d

    private Rigidbody2D rigidbody;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
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
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        //Defines how we move based on the values in our input map
        movement = benStiller.Shmovement.LeftandRight.ReadValue<Vector2>();
        //Shows our inputs in the console
        Debug.Log(movement);
    }

    private void Move()
    {
       rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
    }
}
