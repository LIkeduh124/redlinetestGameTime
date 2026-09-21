using UnityEngine;

public class AttackMe : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    protected CircleCollider2D polygonCollider;
    protected SpriteRenderer spriteRenderer;
    protected Transform joey;
    [SerializeField] GameObject father;
    public Vector2 og, next, now;
    protected void Awake()
    {
        
        polygonCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        joey = GetComponent<Transform>();
        og = joey.position;
    }

   
}
