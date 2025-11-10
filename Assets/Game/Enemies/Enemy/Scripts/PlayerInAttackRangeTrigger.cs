using UnityEngine;

public class PlayerInAttackRangeTrigger : MonoBehaviour
{
    private EnemyController enemyController;
    [SerializeField] private float jumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            enemyController.isPlayerInAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            enemyController.isPlayerInAttackRange = false;
        }
        
    }
       
}
