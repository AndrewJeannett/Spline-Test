using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacement : MonoBehaviour
{
    public GameObject[] RampPiece;
    public GameObject[] SelectionBox;
    public GameObject[] Supports;
    public GameObject[] SupportShadow;
    private int PieceType;
    private int Rotation;
    private int PieceHeight;
   

    // Use this for initialization
    void Start()
    {
        Rotation = 90;
    }
    public void Update()
    {

        if (Input.GetButtonDown("Fire3"))
        {

            PieceType++;
            if (PieceType >= RampPiece.Length)
            {
                PieceType = 0;

            }
            if (transform.childCount > 0)
            {
                Debug.Log("call");
                Destroy(transform.GetChild(0).gameObject);
                ShadowPiece();
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            Rotation += 90;
            Debug.Log("rotate");
            transform.GetChild(0).rotation = Quaternion.Euler(0, Rotation + 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PieceHeight += 1;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PieceHeight -= 1;

        }
    }
    void OnMouseDown()
    {
        RegPiece();
    }
    void OnMouseEnter()
    {
        
        ShadowPiece();


    }
    void RegPiece(){
        
            Vector3 piecePos = new Vector3(transform.position.x, transform.position.y + .1f + PieceHeight, transform.position.z);
            Instantiate(RampPiece[PieceType], piecePos, Quaternion.Euler(0, Rotation + 90, 0));
            for (int i = 1; i <= PieceHeight; i++)
            {
                Vector3 SupportPos = new Vector3(transform.position.x, transform.position.y + .1f + PieceHeight - i, transform.position.z);
                Instantiate(Supports[PieceType], SupportPos, Quaternion.Euler(0, Rotation + 90, 0));
            }
        
    }

    void ShadowPiece()
    {
        Vector3 piecePos = new Vector3(transform.position.x, transform.position.y + .1f + PieceHeight, transform.position.z);

        Instantiate(SelectionBox[PieceType], piecePos, Quaternion.Euler(0, Rotation + 90, 0), transform);
        for (int i = 1; i <= PieceHeight; i++)
        {
            Vector3 SupportPos = new Vector3(transform.position.x, transform.position.y + .1f + PieceHeight-i, transform.position.z);
            Instantiate(SupportShadow[PieceType], SupportPos, Quaternion.Euler(0, Rotation + 90, 0), transform);
        }
        
    }
    void OnMouseExit()
    {
        if (transform.childCount > 0)
        {
            
            foreach(Transform child in transform)
            Destroy(child.gameObject);
        }
        // foreach (Transform dick in transform) {
        // float i = 0;
        // i += 1;
        // Destroy(dick.gameObject);

    }
}

