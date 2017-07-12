using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour {
	public float timeDelay;

	public GameObject Character;

	public float grappleSpeed;

	public int distanceMiss;

	private Vector3 OriginPoint;

	private float t = 0;

	private Vector3 target;

	private Vector3 startingPoint;
	private GameObject Hook;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}
	public Vector3 Target {

		get{ return target; }
		set {
			target = value;

			StopCoroutine ("StartSendingGrapple");

			StopCoroutine ("StartReturningGrapple");
			if (startingPoint == Hook.transform.position) {
				StartCoroutine ("StartReturningGrapple");
			} else {
				StartCoroutine ("StartSendingGrapple");
			}
		}
	}
	IEnumerator StartSendingGrapple(){
		Vector3 maximum = target;
		Vector3 minimum = startingPoint;
		t = 0;
		while (this.transform.position != target) {
			this.transform.position = new Vector3 (Mathf.Lerp (minimum.x, maximum.x, t),
				Mathf.Lerp (minimum.y, maximum.y, t), 0);
			t += grappleSpeed * Time.deltaTime;
			yield return null;
		}

	}
	IEnumerator StartReturningGrapple(){
		Vector3 maximum = target;
		Vector3 minimum = startingPoint;
		t = 0;
		while (this.transform.position != target) {
			this.transform.position = new Vector3 (Mathf.Lerp (minimum.x, maximum.x, t),
				Mathf.Lerp (minimum.y, maximum.y, t), 0);
			t += grappleSpeed * Time.deltaTime;
			if(Character.transform.position != target){
				maximum = Character.transform.position;
			}
			yield return null;
		}

	}

	public bool SendGrapple () {
		/*Vector3 temp = Grapple.transform.position;
		temp.x += distanceMiss;
		temp.y += distanceMiss;
		target = temp;
		OriginPoint = Grapple.transform.position;
		startingPoint = OriginPoint;
		StartCoroutine ("StartSendingGrapple");
	*/
		return false;}
	public bool SendGrapple (GameObject passedTarget){
		Hook = passedTarget;
		startingPoint = this.transform.position;
		Target = passedTarget.transform.position;
		return true;
	}
	public bool DetachGrapple (){
		startingPoint = Hook.transform.position;
		Target = Character.transform.position;
		return false;
	}
}
