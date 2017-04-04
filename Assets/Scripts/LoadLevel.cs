using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

	public GameObject start;
	public GameObject end;
	public GameObject platform;
	public GameObject hole;
	public GameObject wallBlock;
	int[][] testplan;
	// Use this for initialization
	void Start () {
		//int[][] testplan = [[0,4,2,4,0],[0,4,3,4,0],[0,4,3,4,4],[0,4,3,3,1],[0,4,4,4,4],[0,0,0,0,0]];
		testplan = new int[][] {new int[] {0,4,2,4,0},new int[] {0,4,3,4,0},new int[] {0,4,3,4,4},new int[] {0,4,3,3,1},new int[] {0,4,4,4,4},new int[] {0,0,0,0,0}};

		initCourtForPlan (testplan);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void initCourtForPlan(int[][] plan) {
		int xPos = 0;
		int zPos = 0;
		Vector3 currentPosition;
		foreach (int[] row in plan) {
			foreach(int col in row) {
				GameObject currentElement;
				switch (col) {
				case 1:	
					currentElement = start; 
					break;
				case 2:
					currentElement = end;
					break;
				case 3:
					currentElement = platform;
					break;
				case 4:
					currentElement = wallBlock;
					break;
				default:
					currentElement = null;
					break;
				}
				currentPosition = new Vector3 (this.transform.position.x + xPos,this.transform.position.y +  0,this.transform.position.z + zPos);
				if (currentElement != null) {
					Instantiate (currentElement, currentPosition, transform.rotation).transform.SetParent (this.gameObject.transform);
				}
				xPos += 10;

			} //End Col
			xPos = 0;
			zPos += 10;
		} // End Row
	}
}
