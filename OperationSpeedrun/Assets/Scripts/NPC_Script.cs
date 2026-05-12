using UnityEngine;
using UnityEngine.AI;

public class NPC_Script : MonoBehaviour
{
	[SerializeField] float waitTimeOnWayPoint = 1f;
	[SerializeField] WaypointManager path;

	NavMeshAgent agent;
	Animator animator;

	float time = 0f;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		agent.destination = path.GetCurrentWayPoint();
	}

	private void Update()
	{
		if (agent.remainingDistance <= 0.1f)
		{
			time += Time.deltaTime;
			if (time >= waitTimeOnWayPoint)
			{
				time = 0f;
				agent.destination = path.GetNextWaypoint();
			}
		}

		float normalizedSpeed = Mathf.InverseLerp(0f, agent.speed, agent.velocity.magnitude);
		animator.SetFloat("speed", normalizedSpeed);
	}
}
