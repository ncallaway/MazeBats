using UnityEngine;
using System.Collections;

public class WaveParticleGenerator : MonoBehaviour {
	
	public float particles = 32;
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
	
	public void StartSpawning()
	{
		nextSpawnTime = Time.time + Period / 4;
		nextSpawnAmplitude = amplitude;
	}
	
	public void StopSpawning()
	{
		nextSpawnTime = Mathf.Infinity;
	}
	
	private void Start ()
	{	
		StopSpawning();
	}
	
	private void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartSpawning();
		}
		
		if (Input.GetKeyUp(KeyCode.Space))
		{
			StopSpawning();
		}
		
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
		for (int i = 0; i < particles; i++)
		{
			Quaternion rotation = Quaternion.AngleAxis( (float)i * ((float)360 / ((float)particles)), Vector3.forward );
			
			Vector3 direction = rotation * Vector3.up;
			
			WaveParticleData newParticle = (WaveParticleData)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
			
			newParticle.Velocity			= direction * speed;
			newParticle.Height				= spawnHeight;
			newParticle.WaveParticleOrigin	= transform.position;
			newParticle.DispersionAngle		= (float)358 / (float)particles;
		}
	}
}
