using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBorderObject : MonoBehaviour
{

    //Is this object emitting
    [Tooltip("Is this object emitting - curve out/in")]
    public bool curveOut = true;

    Tangent objectTangent = new Tangent();

    public Tangent getTangent()
    {
        objectTangent.tangentStart = transform.position;
        objectTangent.tangentEnd = transform.position + transform.up * transform.localScale.sqrMagnitude;

        if (curveOut)
            objectTangent.SwapDirection();

        return objectTangent;
    }

}
