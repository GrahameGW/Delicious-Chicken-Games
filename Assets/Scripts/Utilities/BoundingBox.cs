using UnityEngine;

public class Polygon2D
{
    Vector2[] corners;

    public Polygon2D (Vector2[] corners)
    {
        if (corners.Length <= 2)
            throw new System.ArgumentException("Polygons require a minimum of 3 corners");

        this.corners = corners;
    }

    public bool Contains(Vector2 point)
    {
        Vector2 v1 = corners[0];
        Vector2 v2 = corners[1];

        for (int i = 2; i < corners.Length; i++) {
            if (PointInTriangle(point, v1, v2, corners[i]))
                return true;
        }

        return false;
    }

    float Sign(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
    }

    bool PointInTriangle(Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3)
    {
        float d1, d2, d3;
        bool has_neg, has_pos;

        d1 = Sign(pt, v1, v2);
        d2 = Sign(pt, v2, v3);
        d3 = Sign(pt, v3, v1);

        has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
        has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

        return !(has_neg && has_pos);
    }
}
