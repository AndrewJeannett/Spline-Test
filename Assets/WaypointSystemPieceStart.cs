using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPieceStart : MonoBehaviour
{

    public List<Transform> Waypoints;
    public GameObject player;
    private int current = 0;
    public int speed;
    public float WpRadius = .1f;

    
   
    void Start()
    {
     
    }

    private void Update()
    {

         Debug.Log("current=" + current);

        player.transform.position = Vector3.MoveTowards(player.transform.position, Waypoints[current].transform.position, Time.deltaTime * speed);
       
        if (Vector3.Distance(Waypoints[current].transform.position, player.transform.position) < WpRadius)
        {
            if (speed < 0)
            {
                current--;
            }
            else if (speed > 0)
            {
                current++;
            }
            if (current >= Waypoints.Count)
            {
                current = 0;
            }

        }
    }
}
