using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPieceStart : MonoBehaviour
{
    public Rigidbody ThisRig;
    public List<GameObject>Pieces;
    public List<Transform> Waypoints;
    public GameObject player;
    private int current = 0;
    public int speed;
    public float WpRadius = .1f;
    private bool ColTrue;
    public BoxCollider ThisCol;
    GameObject[] OtherWPs;
    // Use this for initialization
    void Start()
    {
      
        ColTrue = true;
    }
  
    //void OnTriggerEnter(Collider col)
    //{
    //    Debug.Log("hit");

        
    //    OtherWPs = GameObject.FindGameObjectsWithTag("piece");

    //    foreach (GameObject OtherWP in OtherWPs)
    //        {
    //        ThisRig.WakeUp();
    //        WaypointSystemPiece otherClass;
    //        otherClass = OtherWP.GetComponent<WaypointSystemPiece>();
    //        if (col.gameObject == OtherWP)
    //        {
               
    //            otherClass.ColStart = true;
                
    //            //Pieces.Add(OtherWP);
    //            // ColTrue = false;

               
    //            OtherWP.tag = ("StartPiece");
                
              
    //            OtherWP.transform.SetParent(transform);
    //            ThisCol.enabled = false;
                
               

    //        }
          

    //        //else if (col.gameObject != OtherWP)
    //        //{
    //        //    ColTrue = false;
    //        //}
    //    }

    //    }
    








    private void Update()
    {
       
            
       
        //OtherWPs = GameObject.FindGameObjectsWithTag("piece");
        //Creates an array of all pieces in scene

       
        //  Debug.Log("count=" + Waypoints.Count);
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
