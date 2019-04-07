using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GizmosShapes
{
    public Color shapeColor = Color.white;

    public abstract void Draw();
}


[System.Serializable]
public class Arrow : GizmosShapes
{
    public Vector3 start;
    public Vector3 direction;

    public static Mesh ArrowHeadMesh;

    public override void Draw()
    {
        Gizmos.color = shapeColor;

        Vector3 endPos = start + direction;

        Gizmos.DrawLine(start, endPos);

        Gizmos.DrawMesh(ArrowHeadMesh, endPos, Quaternion.LookRotation(endPos - start));
    }
}


[System.Serializable]
public class BrokenLine : GizmosShapes
{
    public List<Vector3> points;

    public override void Draw()
    {
        Gizmos.color = shapeColor;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }
}