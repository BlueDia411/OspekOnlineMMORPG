using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class MainNPC : MonoBehaviour
{

    public NavMeshAgent agent;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        
    }
   
   

    //fungsi fungsi
    public void DoCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }
}
