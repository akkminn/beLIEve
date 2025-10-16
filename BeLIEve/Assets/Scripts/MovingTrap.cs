using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public Transform pointA;         
    public Transform pointB;         
    public float speed = 2f;         
    public float activationRange = 5f; 
    private Transform player;         
    private bool isActive = false;   

    private Vector3 target;          

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = pointA.position;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= activationRange)
            isActive = true;

        if (isActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target) < 0.1f)
                target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, activationRange);

        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}
