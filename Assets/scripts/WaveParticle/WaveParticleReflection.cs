using UnityEngine;
using System.Collections;

public class WaveParticleReflection : MonoBehaviour {
	
	public float energyLoss = 0.7f;

	private WaveParticleData data;
	
	private void Start()
	{
		data = GetComponent<WaveParticleData>();
		
		if (data == null)
		{
			Debug.LogError("WaveParticleReflection can't exist on a GameObject without a WaveParticleData. Disabling.");
			enabled = false;
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.contacts.Length == 0)
		{
			return;
		}
		
		Vector2 normalSum = Vector2.zero;
		foreach (ContactPoint2D contactPoint in collision.contacts)
		{
			normalSum += contactPoint.normal;
		}
		Vector3 normalAverage = (normalSum / collision.contacts.Length).normalized;
		Vector3 delta = transform.position - data.WaveParticleOrigin;
		
		// Adjust velocity
		data.Velocity = data.Velocity - (2*normalAverage*(Vector3.Dot (normalAverage, data.Velocity)));
		
		// Mirror the origin
		data.WaveParticleOrigin = data.WaveParticleOrigin + (2*normalAverage*(Vector3.Dot (normalAverage, delta)));
		
		// Damage the amplitude
		data.Height *= energyLoss;
	}
}
