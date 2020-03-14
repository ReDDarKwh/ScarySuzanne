using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    public GameObject[] monsters;

    public float spawnRadiusMax;

    public float spawnRadiusMin;

    public float spawnWaitPeriode;

    private float spawnTimer = 0;

    public bool started;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetStarted() {
        this.started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
            spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnWaitPeriode)
        {
            spawnTimer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(monsters[0], 
            transform.position + 
            (Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.up) * Vector3.forward).normalized * UnityEngine.Random.Range(spawnRadiusMin, spawnRadiusMax),
            Quaternion.identity
        );
    }
}
