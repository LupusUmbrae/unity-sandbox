using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class BuildingController : Interactable
{

	public Material blueprint;

	public Material completed;

	List<BuildingElement> stages = new List<BuildingElement> ();

	public override void interact (Vector3 interactorPosition)
	{
		GetComponent<MeshRenderer> ().material = completed;

	}
}
