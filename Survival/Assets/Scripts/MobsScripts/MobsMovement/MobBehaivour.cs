using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MobBehaivour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    public bool move;

    Vector3 wayPoint;                       

    private void Start()
    {
        SetNewDestination();
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + wayPoint.normalized * speed * Time.fixedDeltaTime;
        if (Vector3.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector3(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
        move = true;
    }
}
    