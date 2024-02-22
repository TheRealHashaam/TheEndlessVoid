using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftChecker : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<RaftController>())
        {
            other.GetComponent<RaftController>().CanGetoff = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RaftController>())
        {
            other.GetComponent<RaftController>().CanGetoff = false;
        }
    }
}
