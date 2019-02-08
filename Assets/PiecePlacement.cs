using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacement : MonoBehaviour
{
    public GameObject RampPiece1;
    public GameObject SelectionBox;
    private int Rotation;

    // Use this for initialization
    void Start()
    {
        Rotation = 90;
    }
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Rotation += 90;
            Debug.Log("rotate");
            transform.GetChild(0).rotation = Quaternion.Euler(0, Rotation+90, 0);
        }
    }
    void OnMouseDown()
    {
        Vector3 piecePos = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        Instantiate(RampPiece1, piecePos, Quaternion.Euler(0, Rotation + 90, 0));
    }
    void OnMouseEnter()
    {
        Vector3 piecePos = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);

        Instantiate(SelectionBox, piecePos, Quaternion.Euler(0, Rotation+90, 0), transform);


    }
    void OnMouseExit()
    {

        Destroy(transform.GetChild(0).gameObject);
        // foreach (Transform dick in transform) {
        // float i = 0;
        // i += 1;
        // Destroy(dick.gameObject);

    }
}

