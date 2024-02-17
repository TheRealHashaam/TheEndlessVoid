using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePhysics : MonoBehaviour
{
    public GameObject waterObject; // Reference to your water object with Stylized Water 2 component
    public float waterDensity;
    //void FixedUpdate()
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();

    //    // Get water level and wave data
    //    Vector3 waterData = StylizedWater2.Buoyancy.SampleWaves(transform.position, waterObject);
    //    float waterLevel = waterData.y;

    //    // Calculate submerged volume
    //    float submergedVolume = Mathf.Max(0, transform.position.y - waterLevel) * GetComponent<MeshRenderer>().bounds.size.x * GetComponent<MeshRenderer>().bounds.size.z;

    //    // Calculate buoyancy force
    //    float buoyancyForce = submergedVolume * waterDensity * Physics.gravity.magnitude;

    //    // Apply upward force based on buoyancy
    //    rb.AddForce(Vector3.up * buoyancyForce, ForceMode.Force);
    //}
}
