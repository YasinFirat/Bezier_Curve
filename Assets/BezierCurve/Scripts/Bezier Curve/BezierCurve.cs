using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bezier
{
    /// <summary>
    /// Referance : https://en.wikipedia.org/wiki/Bézier_curve
    /// </summary>
    public abstract class BezierCurve
    {
        protected List<Vector2> points;
        protected Vector2 calculatePoint;
        protected float timer;
        public int beetwenTotalPoint = 0;

        public List<Vector2> GetPoints()
        {
            return points;
        }
        public Vector2 GetPoint(int index)
        {
            return points[index];
        }
        public abstract BezierCurve CalculatePoints();
     
    }
}
