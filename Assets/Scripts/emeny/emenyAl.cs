using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;
using GhostCastle.Utils;

public class emenyAl : MonoBehaviour
{
    [SerializeField] private State startingState;

    [SerializeField] private float roamingDistanceMax = 7f;

    [SerializeField] private float roamingDistanceMin = 3f;

    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent navMeshAgent;

    private State state;

    private float roamingTime;

    private Vector3 roamPosition;

    private Vector3 startingPosition;
private enum State
    {
        idle,
        Roaming
    }
    private void Start()
    {
        startingPosition = transform.position;
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
    }

    private void Update()
    {
        switch (state) {
            default:
            case State.idle:
                break;
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime <= 0) {
                    Roaming();
                    roamingTime = roamingTimerMax;

                }
                break;
        }
    }

    private void Roaming() {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
        navMeshAgent.SetDestination(roamPosition);
    }

    private Vector3 GetRoamingPosition() {
        var gg = startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
        Debug.Log(gg);
        return gg;

        
    }
}
