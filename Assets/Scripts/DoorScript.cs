using UnityEngine;
using System.Collections;

public class DoorScript : Interactable
{
	private Animator anim;

	private bool open = false;

	void Awake ()
	{
		anim = GetComponent<Animator> ();
	}


	public override void interact (Vector3 interactorPosition, GameObject hitObject)
	{
		bool inwards = transform.position.z > interactorPosition.z;
		if (open) {
			anim.SetBool ("OpenCloseDoorInwards", false);
			anim.SetBool ("OpenCloseDoorOutwards", false);
		} else if (inwards) {
			anim.SetBool ("OpenCloseDoorInwards", true);
		} else {
			anim.SetBool ("OpenCloseDoorOutwards", true);
		}

		open = !open;
	}
}
