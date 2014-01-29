using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WaveParticleData))]
public class WaveParticleVertexColor : MonoBehaviour {
	
	public Material up;
	public Material down;
	
	private WaveParticleData data;
	
	private void Start()
	{
		data = GetComponent<WaveParticleData>();
		
		if (data == null)
		{
			Debug.LogError("WaveParticleMotion can't exist on a GameObject without a WaveParticleData. Disabling.");
			enabled = false;
			return;
		}
		
		renderer.sharedMaterial = (data.Height > 0) ? up : down;
	}
}
