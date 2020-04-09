using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public float damageDone;
    public float moveSpeed;
    public float timer = 3.0F;
    public void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    void Awake()
    {
        Destroy(gameObject, timer);
    }
    public void OnTriggerEnter(Collider other)
    {
        Pawn pawn = other.gameObject.GetComponent<Pawn>();
        if(other != null)
        {
            pawn.Damage(damageDone);
        }
        Destroy(gameObject);
    }
}
