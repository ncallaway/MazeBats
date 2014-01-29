using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WaveParticleData))]
public class WaveParticleSplitter : MonoBehaviour {
	
	private const int DISTANCE_TO_SPLIT = 2;
	private const int DISTANCE_TO_DESTROY = 25;

	private WaveParticleData data;
	
	private void Start()
	{
		data = GetComponent<WaveParticleData>();
		
		if (data == null)
		{
			Debug.LogError("WaveParticleSplitter can't exist on a GameObject without a WaveParticleData. Disabling.");
			enabled = false;
		}
	}
	
	private void Update () {
		
		if (data.WaveParticleWidth > DISTANCE_TO_SPLIT)
		{
			// calculate the position of the new particles
			Quaternion aRotation = Quaternion.AngleAxis(data.DispersionAngle / 2, Vector3.forward);
			Quaternion bRotation = Quaternion.AngleAxis(data.DispersionAngle / 2, Vector3.forward);
			
			Vector3 particlePosition = transform.position - data.WaveParticleOrigin;
			Vector3 aPosition = (aRotation * particlePosition) + data.WaveParticleOrigin;
			Vector3 bPosition = (bRotation * particlePosition) + data.WaveParticleOrigin;
			
			Vector3 aVelocity = aRotation * data.Velocity;
			Vector3 bVelocity = bRotation * data.Velocity;
			
			// reduce dispersion angle and amplitude by 1/3
			data.Height /= 3;
			data.DispersionAngle /= 3;
			
			WaveParticleData aParticle = ((GameObject)GameObject.Instantiate(gameObject)).GetComponent<WaveParticleData>();
			WaveParticleData bParticle = ((GameObject)GameObject.Instantiate(gameObject)).GetComponent<WaveParticleData>();
			
			aParticle.transform.position = aPosition;
			bParticle.transform.position = bPosition;
			
			// set waveparticledata
			aParticle.Velocity = aVelocity;
			bParticle.Velocity = bVelocity;
			aParticle.Height = data.Height;
			bParticle.Height = data.Height;
			aParticle.WaveParticleOrigin = data.WaveParticleOrigin;
			bParticle.WaveParticleOrigin = data.WaveParticleOrigin;
			aParticle.DispersionAngle = data.DispersionAngle;
			bParticle.DispersionAngle = data.DispersionAngle;
		}
		
		Vector3 deltaFromCamera = transform.position - Camera.main.transform.position;
		if (Mathf.Abs(deltaFromCamera.x) > DISTANCE_TO_DESTROY || Mathf.Abs(deltaFromCamera.y) > DISTANCE_TO_DESTROY) {
			Destroy(this.gameObject);
		}
	}
}
