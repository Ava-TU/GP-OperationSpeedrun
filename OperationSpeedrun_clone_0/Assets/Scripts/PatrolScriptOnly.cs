using UnityEngine;
using UnityEngine.AI;

public class PatrolScriptOnly : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;

    [SerializeField]
    LayerMask groundLayer, playerLayer;

    //For Patrol
    Vector3 destPoint;
    bool walkPointSet;

    [SerializeField]
    float walkRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkPointSet) //If theres no walk point set:
        {
            SearchForDest();
        }

        if (walkPointSet) //If walk point is set
        {
            agent.SetDestination(destPoint); //The agent will navigate towards the destination point given
        }

        if (Vector3.Distance(transform.position, destPoint) < 10) //If the distance between the enemy position and point is less than 10 units:
        {
            walkPointSet = false; //It sets the walk point bool to false and picks a new destination
        }
    }

    void SearchForDest()
    {
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z); //Picks random new position

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer)) //Checks if its inside the NavMesh area before applying new destination
        {
            walkPointSet = true;
        }
    }
}
