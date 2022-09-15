using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera Eyes;
    public Rigidbody RB;
    public float MouseSensitivity = 2;
    public float WalkSpeed = 10;
    public List<GameObject> Floors;
    public string CurrentLevel = "Deep Sleep";
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

 
    void Update()
    {

        float xRot = Input.GetAxis("Mouse X") * MouseSensitivity;
        float yRot = -Input.GetAxis("Mouse Y") * MouseSensitivity;

        transform.Rotate(0, xRot, 0);
        Eyes.transform.Rotate(yRot, 0, 0);

        if (WalkSpeed > 0)
        {
            Vector3 move = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                move += transform.forward;
            if (Input.GetKey(KeyCode.S))
                move -= transform.forward;
            if (Input.GetKey(KeyCode.A))
                move -= transform.right;
            if (Input.GetKey(KeyCode.D))
                move += transform.right;

            move = move.normalized * WalkSpeed;

            RB.velocity = move;
        }
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(CurrentLevel);


    }
}
