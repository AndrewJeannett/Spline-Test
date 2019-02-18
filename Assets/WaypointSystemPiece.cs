using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPiece : MonoBehaviour
{
    public List<Transform> Waypoints;
    public bool ColStart = false;
    GameObject[] OtherWPs;
    BoxCollider ThisCol;
    private void Start()
    {
       ThisCol = gameObject.GetComponent<BoxCollider>();
        OtherWPs = GameObject.FindGameObjectsWithTag("piece");
    }

    void OnTriggerStay(Collider col)
    {





        foreach (GameObject OtherWP in OtherWPs)

        {
            Transform[] Waypoints = GetComponentsInChildren<Transform>();
            WaypointSystemPiece OtherClass = OtherWP.GetComponent<WaypointSystemPiece>();
            GameObject StartPiece = GameObject.FindGameObjectWithTag("StartPiece");
            WaypointSystemPieceStart OtherStartClass = StartPiece.GetComponent<WaypointSystemPieceStart>();
            

            if ((col.gameObject == OtherWP) && (ColStart))

            {
                OtherClass.ColStart = true;
                OtherWP.transform.SetParent(transform.parent);
                for (int i = 0; i < Waypoints.Length; i++)
                {
                    if (Waypoints[i].transform.parent != StartPiece.transform)
                    {
                        OtherStartClass.Waypoints.Add(Waypoints[i]);
                    }
                }
                ThisCol.enabled = false;
            }
        }
    }
}
