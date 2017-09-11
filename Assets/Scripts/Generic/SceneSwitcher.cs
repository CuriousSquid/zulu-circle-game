using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	[SerializeField] [Tooltip("Put -1 for next scene.")]
	private int sceneIndex = -1;

	[SerializeField]
	private float delay;

	// Use this for initialization
	void Start () {
		if (0 > sceneIndex) {
			sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		}
		StartCoroutine(DoDelayedSwitch());
	}
	
	private IEnumerator DoDelayedSwitch() {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneIndex);
	}
}
