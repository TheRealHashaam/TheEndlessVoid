using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    public Transform Offset;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<RaftController>())
        {
            FindObjectOfType<GameManager>().InstantiateIsland(Offset, this.gameObject);
        }
    }
}
