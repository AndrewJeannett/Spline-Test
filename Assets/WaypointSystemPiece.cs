using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPiece : MonoBehaviour
{
    public List<Transform> Waypoints;
    public bool ColStart = false;
    GameObject[] OtherWPs;
    public BoxCollider ThisCol;
    public static int ColCount;
    private bool isColliding = false;
    private GameObject OtherWPc;

    private void Start()

    {



        ThisCol.enabled = true;
        // StartCoroutine("ColliderDelay");

    }
    //private void Update()
    //{
    //    OtherWPs = GameObject.FindGameObjectsWithTag("piece");
    //}
    //IEnumerator ColliderDelay()
    //{

    //    yield return new WaitForSeconds(.5f);
    //    ThisCol.enabled = true;
    //}
    void OnTriggerEnter(Collider other)
    {

        GameObject StartPiece = GameObject.FindGameObjectWithTag("StartPiece");
        Collider StartCol = StartPiece.GetComponent<Collider>();
        Debug.Log("SP=" + StartPiece);
        Debug.Log(other.gameObject);
        if (other.gameObject == StartPiece)
        {

            Debug.Log("hit2");
            gameObject.transform.SetParent(StartPiece.transform);
            other.enabled = false;
            gameObject.tag = "StartPiece";
            ListAdd();
        }
        if ((other.gameObject.transform.parent == StartPiece.transform) && (transform.parent == null))
        {

            Debug.Log("hit2");

            other.enabled = false;
            gameObject.tag = "StartPiece";
            gameObject.transform.SetParent(StartPiece.transform);
            ListAdd();
        }
    }
    //void OnTriggerEnter(Collider col)
    //{

    //    {
    //        Debug.Log(ColCount);
    //        foreach (GameObject OtherWP in OtherWPs)

    //        {



    //            if (col == OtherWP)

    //            {
    //                isColliding = true;

    //               // OtherWP.transform.SetParent(transform.parent);
    //                //OtherWP.tag = ("StartPiece");
    //                ThisCol.enabled = false;
    //            }

    //            ColCount++;




    //        }
    //    }

    //}

    //private void FixedUpdate()


    //    {
    //    if (Input.GetButtonDown("Fire3"))
    //    {
    //        ThisCol.enabled = true;
    //    }
    //        Invoke("ListAdd", .1f);
    //    }

    //void ColliderOff()
    //{
    //    ThisCol.enabled = false;
    //}
    void ListAdd()
    {
        //foreach (GameObject OtherWP in OtherWPs)

        //Transform[] Waypoints = GetComponentsInChildren<Transform>();

        GameObject StartPiece = GameObject.FindGameObjectWithTag("StartPiece");
        WaypointSystemPieceStart OtherStartClass = StartPiece.GetComponent<WaypointSystemPieceStart>();


        int LastIndex = OtherStartClass.Waypoints.Count - 1;
        Transform LastIndexGO = OtherStartClass.Waypoints[LastIndex].GetComponent<Transform>();
        float Dist = Vector3.Distance(LastIndexGO.position, transform.position);
        Debug.Log(Dist);
        if (Dist >= 3.5f)
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
            
        }
    }
}

//}
