using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public float speed;
    public GameObject Startpiece;
    private WaypointSystemPieceStart StartClass;
    private List<Transform> Path;
    private int current = 0;
    public float WpRadius = .1f;
    public float RampSpeed;
    public float StraightSpeed;
    private bool Play;
    private bool onPath;
    private Rigidbody thisRig;
    // Use this for initialization
    void Start () {
        StartClass = Startpiece.GetComponent<WaypointSystemPieceStart>();
        Play = false;
         thisRig = gameObject.GetComponent<Rigidbody>();
    }
    public void OnTriggerStay(Collider Col)
    {
        if (Play)
        {
            if (Col.tag == "up")
            {
                Debug.Log("slow");
                speed -= 1 * RampSpeed;
            }
            if (Col.tag == "down")
            {
                Debug.Log("fast");
                speed += 1 * RampSpeed;
            }
            if (Col.tag == "straight")
            {
                speed -= 1 * StraightSpeed;
            }
        }
    }
    // Update is called once per frame
    private void SpeedSwitch(){
        GameObject[] UpObjects= GameObject.FindGameObjectsWithTag("up");
        GameObject[] DownObjects= GameObject.FindGameObjectsWithTag("down");
 StartClass.Waypoints.Reverse();
                current = (StartClass.Waypoints.Count -current);
        foreach (GameObject up in UpObjects){
            up.tag = "down";
        }
         foreach (GameObject down in DownObjects){
            down.tag = "up";
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Startpiece.transform.GetChild(0).position;
            Play = false;
            speed = 3;
            current = 0;
            thisRig.velocity = Vector3.zero;
            thisRig.angularVelocity = Vector3.zero;
        }
        if (onPath == true)
        {
            transform.GetChild(0).Rotate(Vector3.right * speed, Space.Self);
        }
        Debug.Log("speed=" + speed);
      
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Play == false)
            {
                Play = true;
            }else if (Play)
            {
                Play = false;
            }
        }
        if (Play)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartClass.Waypoints[current].transform.position, Time.deltaTime * speed);
            transform.LookAt(StartClass.Waypoints[current]);
            onPath = true;
        }
            if (speed <= 0)
            {
            SpeedSwitch();
               
                    speed++;
            }
          
        if (Vector3.Distance(StartClass.Waypoints[current].transform.position, transform.position) < WpRadius)
        {
            
            current++;
            if (current >= StartClass.Waypoints.Count)
            {
                
                thisRig.AddRelativeForce(Vector3.forward*(speed*4));
                //transform.Translate(0, 0, speed*.01f, Space.Self);
                thisRig.useGravity = true;
                //current = 0;
                onPath = false;
                Play = false;
            }
            else
            {
                
                onPath = true;
                thisRig.useGravity = false;
            }



        }
    }
}
