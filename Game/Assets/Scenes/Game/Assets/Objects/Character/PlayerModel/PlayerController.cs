using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Velocity = 10.0F;

	
	void Update () {

        float Translation = Input.GetAxis("Vertical") * Velocity * Time.deltaTime;
        float Strafe = Input.GetAxis("Horizontal") * Velocity * Time.deltaTime;
        //float Jump = Input.GetAxis("Jump") * JumpForce * Time.deltaTime;

        transform.Translate(Strafe, 0, Translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            

    }

}