using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GizmosHelper : MonoBehaviour
{
    public Mesh ArrowHeadMesh;

    static List<GizmosShapes> shapes = new List<GizmosShapes>();

    public Arrow testArrow = new Arrow();

    public BrokenLine testBrokenLine;

    private void Awake()
    {
        Arrow.ArrowHeadMesh = ArrowHeadMesh;
    }

    private void Update()
    {
        GizmosHelper.DrawGizmosShape(testArrow);

        GizmosHelper.DrawGizmosShape(testBrokenLine);
    }

    public static void DrawGizmosShape(GizmosShapes shape)
    {
        shapes.Add(shape);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < shapes.Count; i++)
        {
            shapes[i].Draw();
        }
        shapes.Clear();
    }
}
