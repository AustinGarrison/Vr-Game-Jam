//uSsing Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrottle : MonoBehaviour//PhysicsGadgetConfigurableLimitReader
{
    public float DrainAmount { get { return m_DrainAmount; } }

    public float m_DrainAmount = 0.0f;
    public GameObject ship;

    private EngineManager engines;
    private ShipMover shipMover;

    protected new void Start()
    {
        //base.Start();
        engines = FindObjectOfType<EngineManager>();
        shipMover = FindObjectOfType<ShipMover>();
    }

    void FixedUpdate()
    {
        //if (engines.AreEnginesActive)
        //    shipMover.Accelerate();
        //else if (!engines.AreEnginesActive)
        //    shipMover.Decelerate();
    }

}
