using UnityEngine;

public class MovingToAPoint : MonoBehaviour
{
    public Transform pointA;           
    public float speed = 2f;            
    public float activationRange = 5f; 
    private Transform player;            

    void Start()
    {
        // Find the player in the scene by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure your player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player == null || pointA == null) return;

        // Calculate activation point at the top of the object
        Vector2 activationPoint = (Vector2)transform.position + Vector2.up * GetComponent<SpriteRenderer>().bounds.extents.y;
        float distanceToPlayer = Vector2.Distance(activationPoint, player.position);

        if (distanceToPlayer <= activationRange)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                pointA.position,
                speed * Time.deltaTime
            );
        }
    }

    // Optional: Visualize the activation range in the editor
    void OnDrawGizmosSelected()
    {
        // Calculate top position for gizmo
        Vector2 topPosition = (Vector2)transform.position;
        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            topPosition += Vector2.up * sr.bounds.extents.y;
        }
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(topPosition, activationRange);
        
        if (pointA != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, pointA.position);
            Gizmos.DrawWireSphere(pointA.position, 0.3f);
        }
    }
}