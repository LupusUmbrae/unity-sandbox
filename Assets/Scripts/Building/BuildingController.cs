using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class BuildingController : Interactable
{

	public GameObject blueprint;

	public BuildingStages stages;

	public GameObject completed;

	private bool blueprintPlaced;

	private bool buildingFinished;


	void Start ()
	{
		blueprint.SetActive (true);
		completed.SetActive (false);
	}

	void Update ()
	{
		if (stages.hasFinished ()) {
			completed.SetActive (true);
			stages.complete ();
			buildingFinished = true;
		}
	}

	public override void interact (Vector3 interactorPosition, GameObject hitObject)
	{
		if (!blueprintPlaced) {
			blueprint.SetActive (false);
			stages.next ();
			this.blueprintPlaced = true;
			this.interacable = false;
		} else if (blueprintPlaced) {
			Interactable interactable = hitObject.GetComponent<Interactable> ();
			if (interactable != null) {
				interactable.interact (interactorPosition, hitObject);
			}
		} else if (buildingFinished) {
			// TODO: Building interaction
		}
	}
}
