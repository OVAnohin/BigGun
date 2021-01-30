using UnityEngine;

public class Line
{
    public Vector3 PointA { get; private set; }
    public Vector3 Vector { get; private set; }

    private Vector3 _pointB;

    public Line(Vector3 pointA, Vector3 vector)
    {
        PointA = pointA;
        Vector = vector;
        _pointB = PointA + Vector;
    }

    public Vector3 GetPoint(float t)
    {
        if (t < 0)
            t = 0;

        if (t > 1)
            t = 1;

        float xt = PointA.x + Vector.x * t;
        float yt = PointA.y + Vector.y * t;
        float zt = PointA.z + Vector.z * t;

        return new Vector3(xt, yt, zt);
    }

    public void DrawLine(Color colour)
    {
        float width = .025f;

        GameObject line = new GameObject("Line_" + PointA.ToString() + "_" + _pointB.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = colour;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, PointA);
        lineRenderer.SetPosition(1, _pointB);
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
