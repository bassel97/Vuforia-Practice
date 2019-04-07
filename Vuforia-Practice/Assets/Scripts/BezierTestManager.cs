using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTestManager : MonoBehaviour
{

    public BezierCurveSegment curve;

    private void Start()
    {
        curve.Create();
    }

    private void Update()
    {
        curve.Create();

        curve.EditorDraw();
    }

}
