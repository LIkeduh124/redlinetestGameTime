using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] private Transform opponent;




    private void Update()
    {
        if(opponent== null)
        {
            return;
            //do NOTHING if nothing
        }

        if (opponent.position.x > opponent.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //if the enemy is facing the right of the player.
        }
        if (opponent.position.x < opponent.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //if the enemy is facing the left of the player.
        }
    }


}
