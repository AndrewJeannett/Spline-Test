using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacement : MonoBehaviour {
public GameObject RampPiece1;
public GameObject SelectionBox;
private int Rotation;
    private bool rotateRefresh;
	// Use this for initialization
	void Start () {
		Rotation=90;
	}
	public void Update(){
        if (Input.GetButtonDown("Jump"))
        {
            Rotation += 90;
            Debug.Log("rotate");
            rotateRefresh = true;
            foreach (Transform child in transform)
            {
                float i = 0;
                i += 1;
                Destroy(child.gameObject);

            }
        }
	}
     void OnMouseDown()
    {
        Vector3 piecePos= new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
		Instantiate(RampPiece1, piecePos,Quaternion.Euler(0,Rotation+90,0));
	}
	void OnMouseEnter(){
		Vector3 piecePos= new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        if (rotateRefresh == true)
        {
            Instantiate(SelectionBox, piecePos, Quaternion.Euler(90, Rotation, 0), transform);
            rotateRefresh = false;
        }
	}
    void OnMouseExit(){

        foreach (Transform child in transform) {
	    float i = 0;
        i += 1;
        Destroy(child.gameObject);

		}
    }
}
