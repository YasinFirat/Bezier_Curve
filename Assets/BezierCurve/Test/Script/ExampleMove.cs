using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bezier;

/// <summary>
/// This class was created for exemplification
/// </summary>
public class ExampleMove : MoveBezier
{
    public ExampleMoveManager pointData;
    public void Start()
    {
        StartCoroutine( Move(transform,pointData.SelectBezier(),5));
    }
}
