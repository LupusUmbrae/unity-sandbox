using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float crouchSpeed;
	public float walkSpeed;
	public float runSpeed;
	public float maxInteractDistance;

	public float mouseLookSpeed;

	public float strafeSpeed;
	public float turnSpeed;

	public Transform markerPrefab;


	private float vertical;
	private float horizontal;
	float rotationY = 0F;

	private Retical retical;

	private Interactable curInteractable;
	private GameObject hitObject;

	// Ray casting and interactable details
	private float interactDistance;
	private Vector3 rayPoint;

	void Awake ()
	{
		retical = GetComponent<Retical> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (horizontal * strafeSpeed * Time.deltaTime, 0.0f, vertical * walkSpeed * Time.deltaTime);
		GetComponent<Rigidbody> ().AddRelativeForce (movement);

	}

	void Update ()
	{
		vertical = Input.GetAxis ("Vertical");
		horizontal = Input.GetAxis ("Horizontal");

		bool interact = Input.GetButtonDown ("Interact");
		bool tag = Input.GetButtonDown ("Tag");

		handleMouse ();

		if (interact && curInteractable != null && interactDistance <= maxInteractDistance) {
			curInteractable.interact (transform.position, hitObject);
		}

		if (tag && curInteractable != null) {
			Transform clone;
			clone = Instantiate (markerPrefab, rayPoint, Quaternion.identity) as Transform;
			Debug.Log (clone);
			clone.GetComponent<SpriteRenderer> ().sprite = curInteractable.getSprite ();

		}

	

		RaycastHit hit;
		if (Physics.Raycast (transform.FindChild ("Main Camera").position, transform.FindChild ("Main Camera").forward, out hit)) {
			Interactable interactable = hit.collider.gameObject.transform.root.GetComponent<Interactable> ();

			rayPoint = hit.point;
			if (interactable != null) {
				hitObject = hit.collider.gameObject;
//				Debug.Log("Found: " + hitObject);
				interactDistance = hit.distance;

				curInteractable = interactable;
				retical.setTexture (interactable.getRetical ());
			}
		} else {
			curInteractable = null;
			retical.resetTexture ();
		}
	}

	void handleMouse ()
	{
		Quaternion xRotation = Quaternion.AngleAxis (Input.GetAxisRaw ("Mouse X") * turnSpeed, transform.up);
		transform.localRotation *= xRotation;


		rotationY += Input.GetAxis ("Mouse Y") * mouseLookSpeed;
		rotationY = Mathf.Clamp (rotationY, -45, 45);
		
		transform.FindChild ("Main Camera").transform.localEulerAngles = new Vector3 (-rotationY, transform.FindChild ("Main Camera").transform.localEulerAngles.y, 0);
	}
}
