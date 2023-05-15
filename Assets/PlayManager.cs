using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController camController;
    [SerializeField] GameObject finishWindow;
    [SerializeField] TMP_Text finishText;
    [SerializeField] TMP_Text shootCountText;

    bool isBallOutside;
    bool isBallTeleporting;
    bool isGoal;
    Vector3 lastBallposition;
    private void OnEnable(){
        ballController.onBallShooted.AddListener(UpdateShootCount);
    }
    private void OnDisable(){
        ballController.onBallShooted.RemoveListener(UpdateShootCount);
    }
    private void Update() {
        if (ballController.ShootingMode)
        {
            lastBallposition = ballController.transform.position;
        }

        var inputActive = Input.GetMouseButton(0) 
            && ballController.IsMove() == false 
            && ballController.ShootingMode == false
            && isBallOutside == false;
            
        camController.SetInputActive(inputActive);
    }

    public void OnBallGoalEnter() {
        isGoal = true;
        ballController.enabled = false;

        finishWindow.gameObject.SetActive(true);
        finishText.text = "Finished!!!|n" + "Shoot Count: " + ballController.ShootCount;
    }

    public void OnBallOutside()
    {
        if (isGoal)
            return;

        if(isBallOutside == false)
            Invoke("TeleportBallLastPosition", 3);

        ballController.enabled = false;
        isBallOutside = true;
        isBallTeleporting = true;
    }

    public void TeleportBallLastPosition()
    {
        TeleportBall(lastBallposition);
    }

    public void TeleportBall(Vector3 targetPosition) {
        var rb = ballController.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballController.transform.position = targetPosition;
        rb.isKinematic = false;

        ballController.enabled = true;
        isBallOutside = false;
        isBallTeleporting = false;
    }

    public void UpdateShootCount(int shootCount)
    {
        shootCountText.text = shootCount.ToString();
    }
}