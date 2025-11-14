using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    bool isHandStanding = false;

    [SerializeField]
    GameObject hand;

    Vector3 handInitialPosition;

    void Start() {
    }

    void Update() {
        // explosion
        if (isHandStanding) {
            if (hand.transform.position.z - handInitialPosition.z > 0.2f) {
                Debug.Log("Distance is greater than 0.2f, triggering explosion");
            }
        }
    }

    public void setHandStandingTrue() {
        isHandStanding = true;
        handInitialPosition = hand.transform.position;
    }

    public void setHandStanding(bool standing) {
        isHandStanding = standing;
    }

    public bool getHandStanding() {
        return isHandStanding;
    }
}
