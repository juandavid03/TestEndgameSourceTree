using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    //Variables for the game Scene
    public Image hitPointsImage;
    public Image teleportCooldownImg;
    [SerializeField]
    private Text infoText;

    //Variables for the menu scene.
    [SerializeField]
    private GameObject generalPanel;
    [SerializeField]
    private GameObject instructionsPanel;


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

    //Healthbar management.
    public void ReduceHpBar(float fillAmount)
    {
        hitPointsImage.fillAmount = fillAmount;
    }

    //Button Management methods.
    #region Button Management
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

    #endregion
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
