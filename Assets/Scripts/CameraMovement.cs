using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    private Transform cameraTransform;


    private void Start() {
        cameraTransform = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.transform;
    }

    private void Update() {
        Vector2 moveVector = InputManagerEvents.RequestCameraMovementVector();

        if (moveVector.sqrMagnitude == 0) return;

        Vector3 newPos = new Vector3(moveVector.x, moveVector.y, 0f);
        cameraTransform.Translate(newPos * Time.deltaTime * moveSpeed);
    }

}
