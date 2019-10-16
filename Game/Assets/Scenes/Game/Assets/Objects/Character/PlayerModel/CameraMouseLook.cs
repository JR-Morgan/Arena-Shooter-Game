using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour {

    public float Sensitivity = 2.0f;

    private Vector2 MouseLook;
    private Vector2 SmoothV;

    private GameObject character;

	void Start () {
        character = this.transform.parent.gameObject;

        //Make Cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	void Update () {

        //Get new vector
        var VectorDelta = new Vector2(Input.GetAxisRaw("Mouse X") * Sensitivity, Input.GetAxisRaw("Mouse Y") * Sensitivity);


        //Difference between new vector and current vector
        SmoothV.x = Mathf.Lerp(SmoothV.x, VectorDelta.x, 1f);
        SmoothV.y = Mathf.Lerp(SmoothV.y, VectorDelta.y, 1f);

        MouseLook += SmoothV;
        MouseLook.y = Mathf.Clamp(MouseLook.y, -90f, 90f);

        //Apply transformation
        transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, Vector3.up);

    }
}
