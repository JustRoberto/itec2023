using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startTransform; // starting position
    public Transform endTransform; // ending position
    public float duration = 2f; // duration of interpolation

    private float startTime; // time at which interpolation starts
    private bool isMoving = false; // flag to track if the object is currently being moved

    public void StartMoving()
    {
        if (!isMoving)
        {
            startTime = Time.time;
            isMoving = true;
            SmoothlyMove();
        }
    }

    void SmoothlyMove()
    {
        float timeSinceStart = Time.time - startTime;
        float t = Mathf.Clamp01(timeSinceStart / duration); // ensures t is between 0 and 1

        // interpolate between the two positions using Lerp
        transform.position = Vector3.Lerp(startTransform.position, endTransform.position, t);

        if (t < 1f)
        {
            // if the interpolation is not yet complete, schedule another call to this function
            Invoke("SmoothlyMove", Time.deltaTime);
        }
        else
        {
            isMoving = false;
        }
    }
}
