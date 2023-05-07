using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCollider : MonoBehaviour
{
    [SerializeField] int numSegments = 30; // Köþe sayýsý

    void Awake()
    {
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        if (poly == null)
        {
            poly = gameObject.AddComponent<PolygonCollider2D>();
        }

        Vector2[] points = CreateCirclePoints();
        poly.points = points;

        Destroy(GetComponent<EdgeCollider2D>());
    }

    Vector2[] CreateCirclePoints()
    {
        Vector2[] points = new Vector2[numSegments];
        float angle = 0;
        float angleDelta = 2 * Mathf.PI / numSegments;

        for (int i = 0; i < numSegments; i++)
        {
            float x = Mathf.Cos(angle) * transform.localScale.x / 2;
            float y = Mathf.Sin(angle) * transform.localScale.y / 2;
            points[i] = new Vector2(x, y);
            angle += angleDelta;
        }

        return points;
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ArenaCollider : MonoBehaviour
//{
//    void Awake()
//    {
//        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
//        if (poly == null)
//        {
//            poly = gameObject.AddComponent<PolygonCollider2D>();
//        }

//        Vector2[] points = poly.points;
//        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
//        edge.points = points;
//        Destroy(poly);
//    }
//}
