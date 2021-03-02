using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bezier
{
    /// <summary>
    ///  Cubic : B(t) = (i-t)³*P₀+3*(1-t)²*t*P₁+3*(1-t)*t²*P₂+t³*P₃  , 0<= t <=1
    ///   1-t=x => x³*P₀+3*x²*t*P₁+3*x*t²*P₂+t³*P₃
    ///   x(x²*P₀+3t(x*P₁+t*P₂))+t³*P₃  , 0<= t <=1
    /// </summary>
   [System.Serializable]
    public class CubicBezierCurve : BezierCurve
    {
        public Transform point1;
        public Transform point2;
        public Transform point3;
        public Transform point4;
        float x;

        public CubicBezierCurve(Vector2 point1,Vector2 point2,Vector2 point3,Vector2 point4,int beetwenTotalPoints)
        {
            this.point1.position = point1;
            this.point2.position = point2;
            this.point3.position = point3;
            this.point4.position = point4;
            this.beetwenTotalPoint = beetwenTotalPoints;
        }
        public override BezierCurve CalculatePoints()
        {
            points = new List<Vector2>();
            calculatePoint=Vector2.zero;
            timer = (float)1 / (beetwenTotalPoint+1);
            x = 0;
            Debug.Log("Cubic"+ timer);
            for (float i = 0; i <= 1; i += timer)
            {
                x = 1 - i;
                calculatePoint = (x *
                    (Mathf.Pow(x, 2) * point1.position + 3 * i *
                    (x * point2.position + i * point3.position)) + Mathf.Pow(i, 3) * point4.position);
                points.Add(calculatePoint);
            }
            if (!points.Contains(point4.position))
            {
                points.Add(point4.position);
            }

            return this;


        }
    }
}

