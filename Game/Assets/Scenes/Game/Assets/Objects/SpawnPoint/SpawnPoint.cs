using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public float EnemySpawnDelay = 10f;
    public float DifficutlyScaler = 10f;
    public GameObject Enemy;

    private float NextTimeToSpawn = 0f;
    private float NextTimeToDifficulty = 0f;

    // Update is called once per frame
    void Update () {
		if( Time.time >= NextTimeToSpawn)
        {
            //Enemy spawn
            NextTimeToSpawn = Time.time + EnemySpawnDelay;
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }

        if (Time.time >= NextTimeToDifficulty)
        {
            //Spawnrate Increase
            NextTimeToDifficulty = Time.time + DifficutlyScaler;
            EnemySpawnDelay = EnemySpawnDelay * 0.9f;
            Debug.Log(gameObject + "Has increased its spawning to every " + EnemySpawnDelay + " secconds");
        }

    }
}
