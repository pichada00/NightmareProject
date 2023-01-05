using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class FieldOfView : MonoBehaviour
{
    public static FieldOfView field { get; private set; }
    public float radius;
    [Range(0, 360)]
    public float angle;
    

    public GameObject playerRef;
    public Transform Target;

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public LayerMask isGrounded;

    public bool canSeePlayer = false;
    public bool canAttack;
    private bool canTeleport = false;
    bool walkPointSet;
    public Vector3 walkPoint;

    public NavMeshAgent navmesh;
    public float distanceToTarget;
    public float Distance = 1.0f;
    public float walkPointRange;
    public float Damping = 6.0f;
    public float moveSpeed = 4f;

    public AIwithNAV aIwithNAV;

    //ai sight and memory
    private bool aiMemorizesPlayer = false;
    public float memoryStartTime = 10f;
    private float increasingMemoryTime;

    public GameObject[] transformsWaypoint;
    public List<GameObject> WaypointFrontroom = new List<GameObject>();
    public GameObject waypointTeleport;
    public GameObject waypointstarter;
    public float Min = 10;
    public int currentWP = 0;
    private Gamemanager gamemanager;
    private Animator ghostAnimator;    

    private void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        Target = playerRef.transform;
        gamemanager = Gamemanager.gamemanager;
        ghostAnimator = GetComponent<Animator>();
        aIwithNAV = GetComponent<AIwithNAV>();
        transformsWaypoint = GameObject.FindGameObjectsWithTag("WaypointFrontRoom");
        StartCoroutine(FOVRoutine());
    }
    /*private void Awake()
    {
        if (field == null)
        {
            field = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/
    private void Update()
    {
        aIwithNAV.Walk();
        SoundManager.Instance.Play(aIwithNAV.audioSource, SoundManager.Sound.PlayerWalked);
    }
    public IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    public void FieldOfViewCheck()
    {
        
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                distanceToTarget = Vector3.Distance(transform.position, target.position);
                

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)&& !Physics.Raycast(transform.position, directionToTarget, distanceToTarget, isGrounded)) 
                {
                    var rotation = Quaternion.LookRotation(Target.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
                    canSeePlayer = true;
                    
                    ghostAnimator.SetBool("seePlayer", true);
                    //Moveto player
                    navmesh.destination = playerRef.transform.position;
                    navmesh.speed = 3.5f * 4;
                    if (distanceToTarget <  5.0f )
                    {
                        //ghostAnimator.SetBool("canattack", true);
                        HealthSystem.healthSystem.SetHP();                        
                        canAttack = true;
                        SoundManager.Instance.Play(aIwithNAV.audioSource, SoundManager.Sound.laugh);
                    }
                   // ghostAnimator.SetBool("canattack", false);

                }
                else
                {
                    navmesh.speed = 3.5f;
                    canSeePlayer = false;
                    ghostAnimator.SetBool("seePlayer", false);
                    //StartCoroutine(AiMemory());
                    //DestroyDoor 
                    //Move away 
                    canAttack = false;
                }

            }
            else
            {
                ghostAnimator.SetBool("seePlayer", false);
                canSeePlayer = false;
                //ghostAnimator.SetBool("seePlayer", canSeePlayer);
                //Move away
                canTeleport = true;
                /*if (canTeleport == true && !gamemanager.entrance )
                {
                    Invoke("TelepoetPoint", 5.0f);
                } */             
                canAttack = false;
            }
                
        }
        else if (canSeePlayer)
        {
            ghostAnimator.SetBool("seePlayer", false);
            canSeePlayer = false;
            
            //Move away
            //canAttack = false;
        }

    }

    public void TelepoetPoint()
    {        
        canSeePlayer = true;
        Debug.Log("warp");
        for(int i = 0; i < transformsWaypoint.Length; i++)
        {
            float nearTarget = Vector3.Distance(transform.position, WaypointFrontroom[i].transform.position);
            if (nearTarget < Min)
            {
                waypointTeleport = WaypointFrontroom[i];
            }            
        }
        transform.position = waypointTeleport.transform.position;
        ghostAnimator.SetBool("boolIdle", true);
        Invoke("TeleportStarterPoint", 5.0f);
    }

    public void TeleportStarterPoint()
    {       
        ghostAnimator.SetBool("boolIdle", false);
        Debug.Log("comeback");
        transform.position = waypointstarter.transform.position;
        canSeePlayer = false;
        canTeleport = false;
        gamemanager.entrance = !gamemanager.entrance;
    }
    private IEnumerator AiMemory()
    {
        increasingMemoryTime = 0f;

        while (increasingMemoryTime < memoryStartTime)
        {
            increasingMemoryTime += Time.deltaTime;
            aiMemorizesPlayer = true;
            yield return null;
        }

        canSeePlayer = false;
        aiMemorizesPlayer = false;
    }

    

}
