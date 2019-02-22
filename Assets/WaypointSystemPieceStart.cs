using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPieceStart : MonoBehaviour
{
    public List<GameObject>Pieces;
    public List<Transform> Waypoints;
    public GameObject player;
    private int current = 0;
    public int speed;
    public float WpRadius = .1f;
    private bool ColTrue = true;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerStay(Collider col)
    {
        if (ColTrue)
        {
            GameObject[] OtherWPs;
            //Creates an array of all pieces in scene
            OtherWPs = GameObject.FindGameObjectsWithTag("piece");
            
            
            
            foreach (GameObject OtherWP in OtherWPs)
            {

                if (col.gameObject == OtherWP)
                {
                    WaypointSystemPiece otherClass;
                    otherClass = OtherWP.GetComponent<WaypointSystemPiece>();
                    otherClass.ColStart = true;
                    OtherWP.transform.SetParent(transform);
                    //Pieces.Add(OtherWP);
                    ColTrue = false;
                    
                }
             
                //else if (col.gameObject != OtherWP)
                //{
                //    ColTrue = false;
                //}
            }

        }
    }








    void Update()
    {
        //  Debug.Log("count=" + Waypoints.Count);
        // Debug.Log("current=" + current);
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
