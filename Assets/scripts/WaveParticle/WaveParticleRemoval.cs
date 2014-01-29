using UnityEngine;
using System.Collections;

public class WaveParticleRemoval : MonoBehaviour {

	private WaveParticleData data;
	
	private void Start()
	{
		data = GetComponent<WaveParticleData>();
		
		if (data == null)
		{
			Debug.LogError("WaveParticleRemoval can't exist on a GameObject without a WaveParticleData. Disabling.");
			enabled = false;
		}
	}
	
	void Update () {
		if (Mathf.Abs(data.Height) < 0.1f)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
