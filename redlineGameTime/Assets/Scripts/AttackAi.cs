using UnityEngine;

public class AttackAi : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public float detectionRange = 8f;
    [SerializeField] public float attackRange = 3f;
    [SerializeField] public float attackCooldown = 1f;
    [SerializeField] public GameObject attack;

    private float nextAttackTime;
    private BackWall backWall;
    // Update is called once per frame

    public void Awake()
    {
        //Debug.Log(attack);
        backWall = GetComponent<BackWall>();
    }
    void Update()
    {
        if (player == null)
        {
            return;
        }
        float distance = Vector2.Distance(transform.position, player.position);
                  
        //Debug.Log(distance);
        //Debug.Log(attackRange);
        if (distance <= attackRange)
        {
            EnemyAttack();
            

        }
    }
    private void EnemyAttack()
    {
        if (attack.GetComponent<BackWall>().time <= 0)
        {
            attack.GetComponent<BackWall>().time = 1.0f;
        }

        Debug.Log("Enemy Hit!");
        
    }
}
