using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour

{

    public Transform target;
    public NavMeshAgent agent;

    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    public Transform respawnPoint;
    void Update()
    {
        agent.destination = target.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;
        }
    }
}