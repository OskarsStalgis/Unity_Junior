
using UnityEngine;

public class PlayerDetectionTrigger : MonoBehaviour
{

    private EnemyController enemyController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            enemyController.isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("Player"))
        {
            enemyController.isTriggered = false;
        }
        
    }
    

}
