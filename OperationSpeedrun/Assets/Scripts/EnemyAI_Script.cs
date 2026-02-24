using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class EnemyAI_Script : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;

    public TMP_Text enemyStateText;

    BoxCollider boxCollider;

    [SerializeField]
    LayerMask groundLayer, playerLayer;

    //For Patrol
    Vector3 destPoint;
    bool walkPointSet;

    [SerializeField]
    float walkRange;

    //States
    [SerializeField]
    float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;

    [Header("States")]
    public bool isPatrol;
    public bool isChase;
    public bool isAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        //playerHealth = GetComponent<PlayerScript>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer); //Checks if the player is on the right layer, if its in the sights range and if the position is in range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSight && !playerInAttackRange)
        {
            Patrol(); //Switches to the Patrol State
            isPatrol = true;
            isChase = false;
            isAttack = false;

            enemyStateText.text = "Enemy State = Patrol";
        }
        if (playerInSight && !playerInAttackRange)
        {
            Chase(); //Switches to the Chase state
            isPatrol = false;
            isChase = true;
            isAttack = false;

            enemyStateText.text = "Enemy State = Chase";
        }
        if (playerInSight && playerInAttackRange)
        {
            Attack(); //Switches to the Attack state
            isPatrol = false;
            isChase = false;
            isAttack = true;

            enemyStateText.text = "Enemy State = Attack";
        }
        else //Add in if player health is <= 0
        {
            //enemyStateText.text = "Enemy State = Dance";
        }
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position); //Causes the agent to go towards the players position
    }

    void Attack()
    {
        agent.SetDestination(transform.position);
    }

    void VictoryDance()
    {
        //This will be for when the player dies, the enemy will do a dance animation
    }

    void Patrol()
    {
        if (!walkPointSet)
        {
            SearchForDest();
        }

        if (walkPointSet)
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

    //These will enable/disable the enemy attack collider so it doesnt kill the player too quickly
    //This would be for the attacking animation
    void EnableAttack()
    {
        boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            print("HIT!");
            player.GetComponent<PlayerScript>().health -= 1;
        }
    }
}
