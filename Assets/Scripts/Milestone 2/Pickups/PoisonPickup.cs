//Pick Up the Poison Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPickup : Pickups
{
    public Pawn player;

    public float Poison = 10;
    
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
        pickUpper.AddPoison(Poison);
        base.OnPickup(pickUpper);
    }
}
