using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform targetTransform;
	[SerializeField] private Rigidbody2D targetRb;
    
	public Vector2 offset;
	public Vector2 offset2;
	private float smoothSpeed = 5.0f;

	// Start is called before the first frame update
	void Start()
	{
        
	}

	// Update is called once per frame
	void LateUpdate()
	{
		var targetVelocity = targetRb.velocity;
		// offset = new Vector2(targetVelocity.x * 0.2f + offset2.x, targetVelocity.y * 0.1f + offset2.y); //Doesn't work properly
		offset = new Vector2(0, 0);
		SmoothFollow();
	}

	void SmoothFollow()
	{
		// implement lookahead camera - camera pans to where the player is facing at all times
		Vector2 targetPosition = targetTransform.position;
		Vector2 targetPositionOffset = targetPosition + offset;
		Vector2 smoothFollow = Vector2.Lerp(transform.position, targetPositionOffset, smoothSpeed);
		transform.position = new Vector3(smoothFollow.x, smoothFollow.y, transform.position.z);
	}
}