using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDistanceEstimation : MonoBehaviour {
	public GameObject a;
	public GameObject b;
    public GameObject c;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}
    void V3 (string label, Vector3 v) {
        GUILayout.Button(
            System.String.Format(
                "{0}: {1}, {2}, {3}",
                label,
                v.x.ToString("R"),
                v.y.ToString("R"),
                v.z.ToString("R")
            )
        );
    }
	void OnGUI () {
        if (a == null || b == null || c == null) {
            return;
        }
		Vector3 delta = a.transform.position - b.transform.position;
		GUILayout.Button("A to B: " + delta.magnitude.ToString());

        delta = c.transform.position - b.transform.position;
        GUILayout.Button("C to B: " + delta.magnitude.ToString());

        delta = c.transform.position - a.transform.position;
        GUILayout.Button("C to A: " + delta.magnitude.ToString());

        V3("A", a.transform.position);
        V3("B", b.transform.position);
        V3("C", c.transform.position);
	}
}
