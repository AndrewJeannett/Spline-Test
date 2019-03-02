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
    // Use this for initialization
    void Start () {
        StartClass = Startpiece.GetComponent<WaypointSystemPieceStart>();
        
	}
    public void OnTriggerStay(Collider Col)
    {
        if (Col.tag == "up")
        {
            Debug.Log("slow");
            speed/=RampSpeed;
        }
        if (Col.tag == "down")
        {
            Debug.Log("fast");
            speed*=RampSpeed;
        }
        if (Col.tag == "straight")
        {
            speed /= StraightSpeed;
        }
    }
    // Update is called once per frame
    private void Update()
    {

        Debug.Log("speed=" + speed);
        Path = StartClass.Waypoints;

        transform.position = Vector3.MoveTowards(transform.position, Path[current].transform.position, Time.deltaTime * speed);

        if (Vector3.Distance(Path[current].transform.position, transform.position) < WpRadius)
        {
            if (speed < .1f)
            {
                current--;
            }
            else if (speed > 0)
            {
                current++;
            }
            if (current >= Path.Count)
            {
                current = 0;
            }

        }
    }
}
