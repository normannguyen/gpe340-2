//Pickup Death Trigger

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDeath : Pickups
{
    public Pawn player;

    public float Death = 1000;

    private Transform tf;
    private void Start()
    {
        tf = GetComponent<Transform>();
    }
    private void Update()
    {
        tf.Rotate(new Vector3(0, 30, 0) * Time.deltaTime*2);

    }

    protected override void OnPickup(Pawn pickUpper)
    {
        pickUpper.AddDeath(Death);
        base.OnPickup(pickUpper);
    }
}
