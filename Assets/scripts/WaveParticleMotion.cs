using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WaveParticleData))]
public class WaveParticleMotion : MonoBehaviour {

	private WaveParticleData data;
	
	private void Start()
	{
		data = GetComponent<WaveParticleData>();
		
		if (data == null)
		{
			Debug.LogError("WaveParticleMotion can't exist on a GameObject without a WaveParticleData. Disabling.");
			enabled = false;
		}
	}
	
	private void Update()
	{
		transform.position += data.Velocity * Time.smoothDeltaTime;
	}
}
