using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrottle : PhysicsGadgetConfigurableLimitReader
{
    [Header("Movement")]
    public Transform move;
    [Tooltip("Acts as speed")]
    public Vector3 axis = Vector3.up;
    [Header("Range")]
    public bool useRange = false;
    public Vector3 minRange = -Vector3.up;
    public Vector3 maxRange = Vector3.up;
    private EngineManager engines;

    Vector3 startPos;

    protected new void Start()
    {
        base.Start();
        startPos = move.position;
        engines = FindObjectOfType<EngineManager>();
    }

    void FixedUpdate()
    {
        if (engines.AreEnginesActive)
        {
            if (useRange)
            {
                var value = GetValue();

                if (value >= 0)
                    move.position = Vector3.Lerp(startPos, startPos + minRange, value);
                else if (value < 0)
                    move.position = Vector3.Lerp(startPos, startPos + maxRange, -value);
            }
            else
                move.position += axis * GetValue() * Time.deltaTime;
        }
    }
}
