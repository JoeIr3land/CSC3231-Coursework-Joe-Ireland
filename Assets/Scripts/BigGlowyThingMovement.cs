using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGlowyThingMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private float maxDistance = 100;

    private float moveDistance;

    [SerializeField]
    private float currentDistanceMoved;

    [SerializeField]
    private bool moveDown = true;

    [SerializeField]
    private float rotateSpeed;

    void OnEnable()
    {
        currentDistanceMoved = 0;
    }

    void Update()
    {
        if (moveDown == true)
        {
            moveDistance = -(Time.deltaTime * moveSpeed);
        }
        else
        {
            moveDistance = Time.deltaTime * moveSpeed;
        }
        transform.Translate(0, moveDistance, 0);
        currentDistanceMoved += Mathf.Abs(moveDistance);
        if (currentDistanceMoved > maxDistance)
        {
            moveDown = !moveDown;
            currentDistanceMoved -= maxDistance;
        }
        transform.Rotate(0f, rotateSpeed, 0f);

    }
}
