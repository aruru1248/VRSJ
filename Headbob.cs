using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("移動元(XRRig)")]
    public Transform xrRig;

    [Header("揺れ設定")]
    public float bobSpeed = 10f;
    public float bobAmount = 0.03f;

    private Vector3 initialLocalPos;
    private Vector3 lastRigPos;
    private float timer;

    void Start()
    {
        initialLocalPos = transform.localPosition;

        if (xrRig != null)
            lastRigPos = xrRig.position;
    }

    void Update()
    {
        if (xrRig == null)
            return;

        float speed =
            Vector3.Distance(xrRig.position, lastRigPos)
            / Time.deltaTime;

        if (speed > 0.05f)
        {
            timer += Time.deltaTime * bobSpeed;

            Vector3 pos = initialLocalPos;
            pos.y += Mathf.Sin(timer) * bobAmount;

            transform.localPosition = pos;
        }
        else
        {
            timer = 0;

            transform.localPosition =
                Vector3.Lerp(
                    transform.localPosition,
                    initialLocalPos,
                    Time.deltaTime * 5f);
        }

        lastRigPos = xrRig.position;
    }
}
