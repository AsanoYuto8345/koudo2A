using UnityEngine;

public class GestureAction : MonoBehaviour
{
    [SerializeField]
    public string gestureName;

    [SerializeField]
    public bool isGestureActive = false;

    [SerializeField]
    GameObject hand;

    Vector3 handInitialPosition;

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
        return hand.transform.position.z - handInitialPosition.z > vector.z &&
               hand.transform.position.y - handInitialPosition.y > vector.y &&
               hand.transform.position.x - handInitialPosition.x > vector.x;
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
