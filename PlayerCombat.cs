using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int attackDamage = 10;  // Set the damage of the player’s attack
    public float attackRange = 2.0f;  // The range of the attack
    public LayerMask enemyLayer;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Left mouse button or a key
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
}
