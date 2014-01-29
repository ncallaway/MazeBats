using UnityEngine;
using System.Collections;

public class WaveParticleData : MonoBehaviour {
	public Vector3 	Velocity 			{ get; set; }
	public float	Height				{ get; set; }
	public Vector3 	WaveParticleOrigin 	{ get; set; }
	public float 	DispersionAngle		{ get; set; }
	
	public float DistanceFromOrigin
	{
		get { return (WaveParticleOrigin - transform.position).magnitude; }
	}
	
	public float WaveParticleWidth
	{
		get { return Mathf.Deg2Rad * DispersionAngle * DistanceFromOrigin; }
	}
}
