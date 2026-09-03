using UnityEngine;

public class AttackMe : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private CircleCollider2D polygonCollider;
    private SpriteRenderer spriteRenderer;
    private Transform joey;
    [SerializeField] GameObject father;
    private void Awake()
    {
        
        polygonCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        joey = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        joey.position = father.GetComponent<Transform>().position;
    }
}
