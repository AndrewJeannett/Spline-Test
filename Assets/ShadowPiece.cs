using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPiece : MonoBehaviour {
    public Material ShadowMat;
    private bool legal;
	// Use this for initialization
	void Start () {
        legal = false;
	}
    void OnTriggerEnter(Collider other)
    {
        GameObject StartPiece = GameObject.FindGameObjectWithTag("StartPiece");
        if (other.gameObject.transform.parent == StartPiece.transform) 
        {
            legal = true;
           
        }
       
    }
    void OnTriggerExit(Collider other)
    {
        GameObject StartPiece = GameObject.FindGameObjectWithTag("StartPiece");
        if (other.gameObject.transform.parent == StartPiece.transform)
        {
            legal = false;

        }
    }
    
    // Update is called once per frame
    void Update () {
		if (legal)
        {
            Debug.Log("color change");
            ShadowMat.SetColor("_Color", Color.green);
        }
        if (legal == false)
        {
            ShadowMat.SetColor("_Color", Color.red);
        }
	}
}
