using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPiece : MonoBehaviour
{
    public List<Transform> Waypoints;
    public bool ColStart = false;
    GameObject[] OtherWPs;
    BoxCollider ThisCol;
    public static int ColCount;
    private bool isColliding = false;
    private GameObject OtherWPc;

    private void Start()
        
    {
        
        ThisCol = gameObject.GetComponent<BoxCollider>();
        OtherWPs = GameObject.FindGameObjectsWithTag("piece");
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log(ColCount);
        foreach (GameObject OtherWP in OtherWPs)

        {
           


            if ((col.gameObject == OtherWP) && (ColStart))

            {
                isColliding = true;
                OtherWPc = OtherWP;
            }
            
            ColCount++;

                
                
            
        }
    }
    private void FixedUpdate()
    {
        Invoke("ListAdd", .1f);
    }
    void ColliderOff()
    {
        ThisCol.enabled = false;
    }
    void ListAdd()
    {
        //foreach (GameObject OtherWP in OtherWPs)
        
            //Transform[] Waypoints = GetComponentsInChildren<Transform>();
            WaypointSystemPiece OtherClass = OtherWPc.GetComponent<WaypointSystemPiece>();
            GameObject StartPiece = GameObject.FindGameObjectWithTag("StartPiece");
            WaypointSystemPieceStart OtherStartClass = StartPiece.GetComponent<WaypointSystemPieceStart>();
            if ((isColliding) && (ColStart))
            {
               
            int LastIndex = OtherStartClass.Waypoints.Count - 1;
                Transform LastIndexGO = OtherStartClass.Waypoints[LastIndex].GetComponent<Transform>();
                float Dist = Vector3.Distance(LastIndexGO.position, transform.position);
                Debug.Log(Dist);
                if (Dist >= 5)
                {
                    Waypoints.Reverse();
                }
                for (int i = 0; i < Waypoints.Count; i++)
                {
                    if (Waypoints[i].transform.parent != StartPiece.transform)
                    {
                        OtherStartClass.Waypoints.Add(Waypoints[i]);
                    Waypoints.Remove(Waypoints[i]);
                    i--;
                }
               if (Waypoints.Count == 0)
                {
                  

                    OtherClass.ColStart = true;
                    OtherWPc.transform.SetParent(transform.parent);
                    ColliderOff();
                }
            }
            
        }
        }
    }
