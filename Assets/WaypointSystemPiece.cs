using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPiece : MonoBehaviour
{
    public List<Transform> Waypoints;
    private bool ColStart=false;
    private int ColCount = 0;

    private void Update()
    {
        Debug.Log(ColStart);
    }
    void OnTriggerEnter(Collider col)
    {
        GameObject[] OtherWPs;
        
        OtherWPs = GameObject.FindGameObjectsWithTag("piece");
        if (col.gameObject.tag == "StartPiece")
        {
            ColStart = true;
            ColCount++;
        }
       
        foreach (GameObject OtherWP in OtherWPs)

        {
            WaypointSystemPiece OtherComp = OtherWP.GetComponent<WaypointSystemPiece>();
            if (col.gameObject == OtherWP)
                ColCount++;
            {
                
                if ((ColStart == true)&(OtherComp.ColCount > 1))
                {
                    
                    OtherComp.ColStart = true;
                    
                }
                for (int i = 0; i <= Waypoints.Count; i++)
                {
                    if ((OtherComp.ColStart == false)&(OtherComp.ColCount<=1))
                    {
                        OtherComp.Waypoints.Add(Waypoints[i]);
                        ColStart = false;
                        ColCount--;

                    }
                }
            }
        }
    }
}