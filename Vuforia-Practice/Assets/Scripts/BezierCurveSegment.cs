using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Tangent
{
    public Vector3 tangentStart;
    public Vector3 tangentEnd;

    public void SwapDirection()
    {
        Vector3 temp = tangentStart;
        tangentStart = tangentEnd;
        tangentEnd = temp;
    }
}


[System.Serializable]
public class BezierCurveSegment
{
    [SerializeField] Tangent rightTangent, leftTangent;
    [SerializeField] int resolution;

    [SerializeField] List<Vector3> points = new List<Vector3>();

    //If initialized by inspector -- for Editor testing
    public void Create()
    {
        points.Clear();

        points.Add(rightTangent.tangentStart);
        CalculatePoints();
        points.Add(leftTangent.tangentEnd);
    }

    //If updated by inspector -- for Editor testing
    public void UpdateBezierCurveSegment()
    {
        ReCalculatePoints();
    }

    public void CreateBezierCurveSegment(Tangent _rightTangent, Tangent _leftTangent, int _resolution)
    {
        rightTangent = _rightTangent;
        leftTangent = _leftTangent;
        resolution = _resolution;

        points.Clear();

        points.Add(rightTangent.tangentStart);
        CalculatePoints();
        points.Add(leftTangent.tangentEnd);
    }

    public void UpdateBezierCurveSegment(Tangent _rightTangent, Tangent _leftTangent)
    {
        rightTangent = _rightTangent;
        leftTangent = _leftTangent;

        points[0] = rightTangent.tangentStart;
        ReCalculatePoints();
        points[points.Count - 1] = _leftTangent.tangentEnd;
    }

    void CalculatePoints()
    {
        float t = 0;
        for (int i = 0; i < resolution - 1; i++)
        {
            t += 1 / (float)resolution;

            points.Add(GetPointB(t));
        }
    }

    void ReCalculatePoints()
    {
        float t = 0;
        for (int i = 0; i < resolution - 1; i++)
        {
            t += 1 / (float)resolution;

            points[i + 1] = (GetPointB(t));
        }
    }

    Vector3 GetPointB(float t)
    {
        //Cubic Bezier Curve Equation
        //B(t) = (1-t)3P0 + 3(1-t)2tP1 + 3(1-t)t2P2 + t3P3 , 0 < t < 1

        Vector3 pointB = Mathf.Pow((1 - t), 3) * rightTangent.tangentStart;
        pointB += 3 * Mathf.Pow((1 - t), 2) * t * rightTangent.tangentEnd;
        pointB += 3 * (1 - t) * t * t * leftTangent.tangentStart;
        pointB += t * t * t * leftTangent.tangentEnd;

        return pointB;
    }

    public void EditorDraw()
    {
        Arrow t1 = new Arrow(), t2 = new Arrow();

        t1.start = rightTangent.tangentStart;
        t1.direction = rightTangent.tangentEnd - rightTangent.tangentStart;

        t2.start = leftTangent.tangentStart;
        t2.direction = leftTangent.tangentEnd - leftTangent.tangentStart;

        GizmosHelper.DrawGizmosShape(t1);
        GizmosHelper.DrawGizmosShape(t2);

        BrokenLine curve = new BrokenLine();
        curve.points = new List<Vector3>(points);
        curve.shapeColor = Color.green;

        GizmosHelper.DrawGizmosShape(curve);
    }

}
