using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public float speed = 2f;            
    public float wanderRadius = 10f;    
    public float wanderInterval = 3f;   
    private NavMeshAgent agent;
    private Animator animator;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = speed;

        // Start wandering after a delay
        timer = wanderInterval;

    }

    void Update()
    {
        if (agent.isOnNavMesh)
        {
            // Count down the timer
            timer += Time.deltaTime;


            // When the timer exceeds the interval, choose a new destination
            if (timer >= wanderInterval)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }

            // Update the Animator's Trigger parameter based on agent's velocity
            if (animator != null)
            {
                // NPC is moving
                if (agent.velocity.magnitude > 0.1f) 
                {
                    animator.SetTrigger("IsWalking");
                }
                else // NPC is idle
                {
                    animator.ResetTrigger("IsWalking");
                }
            }
        }
    }

    // Method to find a random position on the NavMesh within a given radius
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
