using UnityEngine;
using System.Collections;

public class StaticWall : MonoBehaviour {
	
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
	}
	
	void FixedUpdate()
	{
		transform.position = startPosition;
		rigidbody2D.velocity = Vector2.zero;
	}
	
	void LateUpdate()
	{
		transform.position = startPosition;
		rigidbody2D.velocity = Vector2.zero;
	}
}
