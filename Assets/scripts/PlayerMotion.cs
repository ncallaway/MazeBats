using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {
	
	float playerSpeed = 2;
	
	void Update () {
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.smoothDeltaTime);
		transform.Translate(Vector3.up    * Input.GetAxis("Vertical")   * playerSpeed * Time.smoothDeltaTime);
	}
}
