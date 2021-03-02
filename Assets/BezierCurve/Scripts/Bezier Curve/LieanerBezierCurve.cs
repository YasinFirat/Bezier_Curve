using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bezier
{
/// <summary>
/// Referance : https://en.wikipedia.org/wiki/Bézier_curve
/// 
/// Lieaner Formula : B(t) =(1-t)*P₀ + t*P₁    , 0<= t <=1
/// </summary>
    [System.Serializable]
    public class LieanerBezierCurve : BezierCurve
    {
        public Transform point1;
        public Transform point2;
        public override BezierCurve CalculatePoints()
        {
            points = new List<Vector2>();
            calculatePoint = Vector2.zero;
            timer = (float)1 / (beetwenTotalPoint+1);
            Debug.Log("timer" + timer);
            for (float i = 0; i <= 1; i += timer)
            {
                calculatePoint = (point1.position * (1 - i) + i * point2.position);
                points.Add(calculatePoint);
                
            }
            if (!points.Contains(point2.position))
            {
                points.Add(point2.position);
            }

            return this;
        }
        public LieanerBezierCurve(Vector2 point1,Vector2 point2,int beetwenTotalPoints)
        {
            this.point1.position = point1;
            this.point2.position = point2;
            this.beetwenTotalPoint = beetwenTotalPoints;
        }

       
        public LieanerBezierCurve() { }
    }
}
