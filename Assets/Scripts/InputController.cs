using UnityEngine;
using System.Collections;

namespace Runner
{
	public class InputController : MonoBehaviour {
		private MovementController _movementController;
		private bool _isJumping;

		private void Awake () {
			_movementController = GetComponent<MovementController> ();
		}

		private void Update () {
			if (_movementController.GetGroundedStatus() == false &&
				_movementController.GetDoubleJumpStatus() == false &&
				Input.GetButtonDown("Jump")) {
				_isJumping = true;
				_movementController.SetDoubleJumpedStatus (true);
				Debug.Log ("I double jumped!");
			}

			if (!_isJumping) {
				_isJumping = Input.GetButtonDown ("Jump");
			}
		}

		private void FixedUpdate () {
			_movementController.Move (1f, _isJumping);
			_isJumping = false;
		}
	}
}
