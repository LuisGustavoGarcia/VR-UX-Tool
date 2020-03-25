using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingSphere : MonoBehaviour
{
    ScalingSphereManager scalingSphereManager;
    Vector3 originalLocalPosition;

    public void Start()
    {
        originalLocalPosition = transform.localPosition;
    }

    public void OnGrab()
    {
        scalingSphereManager.AddScalingSphere(this);
    }

    public void OnRelease()
    {
        scalingSphereManager.RemoveScalingSphere(this);
        transform.localPosition = originalLocalPosition;
    }
}
