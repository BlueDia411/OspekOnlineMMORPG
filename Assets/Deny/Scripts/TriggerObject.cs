using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    public Transform transformPoint1;
    public Transform transformPoint2;
    public Transform transformBangku;

    public bool point1;
    public bool point2;
    public bool bangku;
    public bool duduk;
    public bool canInputBtn;
    // Start is called before the first frame update
    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point1")
        {
            point1 = true;
        }
        else if (other.tag == "Bangku")
        {
            bangku = true;
        }
        else if (other.tag == "Point2")
        {
            point2 = true;
        }
       

    }
   
}
