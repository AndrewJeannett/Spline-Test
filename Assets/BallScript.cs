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
    private bool Forward;
    // Use this for initialization
    void Start () {
        StartClass = Startpiece.GetComponent<WaypointSystemPieceStart>();
        
	}
    public void OnTriggerStay(Collider Col)
    {
        if (Col.tag == "up")
        {
            Debug.Log("slow");
            speed-=1*RampSpeed;
        }
        if (Col.tag == "down")
        {
            Debug.Log("fast");
            speed+=1*RampSpeed;
        }
        if (Col.tag == "straight")
        {
            speed -= 1*StraightSpeed;
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
        Forward=true;
    }
    private void Update()
    {

        Debug.Log("speed=" + speed);
       

        transform.position = Vector3.MoveTowards(transform.position, StartClass.Waypoints[current].transform.position, Time.deltaTime * speed);
            if (speed <= 0)
            {
            SpeedSwitch();
               
                    speed++;
            }
            else if (speed > .01)
            {
                Forward=true;
            }
        if (Vector3.Distance(StartClass.Waypoints[current].transform.position, transform.position) < WpRadius)
        {
           if (Forward){
               current++;
           }
           if (Forward== false){
               
             
               
           }
            if (current >= StartClass.Waypoints.Count)
            {
                current = 0;
            }

        }
    }
}
