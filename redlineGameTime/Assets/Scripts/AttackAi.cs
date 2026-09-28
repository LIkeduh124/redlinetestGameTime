using UnityEngine;

public class AttackAi : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public float detectionRange = 8f;
    [SerializeField] public float attackRange = 1.5f;
    [SerializeField] public float attackCooldown = 1f;

    private float nextAttackTime;
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        float distance = Vector2.Distance(transform.position, player.position);
                  
        
        if (distance <= attackRange &&  Time.time >= nextAttackTime)
        {
            EnemyAttack();
            nextAttackTime = Time.time + attackCooldown;

        }
    }
    private void EnemyAttack()
    {
        tobyBox1 playerHealth = player.GetComponent<tobyBox1>();
        if (playerHealth != null)
        {
            playerHealth.SetHealth(-20);
        }

        Debug.Log("Enemy Hit!");
        
    }
}
