using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickups : MonoBehaviour
{

    protected virtual void OnPickup(Pawn pickerUpper)
    {
        Debug.Log(gameObject.name + " was picked up.");
    }
    private void OnTriggerEnter(Collider collider)
    {
        Pawn pawn = collider.GetComponent<Pawn>();
        if (collider != null)
        {
            OnPickup(pawn);
            Destroy(gameObject);
        }
    }
}
