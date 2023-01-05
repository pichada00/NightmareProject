using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIwithNAV : MonoBehaviour
{
    //public static AIwithNAV aIwithNAV;
    public GameObject[] waypoints;
    int currentWP = 0;
    public float accuary = 1.0f;
    public float moveSpeed = 2.0f;
    bool Lastwaypoint = false;
    public NavMeshAgent navmesh;
    public static AIwithNAV aIwithNAV;
    private FieldOfView field;
    public AudioSource audioSource;

    /*private void Awake()
    {
        aIwithNAV = this;
    }*/

    private void Start()
    {
        if(gameObject.tag == "Ghost")
        {
            waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        }else if(gameObject.tag == "Ghost2")
        {
            waypoints = GameObject.FindGameObjectsWithTag("WaypointSecond");
        }
        field = GetComponent<FieldOfView>();
        navmesh = GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        
    }

    public void Walk()
    {

        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * moveSpeed);


        if (direction.magnitude < accuary && Lastwaypoint == false)
        {
            currentWP++;
            if (currentWP == waypoints.Length)
            {
                Lastwaypoint = true;
            }
        }
        if (direction.magnitude < accuary && Lastwaypoint == true)
        {
            currentWP--;
            if (currentWP == 0)
            {
                Lastwaypoint = false;
            }
        }
        navmesh.destination = waypoints[currentWP].transform.position;
    }
}
