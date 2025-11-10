using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class FireGun : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float fireRate = 3f;
    [SerializeField] Transform spawnpoint;
    [SerializeField] private float destroyDelay = 1f;
    private float fireTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireTime = Time.time;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireTime)
        {
            fireTime += fireRate;
            GameObject projectileInstance = Instantiate(projectile, spawnpoint.position, projectile.transform.rotation);
            projectileInstance.transform.localScale = transform.localScale;

            Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
            rb.linearVelocity = projectileInstance.transform.up * projectileSpeed * Time.deltaTime;
            if (projectileInstance != null)
            {
                Destroy(projectileInstance, destroyDelay);
            }
        }
    }
}
