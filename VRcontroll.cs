using UnityEngine;
using UnityEngine.XR;

public class VRcontroll : MonoBehaviour
{
    public Transform xrRig;
    public Transform head;
    public float moveSpeed = 1.0f;

    void Update()
{
    var left = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    left.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 input);

    Debug.Log("stick = " + input);

    Vector3 forward = head.forward;
    forward.y = 0;
    forward.Normalize();

    Vector3 right = head.right;
    right.y = 0;
    right.Normalize();

    Vector3 move = forward * input.y + right * input.x;

    xrRig.position += move * moveSpeed * Time.deltaTime;
}
}