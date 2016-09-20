using UnityEngine;
using System.Collections;

namespace Runner
{
	public class DeSpawner : MonoBehaviour {

		[SerializeField]private SpawnerController _spawnerController;

		private void OnTriggerEnter2D(Collider2D other) {
			// Jos spawnerController on null tai pooliin lisääminen ei onnistu, tuhoa
			// Vitun AddToPool joka palauttaa booleanin, voi helvetin helvetti Sami
			if (_spawnerController == null || !_spawnerController.AddToPool (other.gameObject)) {
				Destroy (other.gameObject);
			}
		}
	}
}
