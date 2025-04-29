using Unity.Cinemachine;
using UnityEngine;

public class CustomCameraOffset : MonoBehaviour
{
    public CinemachineCamera cineMachineCamera;
    public CinemachinePositionComposer positionComposer;

    private void Start()
    {
        positionComposer = cineMachineCamera.GetComponent<CinemachinePositionComposer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        positionComposer.TargetOffset.y = -1.8f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        positionComposer.TargetOffset.y = 0f;

    }
}
