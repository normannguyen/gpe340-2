//Pawn: For the mode/player itself

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pawn : MonoBehaviour
{
    //Animator
    public Animator anim;

    public Weapon equippedWeapon;
    //Current Speed for the character.
    public float currentSpeed = 1f;
    public float currentHealth;
    public float maxHealth;

    public float radius;
    private List<Collider> objectsInTrigger = new List<Collider>();
    public float tickRate = 0.333333f;
    public float countDown = 10;
    private Health health;
    public Transform attachmentPoint;

    public Transform rightHandPoint;

    public Transform leftHandPoint;

    // events
    public UnityEvent OnTriggerPull;
    public UnityEvent OnTriggerRelease;
    [Range(0.0f, 1.0f)] public float IKweight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Add Health
    public void AddHealth(float healthToAdd)
    {
        currentHealth += healthToAdd;
    }
    //Add Poison or Lose Health
    public void AddPoison(float poisonEffect)
    {
        //countDown -= Time.deltaTime;
        //if (countDown < 0)
        //{
        //    currentHealth -= poisonEffect = Time.deltaTime;
        //    countDown = tickRate;
        //}
        currentHealth -= poisonEffect;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }

    //One touch death
    public void AddDeath(float death)
    {
        //countDown -= Time.deltaTime;
        //if (countDown < 0)
        //{
        //    currentHealth -= poisonEffect = Time.deltaTime;
        //    countDown = tickRate;
        //}
        currentHealth -= death;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    //Damage Function
    public void Damage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }


    }
    //Movement on Vector2 since it focuses on top-down view.
    public void Move(Vector2 direction)
    {
        anim.SetFloat("Horizontal", direction.x * currentSpeed);
        anim.SetFloat("Vertical", direction.y * currentSpeed);
    }
    //Equip Weapon
    public void EquipWeapon(Weapon newWeapon)
    {
        if (equippedWeapon != null)
        {
            UnequipWeapon();
        }
        // try out different instantiates
    
        GameObject weaponObject = Instantiate(newWeapon.gameObject, attachmentPoint.position, attachmentPoint.rotation) as GameObject;
        weaponObject.transform.parent = attachmentPoint;

        equippedWeapon = weaponObject.GetComponent<Weapon>();
        // change the layer
        equippedWeapon.gameObject.layer = gameObject.layer;
        OnTriggerPull.AddListener(equippedWeapon.OnPullTrigger);
        OnTriggerRelease.AddListener(equippedWeapon.OnReleaseTrigger);
    }
    //Unequip Weapon
    public void UnequipWeapon()
    {
        OnTriggerPull.RemoveListener(equippedWeapon.OnPullTrigger);
        OnTriggerRelease.RemoveListener(equippedWeapon.OnReleaseTrigger);
        Destroy(equippedWeapon.gameObject);
        equippedWeapon = null;
    }
    //Animator IK for the arms
    public void OnAnimatorIK()
    {
        //Right Hand
        if (equippedWeapon == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.0f);
            return;
        }
        if (equippedWeapon.rightHand != null)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, equippedWeapon.rightHand.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKweight);
            anim.SetIKRotation(AvatarIKGoal.RightHand, equippedWeapon.rightHand.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IKweight);

        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
        }
        //Left Hand
        if (equippedWeapon.leftHand != null)
        {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, equippedWeapon.leftHand.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, IKweight);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, equippedWeapon.leftHand.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, IKweight);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }
}

