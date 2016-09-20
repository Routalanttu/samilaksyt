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
