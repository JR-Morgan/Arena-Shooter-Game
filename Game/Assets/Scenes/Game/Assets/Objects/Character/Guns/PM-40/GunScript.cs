using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

    public float Damage = 10f;
    //public float ImpactForce = 100f;
    public float FireRate = 7.5f;

    public Camera Cam;
    public ParticleSystem Flash;
    public GameObject ImpactEffect;
    public Text KillCounter0;
    public Text KillCounter1;

    private float NextTimeToFire = 0f;
    private int KillCount = 0;

    void Update() {
        if (Input.GetButtonDown("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        
        //Raycast
        Flash.Play();
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit)) {
            Debug.Log(hit.transform.name);

            EnemyAI target = hit.transform.GetComponent<EnemyAI>();
            if (target != null)
            {
                //If an Enemy was hit
                target.TakeDamage(Damage);

                KillCount += 1;
                KillCounter0.text = KillCount + "";
                KillCounter1.text = KillCount + "";

            }

            //if (hit.rigidbody != null)
            //{
            //    hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            //}


            GameObject ImpactObject = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactObject, 2);
        }
    }

}
