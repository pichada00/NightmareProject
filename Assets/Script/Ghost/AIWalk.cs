using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWalk : MonoBehaviour
{
	public float Distance;
	public Transform Target;
	public GameObject[] waypoints;
	int currentWP = 0;
	public float lookAtDistance = 25.0f;
	public float attackRange = 15.0f;
	public float moveSpeed = 2.0f;
	public float Damping = 6.0f;
	public float accuary = 1.0f;
	bool Lastwaypoint=false;
	

    private void Start()
    {
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    private void Update()
	{
		Distance = Vector3.Distance(Target.position, transform.position);
		float angle = Vector3.Angle(Target.position - this.transform.position, this.transform.forward);
		if (Distance < lookAtDistance)
		{
			lookAt();
		}
		if (Distance > lookAtDistance)
		{
			Walk();
		}
		if (Distance < attackRange)
		{
			attack();
		}
	}

	public void  lookAt()
	{
		var rotation = Quaternion.LookRotation(Target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		//transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
    public void Walk()
    {
        if (waypoints.Length == 0) return;

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
        this.transform.Translate(0, 0, moveSpeed * Time.deltaTime);

    }

    public void  attack()
	{
		//transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		//animation.Play("Attack");
	}

	
}
