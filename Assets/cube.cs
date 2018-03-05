using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube : MonoBehaviour {

	GameObject utc_go;
	Text utc;

	// Use this for initialization
	void Start () {
		utc_go = GameObject.Find("utc");
		utc = utc_go.GetComponentInChildren<Text>();
	}

	GameObject[] cuber = new GameObject[10];
	int last_cuber = 0;
	int cuber_iterations = 0;

	string m;
	string s;

	BoxCollider b;

	// Update is called once per frame
	void FixedUpdate ()
	{
		//TIME
		if (System.DateTime.UtcNow.Minute < 10) {m = "0"+System.DateTime.UtcNow.Minute;} else {m = System.DateTime.UtcNow.Minute.ToString();}
		if (System.DateTime.UtcNow.Second < 10) {s = "0"+System.DateTime.UtcNow.Second;} else {s = System.DateTime.UtcNow.Second.ToString();}
		utc.text = (System.DateTime.UtcNow.Hour + ":" + m + ":" + s);

		if (System.DateTime.UtcNow.Second % 2 == 0) {

			//MANAGE
			if (cuber_iterations > 0) {
				Destroy (cuber [last_cuber]);
			}
			cuber [last_cuber] = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cuber [last_cuber].name = "cube["+cuber_iterations+"]["+last_cuber+"]";
			cuber [last_cuber].isStatic = true;

			//OPTIMIZE
			cuber [last_cuber].GetComponentInChildren<MeshRenderer>().reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
			cuber [last_cuber].GetComponentInChildren<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			cuber [last_cuber].GetComponentInChildren<MeshRenderer>().receiveShadows = false;
			cuber [last_cuber].GetComponentInChildren<MeshRenderer>().motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
			cuber [last_cuber].GetComponentInChildren<MeshRenderer>().lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
			cuber [last_cuber].GetComponentInChildren<MeshRenderer>().material = null;//new Material (Shader.Find ("Unlit/Color"));

			b = cuber [last_cuber].GetComponentInChildren<BoxCollider>();
			Destroy(b);

			//PLACE
			float row = (last_cuber / 5);
			float col = (last_cuber - (row * 5)) * 1.5f;
			cuber [last_cuber].transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
			cuber [last_cuber].transform.position = new Vector3 (col - 3, row, 0);

			//SOLVE
			last_cuber++;
			if (last_cuber == 10) {
				last_cuber = 0;
				cuber_iterations++;
			}
		}
	}
}
