using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Sockets;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    public Transform targetLocationApproach;
    public Vector3 targetLocationLeave;
    public Transform playerPos;

    private NavMeshAgent agent;
    private Animator anim;

    public bool walk;
    public bool leave;
    public bool talk;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targetLocationLeave = this.transform.position;
    }

    private void Update()
    {
        if (walk)
        {
            if (agent.remainingDistance < 0.1)
            {
                anim.SetBool("walk", false);
                transform.LookAt(playerPos);
                walk = false;
                anim.SetBool("talk", true);

            }
        }
        else if (leave)
        {
            if (agent.remainingDistance < 0.1)
            {
                anim.SetBool("leave", false);
                leave = false;
            }
        }
        
    }


    public void InitApproachToCounter()
    {
        
        anim.SetBool("walk", true);
        agent.SetDestination(targetLocationApproach.position);
        transform.LookAt(playerPos);
        walk = true;
        
    }

    public void InitLeave()
    {
        anim.SetBool("talk", false);
        anim.SetBool("leave", true);
        StartCoroutine(TurnAround());

        //leave = true;
        
    }

    IEnumerator TurnAround()
    {
        yield return new WaitForSeconds(0.3f);
        agent.SetDestination(targetLocationLeave);
        transform.LookAt(targetLocationLeave);
        yield return new WaitForSeconds(0.2f);
        leave = true;
    }
}
