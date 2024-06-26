using Unity.VisualScripting;
using UnityEngine;
// ReSharper disable All

public class WebShooter : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask grappleable;

    private GameObject _WebAnchor;
    private SpringJoint2D _springJoint2D;
    private LineRenderer _lineRenderer;

    public float maxDistance = 7.0f;
    public float grappleSpeed = 2.0f;
    public bool isGrappling;

    // Start is called before the first frame update
    private void Start()
    {
        _WebAnchor = new GameObject();
        _WebAnchor.name = "WebAnchor";
        _WebAnchor.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        _springJoint2D = _WebAnchor.AddComponent<SpringJoint2D>();
        _springJoint2D.connectedBody = playerController.GameObject().GetComponent<Rigidbody2D>();
        _springJoint2D.autoConfigureDistance = false;
        _springJoint2D.connectedAnchor = new Vector2(0.0f, -0.7f);
        _springJoint2D.dampingRatio = 0.7f;
        _springJoint2D.frequency = 3.0f;
        _springJoint2D.enabled = false;

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerController.currAnimal != "Spider")
        {
            isGrappling = false;
            _lineRenderer.enabled = false;
            _springJoint2D.enabled = false;
            return;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            GrappleStart();
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            GrappleStop();
        }

        if (Input.GetKey(KeyCode.W))
        {
            if(playerController.transform.localScale.y >= 0)
                GrappleUp();
            else
                GrappleDown();
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            if(playerController.transform.localScale.y < 0)
                GrappleUp();
            else
                GrappleDown();
        }
    }

    private void LateUpdate()
    {
        if (playerController.shouldRespawn)
            GrappleStop();
        if (!isGrappling) return;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, _WebAnchor.GetComponent<Transform>().position);
    }
    
    private void GrappleStart()
    {
        // calculate origin
        var mousePosition = Input.mousePosition;
        var mousePositionWorld = mainCamera.ScreenToWorldPoint(mousePosition);
        var mousePositionWorldV2 = new Vector2(mousePositionWorld.x, mousePositionWorld.y);
        var transformCopy = playerController.transform.position;
        var origin = new Vector2(transformCopy.x, transformCopy.y - 0.75f);
        // calculate direction
        var direction = mousePositionWorldV2 - origin;
        direction.Normalize();
        // cast ray with calculated origin and direction
        var hit = Physics2D.Raycast(origin, direction, maxDistance, grappleable);
        if (!hit.collider) return;
        // ray hit!
        _WebAnchor.GetComponent<Transform>().position = new Vector3(hit.point.x, hit.point.y, 0.0f);
        if (hit.collider.CompareTag("MovingPlatform"))
        {
            _WebAnchor.transform.SetParent(hit.collider.transform);
        }
        else
        {
            _WebAnchor.transform.SetParent(null);
        }
        _springJoint2D.distance = hit.distance;
        _lineRenderer.enabled = true;
        _springJoint2D.enabled = true;
        isGrappling = true;
    }

    private void GrappleStop()
    {
        _lineRenderer.enabled = false;
        _springJoint2D.enabled = false;
        isGrappling = false;
    }

    private void GrappleUp()
    {
        _springJoint2D.distance -= grappleSpeed * Time.deltaTime;
    }

    private void GrappleDown()
    {
        _springJoint2D.distance += grappleSpeed * Time.deltaTime;
    }
}
