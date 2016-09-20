using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Runner 
{
	// Poistettiin MonoBehaviour
	// Käytännössä siis tätä luokkaa ei voi enää liittää GameObjectiin
	// Jos MonoBeh on, TÄYTYY liittää johonkin objektiin.
	// Nyt tätä voi kutsua muissa koodinpätkissä New-instantaatiolla
	public class GameObjectPool
	{
		// Queue on tehokkaampi käyttää tässä kuin List
		private Queue<GameObject> _objectQueue;
		private GameObject _prefab;

		// Tehdään julkinen rakentaja/konstruktori
		// PS. ÄLÄ IKINÄ LUO RAKENTAJAA MonoB-luokkiin!
		// (Unity menee vähän rikki, ilmeisesti.)
		// MonoB-luokkiin Awake ja Start on ihan cool ja jepa.
		public GameObjectPool (GameObject prefab, int initialSize) {
			_prefab = prefab;
			// Nyt varataan muistia initialSizen verran, MUTTA
			// Length/count on edelleen 0!!!
			_objectQueue = new Queue<GameObject> (initialSize);

			for (int i = 0; i < initialSize; i++) {
				// Instantiate on MonoB-luokka, mutta Object-luokan avulla voidaan instantioida muitakin.
				var go = Object.Instantiate(_prefab);

				AddObjectToPool (go);
			}
		}

		public void AddObjectToPool (GameObject go) {
			go.SetActive (false);
			// Työntää uuden alkion jonoon
			_objectQueue.Enqueue (go);
		}

		public GameObject GetObject() {
			if (_objectQueue.Count > 0) {
				// Otetaan jonossa ekana oleva olio.
				var go = _objectQueue.Dequeue ();
				go.SetActive (true);
				return go;
			}

			// Jos edellinen if-lause toteutui,
			// return keskeytti.
			var obj = Object.Instantiate (_prefab);
			obj.SetActive (true);
			return obj;
		}
	}
}
