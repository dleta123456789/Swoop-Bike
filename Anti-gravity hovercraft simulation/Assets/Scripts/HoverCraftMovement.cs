using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCraftMovement : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private KeyCode forward;
    [SerializeField] private KeyCode backward;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;

    [Header ("Movement")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;

    private Rigidbody hovercraftRb;

    // Start is called before the first frame update
    void Start()
    {
        hovercraftRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

    }
    void PlayerInput()
    {
        if (Input.GetKey(forward))
        {
            hovercraftRb.AddForce(Vector3.forward * forwardSpeed);
        }
        if (Input.GetKey(backward))
        {
            hovercraftRb.AddForce(Vector3.back * forwardSpeed);
        }
        if (Input.GetKey(left))
        {
            hovercraftRb.AddForce(Vector3.left * horizontalSpeed);
        }
        if (Input.GetKey(right))
        {
            hovercraftRb.AddForce(Vector3.right * horizontalSpeed);
        }
    }
}
