using UnityEngine;
using System.Collections;

public class BuildingStages : MonoBehaviour {

	private GameObject[] components;
	private GameObject curStage;
	private int cur = 0;

	// Use this for initialization
	void Start () {
		Transform transform = GetComponent<Transform> ();
		Debug.Log (transform.childCount);
		components = new GameObject[transform.childCount];
		for(int i = 0 ; i < transform.childCount; i++)
		{
			components[i] = transform.GetChild(i).gameObject;
			components[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (curStage != null) {
			BuildingElement[] elements = curStage.GetComponentsInChildren<BuildingElement> ();

			bool stageComplete = true;
			foreach (BuildingElement element in elements) {
				stageComplete &= element.completed;
			}

			if (stageComplete && !hasFinished()) {
				next ();
			}
		}
	}

	public void next()
	{
		if(cur < components.Length)
		{
			curStage = components [cur];
			curStage.SetActive (true);
		}
		cur++;
	}

	public void complete()
	{
		for(int i = 0 ; i < components.Length; i++)
		{
			components[i].SetActive(false);
		}
	}

	public bool hasFinished()
	{
		return (cur > components.Length);
	}
}
