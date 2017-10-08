using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TestDistanceEstimation : MonoBehaviour {
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject mid;


    void Start() {
        Invoke("Init", 2f);
    }

	// Use this for initialization
	void Init () {
        
        Screen.orientation = ScreenOrientation.LandscapeRight;
	}

    private static Vector3 CalculateMid (Vector3 a, Vector3 b) {
        return (a + b)/2;
    }

	// Update is called once per frame
	void LateUpdate () {
        /*if (a == null || b == null || c == null || mid == null) {
            return;
        }*/
        /*
                TrackableBehaviour.Status aStatus = a.GetComponent<TrackableBehaviour>().CurrentStatus;
                TrackableBehaviour.Status bStatus = b.GetComponent<TrackableBehaviour>().CurrentStatus;
                TrackableBehaviour.Status cStatus = c.GetComponent<TrackableBehaviour>().CurrentStatus;
                TrackableBehaviour.Status dStatus = d.GetComponent<TrackableBehaviour>().CurrentStatus;
                */
        /*
                Vector3 aPosition = a.transform.position;
                Vector3 bPosition = b.transform.position;
                Vector3 cPosition = c.transform.position;
                Vector3 dPosition = d.transform.position;

                Vector3 topMid = CalculateMid(aPosition, bPosition);
                Vector3 bottomMid = CalculateMid(cPosition, dPosition);
                Vector3 leftMid = CalculateMid(aPosition, bPosition);
        */
        /*float totalX = a.transform.position.x + b.transform.position.x;
        float totalY = a.transform.position.y + c.transform.position.y;
        float totalZ = a.transform.position.z + b.transform.position.z + c.transform.position.z;
        Vector3 midPosition = new Vector3(
            totalX/2,
            totalY/2,
            totalZ/3
        );
        //Vector3 total = a.transform.position + b.transform.position + c.transform.position;// + d.transform.position;
        //Vector3 midPosition = total/3;
        mid.transform.position = midPosition;*/

        float totalX = a.transform.position.x + b.transform.position.x;
        float totalY = a.transform.position.y;// + b.transform.position.y + c.transform.position.z;
        float totalZ = a.transform.position.z + c.transform.position.z;
        Vector3 midPosition = new Vector3(
            totalX / 2,
            totalY / 1,//3,
            totalZ / 2
        );
        //Vector3 total = a.transform.position + b.transform.position + c.transform.position;// + d.transform.position;
        //Vector3 midPosition = total/3;
        mid.transform.position = midPosition;

        Sprite sprite = mid.GetComponent<SpriteRenderer>().sprite;


        float desiredLength = (a.transform.position-b.transform.position).magnitude;
        float originalLength = sprite.bounds.max.x - sprite.bounds.min.x;
        mid.transform.localScale = new Vector3(
            desiredLength/originalLength,
            desiredLength/originalLength,
            1
        );

        Vector3 normal = GetNormal(a.transform.position, b.transform.position, c.transform.position);
        Vector3 lookAt = midPosition + normal * 10;

        mid.transform.localEulerAngles = new Vector3(90, 0, 0);
        //mid.transform.LookAt(lookAt);
        //mid.transform.localEulerAngles += new Vector3(0, 0, -90);

        /*float theta = Mathf.Atan2(
            a.transform.position.y-b.transform.position.y,
            a.transform.position.x-b.transform.position.x
        ) * Mathf.Rad2Deg;


        //mid.transform.RotateAround(transform.position, normal, -theta);
        if (theta > 90 || theta < -90) {
            mid.transform.Rotate(new Vector3(0, 0, -theta-90), Space.Self);
        } else {
            mid.transform.Rotate(new Vector3(0, 0, +theta+90), Space.Self);
        }*/

        float theta = Mathf.Atan2(
            
            a.transform.position.z - b.transform.position.z,
            a.transform.position.x - b.transform.position.x
        ) * Mathf.Rad2Deg;

        //mid.transform.Rotate(new Vector3(0, 0, -theta - 90), Space.Self);
        //mid.transform.RotateAround(transform.position, normal, -theta);
        if (theta < 90 && theta > -90)
        {
            mid.transform.Rotate(new Vector3(0, 0, +theta + 90), Space.Self);
            //mid.transform.Rotate(new Vector3(-theta - 90, 0, 0), Space.Self);
        }
        else
        {
            mid.transform.Rotate(new Vector3(0, 0, -theta - 90), Space.Self);
            //mid.transform.Rotate(new Vector3(+theta + 90, 0, 0), Space.Self);
        }

    }
    Vector3 GetNormal(Vector3 a, Vector3 b, Vector3 c) {
        Vector3 side1 = b - a;
        Vector3 side2 = c - a;
        return Vector3.Cross(side1, side2).normalized;
    }
    void OnDrawGizmos () {
        Vector3 total = a.transform.position + b.transform.position + c.transform.position;
        Vector3 midPosition = total/3;

        Sprite sprite = mid.GetComponent<SpriteRenderer>().sprite;

        Vector3 desiredLeft = a.transform.position;
        Vector3 desiredRight = b.transform.position;

        float desiredLength = (desiredRight-desiredLeft).magnitude;
        float originalLength = sprite.bounds.max.x - sprite.bounds.min.x;

        Vector3 normal = GetNormal(a.transform.position, b.transform.position, c.transform.position);
        Vector3 cross = normal;//GetNormal(desiredLeft, normal, desiredRight);//Vector3.Cross(desiredLeft-midPosition, desiredRight-midPosition);
        Vector3 lookAt = midPosition + cross * 10;

        float theta = Mathf.Atan2(
            a.transform.position.z-b.transform.position.z,
            a.transform.position.x-b.transform.position.x
        ) * Mathf.Rad2Deg;

       // Debug.Log(theta);

        Gizmos.DrawWireSphere(desiredLeft, 1);
        Gizmos.DrawWireSphere(desiredRight, 1);
        Gizmos.DrawWireSphere(lookAt, 1);
        Gizmos.DrawLine(midPosition, lookAt);
        Gizmos.DrawLine(midPosition, midPosition + new Vector3(
            Mathf.Cos(theta * Mathf.Deg2Rad),
            0,
            Mathf.Sin(theta * Mathf.Deg2Rad)
        ) * 10);
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
        GUILayout.Button(
            System.String.Format(
                "{0}: {1}",
                label,
                v
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
		V3("Mid", c.transform.position);

        V3("Mid Rotation", mid.transform.localEulerAngles);

        float theta = Mathf.Atan2(
            a.transform.position.z-b.transform.position.z,
            a.transform.position.x-b.transform.position.x
        ) * Mathf.Rad2Deg;
        GUILayout.Button("Theta: " + theta.ToString());
	}
}
