/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformUtil {
    public sttaic bool IsRightOf (Vector3 forward, Vector3 point, Vector3 up) {
        Vector3 perp = Vector3.Cross(forward, point);
        float dir = Vector3.Dot(perp, up);

        return dir > 0.0f;
    }
    /*
        The idea,
        We want our convex hull to go clockwise (if you want it counter-clockwise, the change is trivial)

        We tentatively assume that the first point is the next point for our convex hull.
        We draw an arrow from `cur` to this tentative result.
        For all the other points,
            If they fall on the left of this arrow, they are "more convex", for lack of a better word,

        We pick the point that has no other points to the left of the arrow draw from `cur` to itself.
    * /
    public static Transform FindNextConvexHullPoint2D (Transform cur, List<Transform> opened) {
        Transform nxt = opened[0];

        for (int i=1; i<arr.Length; ++i) {
            Transform nxtCandidate = opened[i];
            if (!IsRightOf(nxt.position - cur.position, nxtCandidate, Vector3.forward)) {
                nxt = nxtCandidate;
            }
        }
        return nxt;
    }

    public delegate bool UseTransformPredicate (Transform t);
    public static List<Transform> ConvexHull2D (Transform[] arr, UseTransformPredicate usePredicate) {
        if (usePredicate == null) {
            usePredicate = (Transform t) => {
                return true;
            };
        }
        List<Transform> opened = new List<Transform>(arr);
        List<Transform> result = new List<Transform>();


        while (opened.Count > 0) {
            Transform cur = opened[0];
            cur.RemoveAt(0);

            for (int i=0; i<arr.Length; ++i) {
                Transform cur = arr[index];

            }

            if (usePredicate(cur)) {
                result.Add(cur);
                break;
            }
            ++index;
        }
        for (int i=index+1; i<arr.Length; ++i) {
            Transform nxt = arr[i];

        }

        for (int i=0; i<arr.Length; ++i) {
            for (int j=i+1; j<arr.Length; ++j) {

            }
        }
        return result;
    }
}
*/
