using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public float speed = 5.0f;

	private LineRenderer lineRenderer;
    private Vector3 initialPosition;
    private Vector3 currentPosition;
	private Vector3 releasePosition;
	private Vector3 direction;
	private Vector3 rayPoint;
	private Rigidbody2D rb;

	public void Start() {
        lineRenderer = GetComponent<LineRenderer>();
		rb = GetComponent<Rigidbody2D>();
        lineRenderer.startWidth = 0.2f;
        lineRenderer.enabled = false;
    }

    public void Update() {
        if(Input.GetMouseButton(0)) {
            currentPosition = GetCurrentMousePosition().GetValueOrDefault();
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(1, currentPosition);
        }
    }

    void OnMouseDown() {
        initialPosition = GetCurrentMousePosition().GetValueOrDefault();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.positionCount = 1;
        lineRenderer.enabled = true;
    }

    void OnMouseUp() {
        lineRenderer.enabled = false;
        releasePosition = GetCurrentMousePosition().GetValueOrDefault();
        direction = initialPosition - releasePosition;
        direction.Normalize();
		rb.AddForce(direction * speed);
    }
 
    private Vector3? GetCurrentMousePosition() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector3.zero);
		rayPoint = Vector3.zero;
        float rayDistance;
        if(plane.Raycast(ray, out rayDistance)) {
            rayPoint = ray.GetPoint(rayDistance);
        }
		return rayPoint;
    }
}
