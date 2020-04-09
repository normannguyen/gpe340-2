//Bullet Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10;
    public float moveSpeed = 10;

    [SerializeField] private float lifespan = 2f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        // go
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        Pawn pawn = other.gameObject.GetComponent<Pawn>();
        if (pawn != null)
        {
            pawn.Damage(damage);
        }
        Destroy(gameObject);
    }
}
