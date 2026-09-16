using Unity.VisualScripting;
using UnityEngine;

public class WallMode : Appears
{

    private Rigidbody2D rigidbody;
    private BoxCollider2D polygonCollider;
    private SpriteRenderer spriteRenderer;
    private Transform joey;
    private BenStiller benStiller;
    private float time;
    private bool checker;
    private Vector2 og;
    private Vector2 move;

    private void Awake()
    {
        polygonCollider = GetComponent<BoxCollider2D>();
        polygonCollider.enabled = false;
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
        checker = false;
        time = 0.0f;
        spriteRenderer.enabled = false;
        now = og;
        next.x = now.x + 1;
        next.y = now.y + 1;
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
        Appear();
    }

    

    protected override void Appear()
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

        if ((time == 0) && (benStiller.Combat.Attack.IsPressed()))
        {
            spriteRenderer.enabled = true;
            polygonCollider.enabled = true;
            time = 3.0f;
            transform.position = og;
        }
        else if (time <= 0)
        {
            spriteRenderer.enabled = false;
            polygonCollider.enabled = false;
            time = 0.0f;
        }
        else if ((time <= 3.0) && (time > 0))
        {
            time -= Time.deltaTime;
            Move(5);
            
        }

    }

    public void Move(float speed)
    {
        transform.position = ((next) * speed * Time.fixedDeltaTime);
        now = next;
        next.x += 1;
        next.y += 1;
    }
}
