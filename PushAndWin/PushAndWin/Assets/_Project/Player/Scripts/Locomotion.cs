using Mirror;
using System.Collections;
using System.Collections.Generic;
using Telepathy;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Locomotion : NetworkBehaviour
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private float _movementSpeed;
	[SerializeField] private float _rotationSpeed;

	private Vector3 _input;
    void Start()
    {
        if (!isLocalPlayer) {
            this.enabled = false;
        }
    }
    void Update()
    {
		_input.z = Input.GetAxis("Vertical");
		_input.x = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * _input.x * _rotationSpeed * Time.deltaTime);
	}
	private void FixedUpdate() {

		Vector3 movement = new Vector3(0, _playerRb.velocity.y, _input.z * _movementSpeed);
        _playerRb.velocity = transform.TransformDirection(movement);

	}
}
