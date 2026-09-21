using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    //create variables to set health and max health
    public float Health, MaxHealth;

    [SerializeField]
    private HealthManager healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }
    
    public void setHealth(float healthChange)
    {
        //changes the health into the amount thats changed
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }

    private float speed = 5.0f;
    private InputAction action;
    private BenStiller benStiller;
    private Vector2 movement, reverse;
    //rigidBody2d

    private Rigidbody2D rigidbody;
    private PolygonCollider2D polygonCollider;
    private float stun;
    

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        
        benStiller = new BenStiller();

        //Assigns the action variable to the lower health bindings
        action = benStiller.HPTest.LowerHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        stun = 0.0f;
        
        reverse = -(movement);
        
    }

    private void OnEnable()
    {
        benStiller.Enable(); 
        action.performed += OnPress;
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
        /*
        if (action.performed() == true)
        {
            setHealth(-20f);
            Debug.Log("Player1 took Damage!");
        }
        if (Input.GetKeyDown("f"))
        {
            setHealth(20f);
            Debug.Log("Player1 Healed!");
        }
        */
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
        movement = benStiller.Shmovement.LeftandRight.ReadValue<Vector2>();
        //Shows our inputs in the console
        reverse = -(movement);
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
        else if ((collision.gameObject.CompareTag("PhillipeHitbox")))
        {
            Debug.Log(collision.gameObject.name);
        }
        else
        {
            stun = .5f;
        }

        
        
    }

    private void OnPress(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("duuuude");
        setHealth(-20);
    }
    private void KnockBack()
    {
        rigidbody.MovePosition(rigidbody.position + reverse * speed * Time.fixedDeltaTime);
    }
}
