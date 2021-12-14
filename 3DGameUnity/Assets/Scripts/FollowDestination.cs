using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowDestination : MonoBehaviour
{
    public Transform Destination = null; private NavMeshAgent ThisAgent = null;
    void Awake() 
    { 
        ThisAgent = GetComponent<NavMeshAgent>(); 
    }
    void Update() 
    {
        if (GameManager.playing == true && NPCTrigger.NPCtalking == false)
        {
            ThisAgent.SetDestination(Destination.position);
        }
        
    }
}