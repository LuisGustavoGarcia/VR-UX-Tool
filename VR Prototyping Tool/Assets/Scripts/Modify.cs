using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modify : MonoBehaviour
{

    Rigidbody rigidbody;
    public GameObject kinematicCheckmark;
    public GameObject rigidbodyConstraintsCheckmark;
    public GameObject gravityCheckmark;

    void Awake()
    {
        rigidbody = transform.parent.GetComponent<Rigidbody>();
        kinematicCheckmark.SetActive(false);
        rigidbodyConstraintsCheckmark.SetActive(true);
        gravityCheckmark.SetActive(false);
    }

    public void ToggleKinematic()
    {
        rigidbody.isKinematic = !rigidbody.isKinematic;
        if (rigidbody.isKinematic)
        {
            kinematicCheckmark.SetActive(true);
        }
        else
        {
            kinematicCheckmark.SetActive(false);
        }
    }

    public void ToggleGravity()
    {
        rigidbody.useGravity = !rigidbody.useGravity;
        if (rigidbody.useGravity)
        {
            gravityCheckmark.SetActive(true);
        }
        else
        {
            gravityCheckmark.SetActive(false);
        }
    }

    public void ToggleRigidbodyConstraints()
    {
        if (rigidbody.constraints != RigidbodyConstraints.None)
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbodyConstraintsCheckmark.SetActive(false);
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            rigidbodyConstraintsCheckmark.SetActive(true);
        }
    }
}
