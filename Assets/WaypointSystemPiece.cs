using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPiece : MonoBehaviour
{
    public List<Transform> Waypoints;
    private bool ColStart;

    void OnTriggerEnter(Collider col)
    {
        GameObject[] OtherWPs;
        Debug.Log(ColStart);
        OtherWPs = GameObject.FindGameObjectsWithTag("piece");
        if (col.gameObject.tag == "StartPiece")
        {
            ColStart = true;
        }
        else { ColStart = false; }
        foreach (GameObject OtherWP in OtherWPs)
        {
            WaypointSystemPiece OtherComp = OtherWP.GetComponent<WaypointSystemPiece>();
            if (col.gameObject == OtherWP)
            {
             
                
               
                for (int i = 0; i <= OtherComp.Waypoints.Count; i++)
                {
                    if (OtherComp.ColStart==false)
                    {
                        Waypoints.Add(OtherComp.Waypoints[i]);
                    }
                }
            }
        }
    }
}