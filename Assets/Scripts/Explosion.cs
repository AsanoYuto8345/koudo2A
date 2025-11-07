using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    bool isHandStanding = false;

    void Start() {
    }

    void Update() {
    }

    public void setHandStanding(bool standing) {
        isHandStanding = standing;
    }

    public bool getHandStanding() {
        return isHandStanding;
    }
}
