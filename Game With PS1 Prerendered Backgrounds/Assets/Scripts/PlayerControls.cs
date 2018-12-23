using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public string forwardButton;
	public string backwardButton;
	public string turnLeftButton;
	public string turnRightButton;

	public float turnRate;
	public float walkSpeed;

	public CharacterController controller;
	public Transform t;

	private Vector3 turnDir;
	private float cosTur;
	private float turnAngle;
	private float sinTur;
	private float turnRateRad;

	// Start is called before the first frame update
	void Start()
	{
		controller = GetComponent<CharacterController>();
		t = GetComponent<Transform>();
		turnDir = Vector3.zero;
		turnRateRad = turnRate / 180f * Mathf.PI;
		turnAngle = Mathf.PI / 2f;
		cosTur = Mathf.Cos(turnAngle);
		sinTur = Mathf.Sin(turnAngle);
	}

	// Update is called once per frame
	void Update()
	{
		bool wKey = Input.GetKey(forwardButton);
		bool sKey = Input.GetKey(backwardButton);
		bool aKey = Input.GetKey(turnLeftButton);
		bool dKey = Input.GetKey(turnRightButton);

		turnDir = new Vector3(cosTur, 0, sinTur);

		if (wKey == true)
		{
			controller.Move(turnDir * walkSpeed);
			Debug.Log("I moved forward");
		}
		if (sKey == true)
		{
			controller.Move(turnDir * -walkSpeed * 0.5f);
			Debug.Log("I moved backward");
		}

		if (aKey == true)
		{
			transform.Rotate(0, -turnRate, 0);
			turnAngle = turnAngle + turnRateRad;
			cosTur = Mathf.Cos(turnAngle);
			sinTur = Mathf.Sin(turnAngle);
		}
		if (dKey == true)
		{
			transform.Rotate(0, turnRate, 0);
			turnAngle = turnAngle - turnRateRad;
			cosTur = Mathf.Cos(turnAngle);
			sinTur = Mathf.Sin(turnAngle);
		}
	}
}
