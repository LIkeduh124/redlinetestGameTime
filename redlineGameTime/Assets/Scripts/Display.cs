using UnityEngine;
using UnityEngine.UIElements;

public class Display : MonoBehaviour
{
    public float amount;
    private RectTransform rectTransform;
    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
        amount = rectTransform.sizeDelta.x;
    }

    
}
