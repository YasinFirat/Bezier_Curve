using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bezier;
/// <summary>
/// This class was created for exemplification
/// </summary>
public enum SelectMove
{
    lianer,
    quadratic,
    cubic,
    multi,
    multiLieaner,
    multimultiQuadratic,
    multiCubic

}
public class ExampleMoveManager : MonoBehaviour
{
    public SelectMove selectMove;
    public LieanerBezierCurve lieanerWay;
    public QuadraticBezierCurve quadraticBezier;
    public CubicBezierCurve cubicBezier;
    public MultiBezierCurve multiBezier;

    [Header("MULTIBEZIER EXAMPLES")]
    public MultiBezierCurve multiLİeaner;
    public MultiBezierCurve multiQuadratic;
    public MultiBezierCurve multiCubic;
   
    private BezierCurve bezier;
   
    
    private void Awake()
    {
        SelectBezier().CalculatePoints();
        lieanerWay.CalculatePoints();
    }
    private void OnDrawGizmos()
    {
        SelectBezier();
        bezier.CalculatePoints();

        DrawForGizMos(bezier);
    }
    public void DrawForGizMos(BezierCurve bezierCurve)
    {
        for (int i = 0; i < bezierCurve.GetPoints().Count; i++)
        {
            Gizmos.DrawSphere(bezierCurve.GetPoint(i), .2f);
        }
    }
    public BezierCurve SelectBezier()
    {
        switch (selectMove)
        {
            case SelectMove.lianer:
                bezier = lieanerWay;
                return bezier;
               
            case SelectMove.cubic:
                bezier = cubicBezier;
                return bezier;
            case SelectMove.quadratic:
                bezier = quadraticBezier;
                return bezier;
            case SelectMove.multi:
                bezier = multiBezier;
                return bezier;
            case SelectMove.multiLieaner:
                bezier = multiLİeaner;
                return bezier;
            case SelectMove.multimultiQuadratic:
                bezier = multiQuadratic;
                return bezier;
            case SelectMove.multiCubic:
                bezier = multiCubic;
                return bezier;
            default:
                return null;
        }
    }
   
}
