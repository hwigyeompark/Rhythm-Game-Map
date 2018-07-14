using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gamemanager : MonoBehaviour {

	public List<GameObject> prefabList;
	public string code;
    private Vector3 nextPosition;
	public List<GameObject> mapLogList;
	// 0: x+ 오른쪽, 1: z- 아랫쪽, 2: x- 왼쪽, 3: z+ 위쪽
	private int nextDirection;
	private int firstMapSize;
	// Use this for initialization
	void Start () {
		nextDirection = 0;
		firstMapSize = 5;
		mapLogList = new List<GameObject>();
		nextPosition = new Vector3 (0, 0, 0);
		StartCoroutine ("initiateMap");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void cameraPosition()
	{
		float lastObjPosZ = mapLogList[mapLogList.Count - 1].transform.position.z;
		if (Camera.current.transform.position.z < lastObjPosZ)
		{
			// ReSharper disable once EmptyForStatement
			for (int i = 0; i < mapLogList.Count; i++)
			{
				mapLogList[i].SetActive(false);
			}
		}
	}
	
	IEnumerator initiateMap()
	{
		int initiateMax = code.Length < firstMapSize ? code.Length : firstMapSize;

		for (int i = 0; i < initiateMax; i++) {
			StartCoroutine("set", int.Parse (code.Substring(i, 1)));
		}
		StartCoroutine ("createMap", initiateMax);

		yield return null;
	}

	IEnumerator createMap(int createdNum)
    {
        /*할거*/
		for(int i=createdNum;i<code.Length;i++){
			yield return new WaitForSeconds(0.5f); //딜레이
			StartCoroutine("set", int.Parse (code.Substring(i, 1)));
		}
	    StartCoroutine("cameraPosition");
    }

	IEnumerator set(int prefabNum){

		Vector3 position = nextPosition;
		int direction = nextDirection;

		switch (prefabNum) {
		case 1:
			nextPosition.y += 2.034F;
			break;
		case 2:
			nextPosition.y -= 2.034F;
			break;
		case 3:
			nextPosition.y += 1.2F;
			break;
		case 4:
			nextPosition.y -= 1.2F;
			break;
		}

		if (prefabNum < 5) {
			if (direction % 2 == 1) {
				nextPosition.z += new int[]{-4, 4}[direction/2];
			}else{
				nextPosition.x += new int[]{4, -4}[direction/2];
			}
		}else if(prefabNum < 7){
			nextPosition.z += new int[]{3, -3, -3, 3}[direction];
			nextPosition.x += new int[]{3, -3}[direction/2];
			nextDirection = (nextDirection + 3)%4;
		}else if(prefabNum < 9){
			nextPosition.x += new int[]{3, -3, -3, 3}[direction];
			nextPosition.z += new int[]{-3, 3}[direction/2];
			nextDirection = (nextDirection + 1)%4;
		}else{
			yield return null;
		}

		GameObject pattern = Instantiate(prefabList [prefabNum], position, Quaternion.Euler(0, direction*90, 0));
		mapLogList.Add (pattern);

		yield return null;
	
	}
}
