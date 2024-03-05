using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("OnLevelFinish", 1f);

        LevelCanvasManager.instance.SetActiveFinishedUI();
    }

    void OnLevelFinish()
    {
        CharacterMovement.instance.enabled = false;
    }
}
