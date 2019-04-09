using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTestManager : MonoBehaviour
{

    public BezierCurveSegment curve;

    public CurveBorderObject startObject;
    public CurveBorderObject endObject;


    private void Start()
    {
        curve.CreateBezierCurveSegment(startObject.getTangent(), endObject.getTangent(), 30);        
    }


    private void Update()
    {
        curve.UpdateBezierCurveSegment(startObject.getTangent(), endObject.getTangent());

        curve.EditorDraw();
    }

}
