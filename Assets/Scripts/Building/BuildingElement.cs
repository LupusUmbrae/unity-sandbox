using UnityEngine;
using System.Collections;

public class BuildingElement : Interactable 
{

	public Material completedMaterial;

	public bool completed;

	
	public override void interact (Vector3 interactorPosition, GameObject hitObject)
	{
		this.GetComponent<MeshRenderer> ().material = completedMaterial;
		completed = true;
	}

}
