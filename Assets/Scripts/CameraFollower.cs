using UnityEngine;
using System.Collections;

namespace Runner
{
	public class CameraFollower : MonoBehaviour {
		[SerializeField]private Transform _player;

		private void Update () {
			transform.position = new Vector3 (_player.position.x + 6f, transform.position.y, transform.position.z);
		}
	}
}