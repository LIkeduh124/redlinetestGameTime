using UnityEngine;
using UnityEngine.UIElements;

public class Display : MonoBehaviour
{
    public float amount;
    private RectTransform rectTransform;
    protected Rigidbody2D rigidbody;
    protected CircleCollider2D polygonCollider;
    protected SpriteRenderer spriteRenderer;
    protected Transform joey;
    [SerializeField] GameObject father;
    public Vector2 og, next, now;
    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
        amount = rectTransform.sizeDelta.x;
    }

    
}
