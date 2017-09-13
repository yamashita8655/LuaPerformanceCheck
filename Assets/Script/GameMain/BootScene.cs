using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class BootScene : MonoBehaviour {
	[SerializeField] Canvas MainCanvas;
	[SerializeField] Text OutputText;
	[SerializeField] Button TriggerButton;

	[SerializeField] AudioSource AudioSource;

	private string StartDebugLog = "";
	private string ClickDebugLog = "";

	IEnumerator coroutineFunction = null;

	AudioClip TestSound1 = null;

	enum BitTest {
		None = 0,
		One = 1,
		Two = 1 << 1,
		Both = One | Two,
		Three = 1 << 2,
		Four = 1 << 3,
	}

	BitTest bitTest = BitTest.None;

	IEnumerator CoroutineUpdate() {
		while (true) {
			Debug.Log("1");
			yield return null;
			Debug.Log("2");
			yield return null;
			Debug.Log("3");
			yield return null;
		}
	}

	// Use this for initialization
	void Start () {
		Debug.Log((int)BitTest.None);
		Debug.Log((int)BitTest.One);
		Debug.Log((int)BitTest.Two);
		Debug.Log((int)BitTest.Three);
		Debug.Log((int)BitTest.Four);
		Debug.Log((int)BitTest.Both);

		bitTest = BitTest.One|BitTest.Two;
		if ((bitTest & BitTest.One) == BitTest.One) {
			Debug.Log("One");
		}
		if ((bitTest & BitTest.Two) == BitTest.Two) {
			Debug.Log("Two");
		}
		if ((bitTest & BitTest.Three) == BitTest.Three) {
			Debug.Log("Three");
		}
		if ((bitTest & BitTest.Four) == BitTest.Four) {
			Debug.Log("Four");
		}
		if ((bitTest & BitTest.Both) == BitTest.Both) {
			Debug.Log("Both");
		}

		Application.targetFrameRate = 60;

		//StartDebugLog += "↓↓↓↓↓start↓↓↓↓↓\n\n";

		//uint monoSize = Profiler.GetMonoHeapSize();
		//uint monoUsed = Profiler.GetMonoUsedSize();
		//uint tempSize = Profiler.GetTempAllocatorSize();
		//uint totalUsed = Profiler.GetTotalAllocatedMemory();
		//uint totalSize = Profiler.GetTotalReservedMemory();

		//StartDebugLog += string.Format("mono:{0}/{1}kb\ntotal:{2}/{3}kb\ntemp:{4}kb\n\n", monoUsed/1024, monoSize/1024, totalUsed/1024, totalSize/1024, tempSize/1024);
		//StartDebugLog += "↑↑↑↑↑start↑↑↑↑↑\n\n";

		TestSound1 = Resources.Load<AudioClip>("TestSound1");

		StartCoroutine(CoroutineStart());
		coroutineFunction = CoroutineUpdate();
	}

	private IEnumerator CoroutineStart() {
		GameSceneManager.Instance.Initialize();
		GameObjectCacheManager.Instance.Initialize();
		AssetBundleManager.Instance.Initialize();
		ResourceManager.Instance.Init();
		RijindaelManager.Instance.Init();
		VersionFileManager.Instance.Initialize();

		yield return StartCoroutine(LuaInit());

		Debug.Log("C#:timestamp " + Time.realtimeSinceStartup);
		int a = 0;
		for (int i = 0; i < 1000000; i++) {
			a = 1;
		}
		Debug.Log("C#:timestamp " + Time.realtimeSinceStartup);

		//ClickDebugLog = "↓↓↓↓↓click↓↓↓↓↓\n\n";

		//uint monoSize = Profiler.GetMonoHeapSize();
		//uint monoUsed = Profiler.GetMonoUsedSize();
		//uint tempSize = Profiler.GetTempAllocatorSize();
		//uint totalUsed = Profiler.GetTotalAllocatedMemory();
		//uint totalSize = Profiler.GetTotalReservedMemory();

		//ClickDebugLog += string.Format("mono:{0}/{1}kb\ntotal:{2}/{3}kb\ntemp:{4}kb\n\n", monoUsed/1024, monoSize/1024, totalUsed/1024, totalSize/1024, tempSize/1024);
		//ClickDebugLog += "↑↑↑↑↑click↑↑↑↑↑\n\n";
		//OutputText.text = StartDebugLog + ClickDebugLog;
//		//yield return null;
	}

	IEnumerator LuaInit() {
		float factor = MainCanvas.scaleFactor;
		yield return StartCoroutine(UnityUtility.Instance.Init());
	}

	public void OnClickTriggerButton() {
/*		ClickDebugLog = "↓↓↓↓↓click↓↓↓↓↓\n\n";

		uint monoSize = Profiler.GetMonoHeapSize();
		uint monoUsed = Profiler.GetMonoUsedSize();
		uint tempSize = Profiler.GetTempAllocatorSize();
		uint totalUsed = Profiler.GetTotalAllocatedMemory();
		uint totalSize = Profiler.GetTotalReservedMemory();

		ClickDebugLog += string.Format("mono:{0}/{1}kb\ntotal:{2}/{3}kb\ntemp:{4}kb\n\n", monoUsed/1024, monoSize/1024, totalUsed/1024, totalSize/1024, tempSize/1024);
		ClickDebugLog += "↑↑↑↑↑click↑↑↑↑↑\n\n";*/
//		OutputText.text = StartDebugLog + ClickDebugLog;
//		StartCoroutine(InitLua());

		AudioSource.clip = TestSound1;
		AudioSource.Play();
	}

	IEnumerator InitLua() {
		yield return StartCoroutine(LuaInit());
	}
	void Update() {
		/*if (coroutineFunction != null) {
			if (coroutineFunction.MoveNext() == false) {
				coroutineFunction = null;
			}
		}*/
	}
}
