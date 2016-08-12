using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class Playback : MonoBehaviour
{

	public GameObject leftSphere, rightSphere;

	private const string logPrefix = "InputTrackerChecker: ";
 
	[SerializeField] VRNode m_VRNode = VRNode.Head;

	private void LateUpdate ()
	{
		LogRotation ("Late");
	}

	private IEnumerator EndOfFrameUpdate ()
	{
		while (true) {
			yield return new WaitForEndOfFrame ();
			LogRotation ("EndOfFrame");
		}
	}

	private void LogRotation (string id)
	{
		var quaternion = InputTracking.GetLocalRotation (m_VRNode);
		var euler = quaternion.eulerAngles;
		Debug.Log (string.Format ("{0} {1}, ({2}) Quaternion {3} Euler {4}", logPrefix, id, m_VRNode, quaternion.ToString ("F2"), euler.ToString ("F2")));
	}

	void Start ()
	{
		StartCoroutine (EndOfFrameUpdate ());
		((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).Play ();
		((MovieTexture)rightSphere.GetComponent<Renderer> ().material.mainTexture).Play ();
		GetComponent<AudioSource> ().Play ();
	}

	void Update ()
	{
		LogRotation ("Update");

		if (Input.GetKey (KeyCode.Space)) {
			if (((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).isPlaying) {
				((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).Pause ();
			} else {
				((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).Play ();
			}
		}

		if (Input.GetKey (KeyCode.Escape)) {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit ();
			#endif
		}
	}
}