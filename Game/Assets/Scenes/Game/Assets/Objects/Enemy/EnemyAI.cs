using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public NavMeshAgent NavMeshAgent;
    public GameObject ExplosionEffect;
    public float Health = 1f;
    public Vector3 Destination = new Vector3(0, 0, 0);

    void Start () {
        NavMeshAgent = this.GetComponent<NavMeshAgent>();

        NavMeshAgent.SetDestination(Destination);
    }
	
    void Update()
    {

        float DestinationDistance = Vector3.Distance(Destination, transform.position);
        if (DestinationDistance <= 4)
        {
            Explode();
        }
    }

    private void Explode()
    {
        //Explode
        Debug.Log(gameObject.name + " Destroyed the core!");
        GameObject EffectObject = Instantiate(ExplosionEffect, new Vector3(0f,3.5f,0f), new Quaternion(0,3.5f,0,0));
        Destroy(EffectObject, 2);
        Destroy(gameObject);

        //End Game
        var GameOverObject = GameObject.FindWithTag("GameOver");
        GameOverObject.GetComponent<GameOver>().EndGame();

    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
