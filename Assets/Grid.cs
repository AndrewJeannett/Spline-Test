using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
private GameObject [,] grid;
public int GridNum;
public GameObject gridtile;
   


	// Use this for initialization
	void Start () {
		grid = new GameObject [GridNum,GridNum];
		for (int p =0; p<GridNum; p++){
			for (int i = 0; i<GridNum;i++){
				Vector3 tilePos = new Vector3 (-GridNum/2 +p*2,0,-GridNum/2 +i*2);
				  GameObject tile = Instantiate(gridtile, tilePos, Quaternion.Euler(90, 0, 0),gameObject.transform);
				  grid[p, i] = tile; 

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
