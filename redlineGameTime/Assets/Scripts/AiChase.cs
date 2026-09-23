using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//this checks distance betweem the Ai and the player.
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.forward;
        //this creates the Vector, MoveTowards. and directs the AI towards the character with each update.
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime);
        
    }
}
