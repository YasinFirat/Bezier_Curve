using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bezier
{/// <summary>
/// Quadratic : B(t) = P₁+(1-t)² * (P₀-P₁)+t²(P₂-P₁) , 0<= t <=1
/// </summary>
    [System.Serializable]
    public class QuadraticBezierCurve:BezierCurve
    {
        public Transform point1;
        public Transform point2;
        public Transform point3;

        public QuadraticBezierCurve(Vector2 point1, Vector2 point2, Vector2 point3, int beetwenTotalPoints)
        {
            this.point1.position = point1;
            this.point2.position = point2;
            this.point3.position = point3;
            this.beetwenTotalPoint = beetwenTotalPoints;
        }
        public override BezierCurve CalculatePoints()
        {
            points = new List<Vector2>();
            calculatePoint = Vector2.zero;
            timer = (float)1 / (beetwenTotalPoint+1);
            for (float i = 0; i <= 1; i += timer)
            {
                calculatePoint = (point2.position + Mathf.Pow((1 - i), 2) * (point1.position - point2.position) 
                    + Mathf.Pow(i, 2) * (point3.position - point2.position));
                points.Add(calculatePoint);
            }
            if (!points.Contains(point3.position))
            {
                points.Add(point3.position);
            }

            return this;
           
        }
    }
}
