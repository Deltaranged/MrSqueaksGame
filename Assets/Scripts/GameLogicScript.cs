using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// which direction the camera is facing
// pressing right = +1 to enum
public enum orientation {
   North,
   East,
   South,
   West
};

// GameObject meant to hold flags for game logic
public class GameLogicScript : MonoBehaviour
{
    public bool isRotating = false;  // if world is currently rotating, disable inputs
    public int currentOrientation;  // integer corresponding to current orientation, maps to enum above

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
