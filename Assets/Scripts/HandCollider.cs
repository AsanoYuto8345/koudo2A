using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
{
    //Effect Prefab 
    //[SerializeField] private GameObject _effectPrefab;

    private void OnTriggerEnter(Collider other) //Touch other object!
    {
        if (other.tag == "Ball") //Touched object has "Ball" Tag
        {
            //Start effect and destroy it after 5 sec/ 
            //GameObject effect = Instantiate(_effectPrefab, other.transform.position, 
            //                                               Quaternion.identity);
            //Destroy(effect, 5);

            //Destroy the touched Ball
            Destroy(other.gameObject);
        }
    }
}
