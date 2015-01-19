using UnityEngine;
using System.Collections;

public class SpawningMixedBerries : MonoBehaviour {

	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] mixedBerries;		// Array of berry prefabs.
	
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}//Start()
	
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, mixedBerries.Length);
		Instantiate(mixedBerries[enemyIndex], transform.position, transform.rotation);
		
		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}//foreach
	}// Spawn ()
}//class
