using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private float movementY;
    private float movementX;
    [SerializeField] float clampVertical;
    [SerializeField] float clampHorizontal;
    private Vector3 MovementVector;
    [SerializeField] Shoot shootScript;

    private void Update()
    {
        movementY = 0;
        movementX = 0;
        if (Input.GetKey(KeyCode.W) && !(clampVertical < this.transform.position.y))
        {
            movementY = speed;
        }
        if (Input.GetKey(KeyCode.S) && !(clampVertical < -this.transform.position.y))
        {
            movementY = -speed;
        }
        if (Input.GetKey(KeyCode.A) && !(clampHorizontal < -this.transform.position.x))
        {
            movementX = -speed;
        }
        if (Input.GetKey(KeyCode.D) && !(clampHorizontal < this.transform.position.x))
        {
            movementX = speed;
        }
        if(clampHorizontal < this.transform.position.x || clampHorizontal < -this.transform.position.x)
        {
           // movementX = 0;
        }
        MovementVector = new Vector3(movementX, movementY);
        transform.Translate(MovementVector * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootScript.Fire();
        }
    }
}
