using System;
using System.Security.Cryptography;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public GameObject player;
        public float dist = 30;
        public float distance;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            distance = Vector3.Distance(this.transform.position, player.transform.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
            {
                if (distance < dist && distance>6)
                {
                    this.target = player.transform;
                }
                
                else
                {
                    //pick new target
                    System.Random rnd = new System.Random();
                    int c = rnd.Next(1, 100);
                    GameObject target1 = GameObject.Find("Sideway Prefab (" + c + ")");
                    this.target = target1.transform;
                    //character.Move(Vector3.zero, false, false);
                }
            }
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
