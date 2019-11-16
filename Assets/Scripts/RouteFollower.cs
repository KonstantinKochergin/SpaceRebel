using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteFollower : MonoBehaviour
{

    private Route route;

    private int currentWaypoint;

    private float nearDistance = 0.05f;

    private float speed = 2f;

    private bool isFollowing = false;

    public void Init(Route route)
    {
        this.route = route;
        currentWaypoint = 0;
        isFollowing = true;
    }

    public void StartFollowing()
    {
        transform.position = route.waypoints[currentWaypoint].transform.position;       //ставим в начальную позицию
        currentWaypoint += 1;
    }


    float wayPointCoverdDistance;
    float distanceBetweenWayPoints;
    float fractionJourny;
    float startTime;

    private void FlyToWaypoint()
    {
        if (Vector2.Distance(transform.position, route.waypoints[currentWaypoint].transform.position) > nearDistance)
        {
            wayPointCoverdDistance = (Time.time - startTime) * speed;

            float fraction = wayPointCoverdDistance / distanceBetweenWayPoints;

            transform.position = Vector3.Lerp(route.waypoints[currentWaypoint - 1].transform.position, route.waypoints[currentWaypoint].transform.position, fraction);

            Vector3 vectorToTarget = route.waypoints[currentWaypoint].transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10);
        }
        else if (currentWaypoint < route.waypoints.Count)
        {
            currentWaypoint += 1;
            if (currentWaypoint == route.waypoints.Count)
            {
                isFollowing = false;
                return;
            }

            /*
            Vector3 vectorToTarget = route.waypoints[currentWaypoint].transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            Debug.Log($"angle: " + angle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 100);

            //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10);
            */

            distanceBetweenWayPoints = Vector2.Distance(route.waypoints[currentWaypoint - 1].transform.position, route.waypoints[currentWaypoint].transform.position);
            startTime = Time.time;


        }
        else if (currentWaypoint == route.waypoints.Count)
        {
            isFollowing = false;
        }
    }

    

    public void PauseFollowing()
    {

    }


    private void Update()
    {
        if (isFollowing)
        {
            FlyToWaypoint();
        }
    }
}
