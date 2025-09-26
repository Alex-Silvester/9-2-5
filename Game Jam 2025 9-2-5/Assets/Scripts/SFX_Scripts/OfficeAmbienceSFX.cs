using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OfficeAmbienceSFX : MonoBehaviour
{
    public Collider Area;
    public GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 closestPoint = Area.ClosestPoint(Player.transform.position);
        transform.position = closestPoint;
    }
}
