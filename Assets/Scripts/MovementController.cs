using UnityEngine;
using System.Collections;

namespace Runner
{
	[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
	public class MovementController : MonoBehaviour {
		private const float GroundedRadius = 0.2f;

		private const string GroundedAnimationParameterName = "Ground";
		private const string VerticalSpeedAnimationParameterName = "vSpeed";
		private const string SpeedAnimationParameterName = "Speed";


		[SerializeField]private float _speed;
		[SerializeField]private float _jumpForce = 800f;
		[SerializeField]private Transform _groundCheck;
		[SerializeField]private Animator _animator;
		[SerializeField]private Rigidbody2D _rb;

		private bool _isGrounded = false;

		private void Awake () {
			_animator = GetComponent<Animator> ();
			_rb = GetComponent<Rigidbody2D> ();
		}

		private void FixedUpdate () {
			_isGrounded = false;
			var colliders = Physics2D.OverlapCircleAll (_groundCheck.position, GroundedRadius);
			for (var i = 0; i < colliders.Length; ++i) {
				// Toimii vain niin kauan kuin ainoat muut colliderit kuin pelaajahahmo itse on groundeja.
				if (colliders [i].gameObject != gameObject) {
					_isGrounded = true;
				}
			}
			_animator.SetBool (GroundedAnimationParameterName, _isGrounded);
			_animator.SetFloat (VerticalSpeedAnimationParameterName, _rb.velocity.y);
		}

		public void Move (float movementAmount, bool isJumping) {
			// Should we move?
			if (_isGrounded) {
				_animator.SetFloat (SpeedAnimationParameterName, movementAmount);
				_rb.velocity = new Vector2 (movementAmount * _speed, _rb.velocity.y);
			}

			// Should we jump?
			if (_isGrounded && isJumping) {
				_isGrounded = false;
				_animator.SetBool (GroundedAnimationParameterName, _isGrounded); //aina false
				_rb.AddForce(new Vector2(0f,_jumpForce));
			}
		}
	}

}
