using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPiece : MonoBehaviour
{
    public List<Transform> Waypoints;
    private int ColCount=0;

    void OnTriggerEnter(Collider col)
    {
        GameObject[] OtherWPs;
        Debug.Log(ColCount);
        OtherWPs = GameObject.FindGameObjectsWithTag("piece");

        foreach (GameObject OtherWP in OtherWPs)
        {
            WaypointSystemPiece OtherComp = OtherWP.GetComponent<WaypointSystemPiece>();
            if (col.gameObject == OtherWP)
            {
                ColCount++;
                
               
                for (int i = 0; i <= OtherComp.Waypoints.Count; i++)
                {
                    if (OtherComp.ColCount >= 1)
                    {
                        Waypoints.Add(OtherComp.Waypoints[i]);
                    }
                }
            }
        }
    }
}