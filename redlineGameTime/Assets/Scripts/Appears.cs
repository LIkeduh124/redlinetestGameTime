using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Appears : MonoBehaviour
{
    private BenStiller benStiller;
    private Button toddHowad;
    private SpriteRenderer spriteRenderer;
    private float time;
    private bool checker;

    private void Awake()
    {
        benStiller = new BenStiller();
        spriteRenderer = GetComponent<SpriteRenderer>();
        toddHowad = GetComponent<Button>();
        checker = false;
        time = 0.0f;
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
        //CheckHeld();
        Debug.Log(time);
        
    }

    private void Appear()
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

        if((time == 0)&&(benStiller.Combat.Attack.IsPressed()))
        {
            spriteRenderer.enabled = true;
            time =3.0f;
        }
        else if(time <= 0)
        {
            spriteRenderer.enabled = false;
            time = 0.0f;
        }
        else if((time<=3.0)&&(time>0))
        {
            time -= Time.deltaTime;
        }
        
    }

    /*
    private void CheckHeld()
    {
        if(benStiller.Combat.Attack.IsPressed())
        {
            checker = true;
        }
        else
        {
            checker = false;
        }

    }
    */
}
