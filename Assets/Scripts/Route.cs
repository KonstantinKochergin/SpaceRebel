using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route
{

    public List<Waypoint> waypoints = new List<Waypoint>();         //маршрут

    private List<RouteFollower> followers = new List<RouteFollower>();   //следователи маршрута

    public Route(List<Waypoint> waypoints)
    {
        this.waypoints = waypoints;
    }


    //добавляет следователя
    public void AddFollower(RouteFollower follower)
    {
        follower.Init(this);
        followers.Add(follower);

        follower.StartFollowing();
    }

}
