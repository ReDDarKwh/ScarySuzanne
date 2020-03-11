using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Collider head;
    public Collider body;

    public NavMeshAgent agent;

    public Transform objective;

    public float hitpoints;
    public float headDamageMultiplier;
    public float minSpeed;
    public float maxSpeed;

    public AudioClip deadSound;

    public AudioSource spoopyVoiceSource;

    public MeshRenderer mesh;


    public Score score;

    private bool dead;

    public void DoDamage(float damage, Collider colliderHit)
    {

        spoopyVoiceSource.PlayOneShot(deadSound);

        hitpoints -= damage * (colliderHit == head ? headDamageMultiplier : 1);
        if (hitpoints <= 0 && !dead)
        {
            Die();
        }
    }

    public void Die()
    {
        dead = true;
        score.score++;
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

        objective = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(objective.position);
        agent.speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
