using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathObjectParent : pathPoint 

{
    public pathPoint[] commenPathPoint;
    public pathPoint[] redPathPoint;
    public pathPoint[] greenPathPoint;
    public pathPoint[] bluePathPoint;
    public pathPoint[] yellowPathPoint;

    [Header("Scale and positing Difrence")]
    public float[] scales;
    public float[] positionDifrence;
    public pathPoint[] BasePoint;
    public List<pathPoint> safePoint;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
