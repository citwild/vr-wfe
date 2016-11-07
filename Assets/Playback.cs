using UnityEngine;
using UnityEngine.VR;
using System;
using System.Collections;
using System.IO;

public class Playback : MonoBehaviour
{
	public GameObject leftSphere, rightSphere;
	//
	//	private const string logPrefix = "InputTrackerChecker: ";
	//
	[SerializeField] VRNode m_VRNode = VRNode.Head;

	void Start ()
	{
//		StartCoroutine (EndOfFrameUpdate ());
		((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).Play ();
		((MovieTexture)rightSphere.GetComponent<Renderer> ().material.mainTexture).Play ();
		GetComponent<AudioSource> ().Play ();
	}

	void Update ()
	{
//		LogRotation ("Update");

		Debug.Log (string.Format ("SWIS Time {0} Rotation {1}", DateTime.Now.Second.ToString ("F2"), UnityEngine.VR.InputTracking.GetLocalRotation (m_VRNode)));

		if (Input.GetKey (KeyCode.Space)) {
			if (((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).isPlaying) {
				((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).Pause ();
			} else {
				((MovieTexture)leftSphere.GetComponent<Renderer> ().material.mainTexture).Play ();
			}
		}

		if (Input.GetKey (KeyCode.Q)) {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit ();
			#endif
		}
	}
	//
	//	private void LateUpdate ()
	//	{
	//		LogRotation ("Late");
	//	}
	//
	//	private IEnumerator EndOfFrameUpdate ()
	//	{
	//		while (true) {
	//			yield return new WaitForEndOfFrame ();
	//			LogRotation ("EndOfFrame");
	//		}
	//	}
	//
	//	private void LogRotation (string id)
	//	{
	//		var quaternion = InputTracking.GetLocalRotation (m_VRNode);
	//		var euler = quaternion.eulerAngles;
	//		Debug.Log (string.Format ("{0} {1}, Time {3} Euler {4}", logPrefix, id, DateTime.Now.Second.ToString ("F2"), euler.ToString ("F2")));
	//	}
}