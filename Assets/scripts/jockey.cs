using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class jockey : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    float inRange = 10f;
    bool chase = false;
    bool attack = false;
    bool walkable = true;
    int i = 0;
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
        StartCoroutine("Reset");
    }

    // Update is called once per frame
    void Update()
    {
        //print(++i);
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if (distance <= inRange && chase == false)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = 1.5f;
            anim.SetBool("chase", true);
            chase = true;
            walkable = true;
        }
        if (chase && walkable)
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attack = true;
            StartCoroutine(Reset());
            //print("now");
            //anim.SetBool("idle", false);
            //anim.SetBool("attack", true);
            //Invoke("myTimer", 5);


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attack = false;
            anim.SetBool("attack", false);
            //walkable = false;
            agent.SetDestination(agent.transform.position);
            anim.SetBool("idle", true);
            Invoke("myTimer", 5);
            //chase = false;
        }
    }
    IEnumerator Reset()
    {
        // your process
        while (attack)
        {
            anim.SetBool("idle", false);
            anim.SetBool("chase", false);
            anim.SetBool("attack", true);
            yield return new WaitForSeconds(5);
            // continue process
            if (attack)
            {
                anim.SetBool("attack", false);
                anim.SetBool("idle", true);
                yield return new WaitForSeconds(5);
            }
        }
    }
    private void myTimer()
    {
        chase = false;
        /*Invoke("idleTimer", 5);*/
    }

    private void idleTimer()
    {
        anim.SetBool("idle", false);
        anim.SetBool("chase", true);
    }
    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("attack", false);

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            anim.SetBool("attack", true);
            Invoke("myTimer", 5);

        }
    }*/
}

