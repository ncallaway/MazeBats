using UnityEngine;
using System.Collections;

public class WaveParticleGenerator : MonoBehaviour {
	
	private const int NUMBER_PARTICLES_PER_SPAWN = 64;
	
	public float frequency = 1;
	public float amplitude = 1;
	public float speed = 1;
	
	public WaveParticleData prefab;
	
	public float Period
	{
		get
		{
			if (frequency == 0)
			{
				return Mathf.Infinity;
			}
			
			return 1 / frequency;
		}
	}
	
	private float nextSpawnTime;
	private float nextSpawnAmplitude;
	
	private void Start ()
	{	
		nextSpawnTime = Time.time + Period / 4;
		nextSpawnAmplitude = amplitude;
	}
	
	private void Update ()
	{
		if (Time.time > nextSpawnTime)
		{
			Spawn();
		}
	}
	
	private void Spawn()
	{
		float spawnHeight = nextSpawnAmplitude;
		
		nextSpawnTime = nextSpawnTime + Period / 2;
		nextSpawnAmplitude = -nextSpawnAmplitude;
		
		// Spawn some new particles
		for (int i = 0; i < NUMBER_PARTICLES_PER_SPAWN; i++)
		{
			Quaternion rotation = Quaternion.AngleAxis( (float)i * ((float)360 / ((float)NUMBER_PARTICLES_PER_SPAWN)), Vector3.forward );
			
			Vector3 direction = rotation * Vector3.up;
			
			WaveParticleData newParticle = (WaveParticleData)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
			
			newParticle.Velocity			= direction * speed;
			newParticle.Height				= spawnHeight;
			newParticle.WaveParticleOrigin	= transform.position;
			newParticle.DispersionAngle		= 390 / NUMBER_PARTICLES_PER_SPAWN;
		}
	}
}
