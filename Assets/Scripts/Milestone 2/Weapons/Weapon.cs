using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public float Damage;
    public float Speed;
    [SerializeField] protected float damageDone;
    [SerializeField]public Transform leftHand;
    [SerializeField]public Transform rightHand;
    public virtual void Start()
    {

    }

    public virtual void OnReleaseTrigger()
    {
        
    }

    public virtual void OnPullTrigger()
    {

    }
    public virtual void Fire()
    {
    }
    protected virtual void Update()
    {

    }
}
