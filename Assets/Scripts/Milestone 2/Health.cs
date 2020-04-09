//Health Script for the UI text for right now.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public Pawn pawn;
    private Text text;
    private GameObject character;
    [Header("Events")]
    [SerializeField, Tooltip("Raised every time the object is healed.")]
    private UnityEvent onHeal;
    [SerializeField, Tooltip("Raised every time the object is damaged.")]
    private UnityEvent onDamage;
    [SerializeField, Tooltip("Raised once when the object's health reaches 0.")]
    private UnityEvent onDie;
    private void Start()
    {
        character = this.gameObject;
    }
    void Awake()
    {
        //UI Text
        text = GameObject.Find("HealthText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + pawn.currentHealth;

    }
}
