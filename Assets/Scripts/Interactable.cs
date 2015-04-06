using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour
{

	public Texture2D retical;

	public Sprite sprite;

	abstract public void interact (Vector3 interactorPosition, GameObject hitObject);

	public bool interacable = true;

	public Texture2D getRetical ()
	{
		return retical;
	}

	public Sprite getSprite ()
	{
		return sprite;
	}
}
