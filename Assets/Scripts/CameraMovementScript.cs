using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public float duration = 0.75f;
    public AnimationCurve animationCurve;

    private Vector3 origin = new Vector3(0, 0, 0);
    private GameLogicScript gameLogic;

    // coroutine to rotate camera around origin
    // https://medium.com/@rhysp/lerping-with-coroutines-and-animation-curves-4185b30f6002
    IEnumerator revolveCamera(bool clockWise) {
        gameLogic.isRotating = true;
        float arc = 0.0f;  // from 0 to 90 degrees
        float journey = 0.0f;  // from 0 to duration
        int rotateDirection = 1;
        if (clockWise) {
            rotateDirection = -1;
        }

        while (arc < 90.0f) {
            journey += Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);
            float curvePercent = animationCurve.Evaluate(percent);

            float arcSegment = Mathf.Min((90.0f * curvePercent), 90.0f) - arc;
            arc += arcSegment;
            transform.RotateAround(origin, Vector3.up, rotateDirection * arcSegment);

            yield return null;
        }

        gameLogic.isRotating = false;
        gameLogic.currentOrientation = Utils.indexMod(
            (gameLogic.currentOrientation + rotateDirection), 4
        );
    }
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject
            .FindGameObjectWithTag("Game Logic")
            .GetComponent<GameLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameLogic.isRotating) {
            if (Input.GetKey(KeyCode.RightArrow)) {
                Debug.Log("move camera right");
                StartCoroutine(revolveCamera(false));
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                Debug.Log("move camera left");
                StartCoroutine(revolveCamera(true));
            }
        }
    }
}
