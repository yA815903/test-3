using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int attackDamage = 5;  // Set enemy attack damage
    public float attackRange = 1.5f;  // Enemy attack range
    public LayerMask playerLayer;

    public void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= attackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
}
