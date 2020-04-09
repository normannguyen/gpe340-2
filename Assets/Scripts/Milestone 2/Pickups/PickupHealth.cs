//Pickup Health Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : Pickups
{
    public Pawn player;

    private float healthUp = 10;
    private Transform tf;
    private void Start()
    {
        tf = GetComponent<Transform>();
    }
    private void Update()
    {
        tf.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
    protected override void OnPickup(Pawn pickUpper)
    {
        pickUpper.AddHealth(healthUp);
        base.OnPickup(pickUpper);
    }

}
