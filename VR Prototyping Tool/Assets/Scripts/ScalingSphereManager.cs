using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingSphereManager : MonoBehaviour
{

    ScalingSphere[] scalingSpheres;
    string axisOfChange;
    public float scalingFactor;

    // Start is called before the first frame update
    void Start()
    {
        scalingSpheres = new ScalingSphere[2];    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScale();
    }

    public void AddScalingSphere(ScalingSphere scalingSphere)
    {
        if (scalingSpheres[0] != scalingSphere && scalingSpheres[1] != scalingSphere)
        {
            scalingSpheres[1] = scalingSpheres[0];
            scalingSpheres[0] = scalingSphere;
        }
        UpdateScalingAxis();
    }

    public void RemoveScalingSphere(ScalingSphere scalingSphere)
    {
        if (scalingSpheres[0] == scalingSphere)
        {
            scalingSpheres[0] = scalingSpheres[1];
            scalingSpheres[1] = null;
        }
        else if (scalingSpheres[1] == scalingSphere)
        {
            scalingSpheres[1] = null;
        }
        UpdateScalingAxis();
    }

    public void UpdateScalingAxis()
    {
        if (scalingSpheres[0] == null || scalingSpheres[1] == null)
        {
            axisOfChange = null;
            return;
        }
        
        float xDifference = scalingSpheres[1].transform.position.x - scalingSpheres[0].transform.position.x;
        float yDifference = scalingSpheres[1].transform.position.y - scalingSpheres[0].transform.position.y;
        float zDifference = scalingSpheres[1].transform.position.z - scalingSpheres[0].transform.position.z;

        if (xDifference != 0)
        {
            axisOfChange = "x";
        }
        else if (yDifference != 0)
        {
            axisOfChange = "y";
        }
        else if (zDifference != 0)
        {
            axisOfChange = "z";
        }
    }

    public void UpdateScale()
    {
        if (axisOfChange == null)
            return;

        Transform objectToScale = transform.parent;
        // "2" is the starting distance between the spheres in this case.
        if (axisOfChange.Equals("x"))
        {
            float difference = 2 - Mathf.Abs(scalingSpheres[0].transform.position.x - scalingSpheres[1].transform.position.x);
            objectToScale.transform.localScale = new Vector3(Mathf.Pow(difference, 2), 0f, 0f);
        }
        else if (axisOfChange.Equals("y"))
        {
            float difference = 2 - Mathf.Abs(scalingSpheres[0].transform.position.y - scalingSpheres[1].transform.position.y);
            objectToScale.transform.localScale = new Vector3(0f, Mathf.Pow(difference, 2), 0f);
        }
        else if (axisOfChange.Equals("z"))
        {
            float difference = 2 - Mathf.Abs(scalingSpheres[0].transform.position.z - scalingSpheres[1].transform.position.z);
            objectToScale.transform.localScale = new Vector3(0f, 0f, Mathf.Pow(difference, 2));
        }
    }
}
