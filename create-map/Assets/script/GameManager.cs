using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GameObject> prefabList = new List<GameObject>();
	public List<GameObject> mapLogList = new List<GameObject>();
	public Vector3 nextPosition;
	public string[] codeArr = new string[100];
	public int direction;
	private int firstMapSize;
	GameObject[] gameObjectArr = new GameObject[100];

	void Start () {
		direction = 0;
		firstMapSize = 5;
		StartCoroutine ("initiateMap");
	}
		
	void Update () {

	}

//	IEnumerator loadPrefab(){
//		GameObject curveLeft = Instantiate (Resources.Load ("/Prefabs/curveLeft")) as GameObject;
//		prefabList.Add(curveLeft);
//		GameObject curveRight = Instantiate (Resources.Load ("/Prefabs/curveRight")) as GameObject;
//		prefabList.Add(curveRight);
//		GameObject direct = Instantiate (Resources.Load ("/Prefabs/direct")) as GameObject;
//		prefabList.Add(direct);
//		GameObject downHill = Instantiate (Resources.Load ("/Prefabs/downHill")) as GameObject;
//		prefabList.Add(downHill);
//		GameObject downHillLow = Instantiate (Resources.Load ("/Prefabs/downHillLow")) as GameObject;
//		prefabList.Add(downHillLow);
//		GameObject turnLeft = Instantiate (Resources.Load ("/Prefabs/turnLeft")) as GameObject;
//		prefabList.Add(turnLeft);
//		GameObject turnRight = Instantiate (Resources.Load ("/Prefabs/turnRight")) as GameObject;
//		prefabList.Add(turnRight);
//		GameObject upHill = Instantiate (Resources.Load ("/Prefabs/upHill")) as GameObject;
//		prefabList.Add(upHill);
//		GameObject upHillLow = Instantiate (Resources.Load ("/Prefabs/upHillLow")) as GameObject;
//		prefabList.Add(upHillLow);
//	}
//
	
	IEnumerator searchPatternCorrect(){
		for (int i = 0; i < gameObjectArr.Length; i++) {
			if (codeArr.GetValue()) {
				GameObject recyclePattern = Instantiate (prefabList [int.Parse (code.Substring(i, 1))], new Vector3 (i * 6.0F, 0, 0), Quaternion.identity);
				mapLogList.Add (recyclePattern);
			}
		}
	}

	IEnumerator initiateMap()
	{
		if (code.Length < firstMapSize) {
			for (int i = 0; i < code.Length; i++) {
				GameObject pattern = Instantiate (prefabList [int.Parse (code.Substring(i, 1))], new Vector3 (i * 6.0F, 0, 0), Quaternion.identity);

				mapLogList.Add (pattern);
			}
		} else {
			for (int i = 0; i < firstMapSize; i++) {
				GameObject pattern = Instantiate (prefabList [int.Parse (code.Substring(i, 1))], new Vector3 (i * 6.0F, 0, 0), Quaternion.identity);

				mapLogList.Add (pattern);
			}
			StartCoroutine ("createMap");
		}
		yield return null;
	}

	IEnumerator createMap()
	{
		/*할거*/
		for(int i=firstMapSize;i<code.Length;i++){
			yield return new WaitForSeconds(0.5f); //딜레이
			if (prefabList.Count > int.Parse (code.Substring(i, 1)))
			{
				GameObject pattern = Instantiate(prefabList [int.Parse (code.Substring(i, 1))], new Vector3(i * 6.0F, 0, 0), Quaternion.identity);
				mapLogList.Add (pattern);
			}
		}
	}
}
