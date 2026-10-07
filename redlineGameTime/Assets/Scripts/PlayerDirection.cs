using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] private Transform opponent;
    private SpriteRenderer playerSprite;


        private void Awake()
    {
        playerSprite  = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(opponent== null)
        {
            return;
            //do NOTHING if nothing
        }

        if (opponent.position.x > transform.position.x)
        {
            playerSprite.flipX = false;
        }
        if (opponent.position.x < transform.position.x)
        {
            Debug.Log("sprite flipped!");
            playerSprite.flipX = true;
        }
    }


}
