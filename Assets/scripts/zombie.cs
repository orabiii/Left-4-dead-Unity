using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class zombie : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    float inRange = 10f;
    bool chase = false;
   /* public Transform [] Destination;
    private Vector3 currentDestination;
    private int index;*/

    void Start()
    {
        /*var list = GetComponents(typeof(Component));
        for (int i = 0; i < list.Length; i++)
        {
            Debug.Log(list[i].name);
        }*/
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        /*index = 0;
        currentDestination = Destination[0].position;*/
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if (distance <= inRange && chase == false)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 11.5f;
            anim.SetBool("chase", true);
            chase = true;
        }
        if (chase)
        {
            agent.SetDestination(player.transform.position);
            
        }
        else
        {
            //setNewDestibation();
        }

    }

    void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = agent.nextPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, inRange);
    }

    /*void setNewDestibation()
    {
        index++;
        if (index >= Destination.Length)
        {
            index = 0;
        }
        currentDestination = Destination[index].position;
        agent.SetDestination(currentDestination);
    }*/
}

