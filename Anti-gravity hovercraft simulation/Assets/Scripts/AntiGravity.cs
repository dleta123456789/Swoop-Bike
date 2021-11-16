using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{

    [Header("canceling out gravity")]
    public float multiplier;
    public float force;
    public float  setHeight;

    private Rigidbody hovercraftRb;
    [SerializeField] private  Transform[] anchors= new Transform[2];
    private RaycastHit[] hits = new RaycastHit[2];
    // Start is called before the first frame update
    void Start()
    {
        hovercraftRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(int i=0;i<anchors.Length; ++i)
        {
            CounterGravity(anchors[i], hits[i]);
        }
        
    }
    void CounterGravity(Transform anchor,RaycastHit hit)
    {
        Debug.DrawRay(anchor.position, -anchor.up, Color.green, 10, false);
        if (Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            Debug.Log("Hit point" + hit.point);
            force = 0;
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            Debug.Log("Force= " + force);
            hovercraftRb.AddForceAtPosition(transform.up * force * multiplier, anchor.position, ForceMode.Acceleration);
        }
    }
}
