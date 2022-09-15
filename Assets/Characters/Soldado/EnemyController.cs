using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    Animator animator;
    [Range(2, 20)]
    public int detectionDistance;
    public float wanderRange;

    bool isWandering = false, alive = true;

    public enum State { Spawn, Idle, Run, Attack };
    public State myState;

    void Start()
    {
        myState = State.Spawn;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = EnemyManager.s_player;
    }

    void Update()
    {
        if (alive)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance < detectionDistance)
            {
                agent.SetDestination(player.position);

                if (agent.remainingDistance <= 3f)
                {
                    if (myState != State.Attack)
                    {
                        myState = State.Attack;
                        animator.SetInteger("State", 3);
                        print("ATACAR");
                    }
                }

                else
                {
                    if (myState != State.Run)
                    {
                        myState = State.Run;
                        animator.SetInteger("State", 1);
                        agent.speed = 3;
                    }
                }
            }

            else Wander();
        }       
    }

    public void BegingChase()
    {
        agent.speed = 3;
    }

    void Wander()
    {
        if (agent.remainingDistance <= 3f)
        {
            myState = State.Idle;
            animator.SetInteger("State", 2);
            agent.speed = 0;

            if (!isWandering)
                StartCoroutine(SetNewTarget(5f));
        }
    }

    IEnumerator SetNewTarget(float time)
    {
        isWandering = true;
        yield return new WaitForSeconds(time);
        float x_component = Random.Range(-wanderRange, wanderRange);
        float z_component = Random.Range(-wanderRange, wanderRange);
        Vector3 wanderTarget = new Vector3(x_component, 0, z_component);
        wanderTarget += transform.position;
        agent.SetDestination(wanderTarget);
        myState = State.Run;
        animator.SetInteger("State", 1);
        agent.speed = 3;
    }

    public void CoolDown()
    {
        if (myState == State.Idle)
            isWandering = false;
    }

    public void Die()
    {
        alive = false;
        animator.SetTrigger("Die");
        agent.enabled = false;
        StartCoroutine(DestroyAfterSeconds());
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(5f);
        EnemyManager.s_enemyCount--;
        Destroy(gameObject);
    }
}
