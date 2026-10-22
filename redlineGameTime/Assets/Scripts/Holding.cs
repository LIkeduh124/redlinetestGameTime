using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UIElements;
public class Holding : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Sprite confed;
    public static Sprite allConfed;
    [SerializeField] Sprite union;
    public static Sprite allUnion;

    private void Awake()
    {
        allConfed = confed;
        allUnion = union;
    }
}
