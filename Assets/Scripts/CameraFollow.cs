using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private Transform targetTransform;

    private void FixedUpdate()
    {
        Vector3 relativeCameraTargetPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, -10f);

        cameraTransform.position = Vector3.Lerp(cameraTransform.position, relativeCameraTargetPosition, Time.fixedDeltaTime);
    }

}
