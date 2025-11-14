using UnityEngine;
using UnityEngine.Events;
using System;

public class GestureAction : MonoBehaviour
{
    [SerializeField]
    public string gestureName;

    [SerializeField]
    public bool isGestureActive = false;

    [SerializeField]
    GameObject hand;

    Vector3 handInitialPosition;
    public UnityEvent Action;

    void Start()
    {
    }

    void Update()
    {
        if (isGestureActive)
        {
            switch (gestureName)
            {
                case "OpenHand":
                    Debug.Log("Open Hand Gesture Activated");
                    if (MovedOverVector(new Vector3(0, 0, 0.2f)))
                    {
                        Action?.Invoke();
                    }
                    break;
                case "Fist":
                    Debug.Log("Fist Gesture Activated");
                    break;
                case "Shild":
                    Debug.Log("Shield Gesture Activated");
                    break;
                case "Lightbulb":
                    Debug.Log("Lightbulb Gesture Activated");
                    break;
            }
        }
    }

    private bool MovedOverVector(Vector3 vector)
    {
        return Math.Abs(hand.transform.position.z - handInitialPosition.z + vector.z) >= Math.Abs(vector.z * 2) &&
               Math.Abs(hand.transform.position.y - handInitialPosition.y + vector.y) >= Math.Abs(vector.y * 2) &&
               Math.Abs(hand.transform.position.x - handInitialPosition.x + vector.x) >= Math.Abs(vector.x * 2);
    }

    public void ActivateGesture()
    {
        isGestureActive = true;
        handInitialPosition = hand.transform.position;
    }

    public void InactivateGesture()
    {
        isGestureActive = false;
    }

}
