using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DetectSwipe : MonoBehaviour
{
    private Vector2 initialPos;

    public SO.Events.EventSO swipeDown;
    public SO.Events.EventSO swipeUp;
    public SO.Events.EventSO swipeLeft;
    public SO.Events.EventSO swipeRight;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Calculate(Input.mousePosition);
        }
    }
    void Calculate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(initialPos.x - finalPos.x);
        float disY = Mathf.Abs(initialPos.y - finalPos.y);
        if (disX > 0 || disY > 0)
        {
            if (disX > disY)
            {
                if (initialPos.x > finalPos.x)
                {
                    Debug.Log("Left");
                    swipeLeft.Raise();
                }
                else
                {
                    Debug.Log("Right");
                    swipeRight.Raise();
                }
            }
            else
            {
                if (initialPos.y > finalPos.y)
                {
                    Debug.Log("Down");
                    swipeDown.Raise();
                }
                else
                {
                    Debug.Log("Up");
                    swipeUp.Raise();
                }
            }
        }
    }
}