using UnityEngine;
using System.Collections;

public class MarkerController : MonoBehaviour
{
	void Awake ()
	{
		Debug.Log ("The sleeper has awoken!");
		Destroy (this.gameObject, 5.0f);
	}
}
