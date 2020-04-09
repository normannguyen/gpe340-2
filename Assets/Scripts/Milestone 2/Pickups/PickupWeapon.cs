//Pickup Weapon

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Pickups
{
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnPickup(Pawn picker)
    {
        if (picker != null)
        {
            picker.EquipWeapon(weapon);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Pawn pawn = other.GetComponent<Pawn>();
        if (pawn != null)
        {
            OnPickup(pawn);
            Destroy(gameObject);
        }
    }
}
