using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPieceStart : MonoBehaviour {
    public List<GameObject> Pieces;
    public GameObject player;
    private int current = 0;
    public int speed;
    public float WpRadius=.1f;
	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        
        GameObject[] OtherWPs;
        //Creates an array of all pieces in scene
        OtherWPs = GameObject.FindGameObjectsWithTag("piece");

       foreach (GameObject OtherWP in OtherWPs)
        {
            
            if (col.gameObject == OtherWP)
            {
                Pieces.Add(OtherWP);
                //WaypointSystemPiece OtherComp = OtherWP.GetComponent<WaypointSystemPiece>();
                //for (int i = 0; i <= OtherComp.Waypoints.Count; i++)
                //{
                //    Waypoints.Add(OtherComp.Waypoints[i]);

                //}
            }
        }
       for (int i =0; i <= 100; i++)
        {
           GameObject PiecesGO = GetComponent<GameObject>(Pieces[i]);
            foreach (GameObject OtherWP in OtherWPs) {
                if (col.) {
                    Pieces.Add(OtherWP); }
            }

        }
    }


}
        void Update() {
            // Debug.Log("count="+Waypoints.Count);
            // Debug.Log("current=" + current);
            //player.transform.position = Vector3.MoveTowards(player.transform.position, Waypoints[current].transform.position, Time.deltaTime * speed);
            //if (Vector3.Distance(Waypoints[current].transform.position, player.transform.position) < WpRadius)
            //{
            //    current++;
            //    if (current >= Waypoints.Count)
            //    {
            //        current = 0;
            //    }

            //}
        }
    }
