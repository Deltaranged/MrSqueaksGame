using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 3f;
    private float scaleFactor = 1f;
    private float sqrt2 = 0.7071f;
    private GameLogicScript gameLogic;
    private Vector3[] movementDirections = new Vector3[4];


    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject
            .FindGameObjectWithTag("Game Logic")
            .GetComponent<GameLogicScript>();

        movementDirections[0] = new Vector3(sqrt2, 0, sqrt2);
        movementDirections[1] = new Vector3(sqrt2, 0, -sqrt2);
        movementDirections[2] = new Vector3(-sqrt2, 0, -sqrt2);
        movementDirections[3] = new Vector3(-sqrt2, 0, sqrt2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        bool isMoving = false;

        if (!gameLogic.isRotating) {
            if (Input.GetKey(KeyCode.W)) {
                Debug.Log("move up");
                direction += movementDirections[
                    gameLogic.currentOrientation
                ];
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.D)) {
                Debug.Log("move right");
                direction += movementDirections[
                    (1 + gameLogic.currentOrientation) % 4
                ];
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S)) {
                Debug.Log("move down");
                direction += movementDirections[
                    (2 + gameLogic.currentOrientation) % 4
                ];
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.A)) {
                Debug.Log("move left");
                direction += movementDirections[
                    (3 + gameLogic.currentOrientation) % 4
                ];
                isMoving = true;
            }

            if (isMoving) {
                moveAndRotate(direction);
            }
        }
    }

    void moveAndRotate(Vector3 direction) {
        // rotate
        Vector3 rotation = Vector3.RotateTowards(transform.forward, direction, 7.0f, 7.0f);
        transform.rotation = Quaternion.LookRotation(rotation) * Quaternion.Euler(0, 90, 0);

        // move
        direction = direction * speed * scaleFactor * Time.deltaTime; 
        transform.position += direction;
    }
}
