using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bezier
{/// <summary>
/// You can use all properties, such as a Lieaner,Quadratic,Cubic ...
/// for lianer pointsArray[2] , for Quadratic pointsArray[3],for Cubic pointsArray[4]
/// 
/// Multi : n,i => ∑  Binomial(n,i)*[(1-t)^(n-1)]*(t^i) Pi
/// </summary>
    [System.Serializable]
    public class MultiBezierCurve : BezierCurve
    {
        public Transform[] pointsArray;
        float sum;
        int n;
        public MultiBezierCurve(Transform[] pointsArray,int beetwenTotalPoints)
        {
            this.pointsArray = pointsArray;
            this.beetwenTotalPoint = beetwenTotalPoints;
        }
        public override BezierCurve CalculatePoints()
        {
            points = new List<Vector2>();
            calculatePoint=Vector2.zero;
            timer = (float)1 / (beetwenTotalPoint+1);

            n = pointsArray.Length;

            for (float t = 0; t <= 1; t += timer)
            {
                calculatePoint = Vector2.zero;
                for (int i = 0; i < n; i++)
                {
                    calculatePoint += Binomial(n - 1, i) * Mathf.Pow(1 - t, n - 1 - i) * Mathf.Pow(t, i) * (Vector2)pointsArray[i].position;
                }
                points.Add(calculatePoint);
            }
            if (!points.Contains(pointsArray[n-1].position))
            {
                points.Add(pointsArray[n-1].position);
            }
            return this;
        }

        private float Binomial(float n, float k)
        {
            sum = 0;
            for (float i = 0; i < k; i++)
            {
                sum += Mathf.Log10(n - i);
                sum -= Mathf.Log10(i + 1);
            }

            return Mathf.Pow(10, sum);
        }
    }
}

