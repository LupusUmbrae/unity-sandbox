using UnityEngine;
using System.Collections;

public class Retical : MonoBehaviour
{
	public Texture2D baseTexture;

	private Texture2D crosshairTexture;
	public float crosshairScale = 1;
	void OnGUI ()
	{
		//if not paused
		if (Time.timeScale != 0) {
			if (crosshairTexture != null)
				GUI.DrawTexture (new Rect ((Screen.width - crosshairTexture.width * crosshairScale) / 2, 
				                           (Screen.height - crosshairTexture.height * crosshairScale) / 2,
				                           crosshairTexture.width * crosshairScale, 
				                           crosshairTexture.height * crosshairScale), crosshairTexture);
			else
				Debug.Log ("No crosshair texture set in the Inspector");
		}
	}

	public void setTexture (Texture2D nexTexture)
	{
		if (nexTexture != null) {
			crosshairTexture = nexTexture;
		}
	}

	public void resetTexture ()
	{
		crosshairTexture = baseTexture;
	}

	void Awake ()
	{
		crosshairTexture = baseTexture;
	}
}
