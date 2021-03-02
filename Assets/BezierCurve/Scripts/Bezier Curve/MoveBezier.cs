using System.Collections;
using UnityEngine;


namespace Bezier
{
    public abstract class MoveBezier : MonoBehaviour
    {
        public IEnumerator Move(Transform player, BezierCurve bezierCurve, float speed)
        {
            player.position = bezierCurve.GetPoint(0);
            for (int i = 1; i < bezierCurve.GetPoints().Count;)
            {
                player.position = Vector2.MoveTowards(player.position, bezierCurve.GetPoint(i), Time.deltaTime * speed);
                
                yield return new WaitForFixedUpdate();
                if (Vector2.Distance(player.position, bezierCurve.GetPoint(i)) < 0.001f)
                {
                    i++;
                }
            }
        }

    }
}

