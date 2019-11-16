using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoutesManager : MonoBehaviour
{

    public List<Waypoint> route1Waypoints = new List<Waypoint>();
    public RouteFollower follower;

    private List<Route> routes = new List<Route>();

    private void Awake()
    {
        routes.Add(new Route(route1Waypoints));

        routes[0].AddFollower(follower);    //инициализация следования маршрута
    }

}
