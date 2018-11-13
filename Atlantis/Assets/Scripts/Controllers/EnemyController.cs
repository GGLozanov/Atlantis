using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    private float lookRadius;
    private float cooldown;
    private float damage;
    private float timer, timer2 ,  wonderTimer = 5f;

    public float wanderRadius;

    private Vector3 spawnPoint, distanceCovored, spawnLocation, newPos;
    private bool follow = true, returnIndicator = false;
    GameObject target;
    NavMeshAgent agent;


	void Start () {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        timer = cooldown;
        timer2 = wonderTimer;
        damage = gameObject.GetComponent<EnemyStats>().damage;
        cooldown = gameObject.GetComponent<EnemyStats>().cooldown;
        lookRadius = gameObject.GetComponent<EnemyStats>().lookRadius;
        spawnPoint = transform.position;
        spawnLocation = new Vector3(Mathf.Abs(spawnPoint.x), Mathf.Abs(spawnPoint.y));
    }

	void Update () {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        timer2 += Time.deltaTime;
        if (distance <= lookRadius && follow == true)
        {
            Vector3 currentLocation = new Vector3(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y));
            distanceCovored = spawnLocation - currentLocation;
            timer -= Time.deltaTime;
            agent.SetDestination(target.transform.position);
            if (distance <= agent.stoppingDistance)
            {
                if (timer < 0)
                {
                    target.GetComponent<PlayerStats>().DealDamage(damage);
                    timer = cooldown;
                }
                FaceTarget();
            }
        }
        else {
            if (timer2 >= wonderTimer)
            {
                if (returnIndicator == false) {
                    newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                    agent.SetDestination(newPos);
                    returnIndicator = true;
                }
                else if (returnIndicator == true) {
                    agent.SetDestination(spawnPoint);
                    returnIndicator = false;
                }
                timer2 = 0;
            }
            if (gameObject.GetComponent<EnemyStats>().health < 100)
            {
                gameObject.GetComponent<EnemyStats>().health++;
            }
        }

        if(Mathf.Abs(distanceCovored.x) > 20f || Mathf.Abs(distanceCovored.y) > 20f)
        {
            agent.SetDestination(spawnPoint);
            follow = false;
            if (gameObject.GetComponent<EnemyStats>().health < 100) {
                gameObject.GetComponent<EnemyStats>().health++;
            }
            
        }

        if (Vector3.Distance(spawnPoint, transform.position) <= 4 && follow == false)
        {
            follow = true;
        }
    
    }

    void FaceTarget() {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
