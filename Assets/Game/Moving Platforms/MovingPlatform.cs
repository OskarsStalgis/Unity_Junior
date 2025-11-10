using UnityEditorInternal;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private Transform[] points;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float marginOfError = 0.01f;
    private int currentPointIndex = 0;
    private int indexStep = -1;

    // Update is called once per frame
    void Update()
    {
        if (points.Length != 0)
        {
            Transform currentPoint = points[currentPointIndex];
            Transform targetPos = currentPoint.transform;
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, movementSpeed * Time.deltaTime);

            float distance = Vector3.Distance(targetPos.transform.position, transform.position);
            if (distance < marginOfError)
            {
                if (currentPointIndex == (points.Length - 1) || currentPointIndex == 0)
                {
                    indexStep = -indexStep;
                }
                currentPointIndex += indexStep;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player.tag == collision.gameObject.tag)
        {
            player.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (player.tag == collision.gameObject.tag)
        {
            player.transform.SetParent(null);
        }
    }
}
