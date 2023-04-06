using Birds;
using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

public class SpringController : UnifyBehaviour
{
    private Camera _mainCamera;
    private Rigidbody2D _birdBody;
    private Rigidbody2D _swingPointBody; 
    private SpringJoint2D _spring;
    private BirdMotor _birdMotor;

    public bool SpringIsAttached { get; private set; } = false;
    
    public Vector2 AttachOrientation {
        get
        {
            // Clockwise if dot product is positive
            var posHere = transform.position;
            var posNext = (Vector2)posHere + (_birdBody.velocity);
            var posAttach = _swingPointBody.transform.position;
        
            var clockwise = ShouldAttachInClockwiseRotation(posHere, posNext, posAttach);
            return Vector2.Perpendicular(posHere - posAttach) * (clockwise ? 1 : -1);  
        } 
    }

    [Inject]
    public void Inject(Rigidbody2D birdBody, SpringJoint2D spring, BirdMotor birdMotor, Camera mainCamera)
    {
        _birdBody = birdBody;
        _spring = spring;
        _swingPointBody = spring.connectedBody;
        _birdMotor = birdMotor;
        _mainCamera = mainCamera;
    }

    private void Start()
    {
        _spring.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            AttachSpringToWorldPoint(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            DetachSpring();
        }
    }

    private void ConfigureSpringForPoint(Vector3 worldPoint)
    {
        _swingPointBody.position = worldPoint;
        _spring.distance = Vector2.Distance(transform.position, _swingPointBody.position);
    }

    private void AttachSpringToWorldPoint(Vector3 worldPoint)
    {
        SpringIsAttached = true;
        EnableDisableSpring(true);
        ConfigureSpringForPoint(worldPoint);
    }

    private void DetachSpring()
    {
        SpringIsAttached = false;
        EnableDisableSpring(false);
    }

    private void EnableDisableSpring(bool attach)
    {
        _swingPointBody.gameObject.SetActive(attach);
        _spring.enabled = attach;
    }
    private void FixedUpdate()
    {
        if (!SpringIsAttached) return;

        Debug.DrawRay(this.transform.position, AttachOrientation * 5, Color.red);
    }


    private static bool ShouldAttachInClockwiseRotation(Vector3 posHere, Vector3 posNext, Vector3 swingPoint)
    {
        return ((posHere.x - swingPoint.x) * (posNext.y - swingPoint.y) -
                (posHere.y - swingPoint.y) * (posNext.x - swingPoint.x)) >= 0;
    }
}
