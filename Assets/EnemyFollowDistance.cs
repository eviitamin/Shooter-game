using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyFollowDistance : MonoBehaviour
{
    public float minDistance;
    private float distanceToPlayer;

    private AIPath _aiPath;
    private Transform _player;

    public bool isPatrol;

    public Transform pointA;
    public Transform pointB;

    private void Awake()
    {
        _aiPath = GetComponent<AIPath>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(_player.transform.position, transform.position);

        if (minDistance >= distanceToPlayer)
        {
            _aiPath.enabled = true;
        }
        else
        {
            _aiPath.enabled = false;
        }
    }
}
