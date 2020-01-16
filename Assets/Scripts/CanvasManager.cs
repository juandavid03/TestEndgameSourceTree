using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image hitPointsImage;
    public Image teleportCooldownImg;

    [SerializeField]
    private GameObject generalPanel;
    [SerializeField]
    private GameObject instructionsPanel;
    [SerializeField]
    private Text infoText;

    private void Start()
    {
        if(SceneController._instance.getCurrentScene() == SceneController._instance.menuScene)
        {
            generalPanel.SetActive(true);
            instructionsPanel.SetActive(false);
        }

        if (SceneController._instance.getCurrentScene() == SceneController._instance.gameScene)
        {
            infoText.enabled = false;
        }
    }
    public void ReduceHpBar(float fillAmount)
    {
        hitPointsImage.fillAmount = fillAmount;
    }

    public void PlayBtn()
    {
        SceneController._instance.LoadPlayScene();
    }

    public void InstructionsBtn()
    {
        instructionsPanel.SetActive(true);
        generalPanel.SetActive(false);
    }

    public void BackBtn()
    {
        generalPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void PauseBtn()
    {

    }

    public void DisplayInfoText(string message)
    {
        infoText.text = message;
        infoText.enabled = true;
        StartCoroutine(DisapearInfoTextCR());
    }

    IEnumerator DisapearInfoTextCR()
    {
        yield return new WaitForSeconds(2);
        infoText.text = null;
        infoText.enabled = false;
    }
}
