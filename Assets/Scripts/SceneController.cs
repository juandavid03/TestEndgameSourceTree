using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //Scene in charge of everythin related to scenes.
    #region Variables
    public static SceneController _instance = null;
    public string gameScene = "SampleScene";
    public string menuScene = "MainMenu";
    public string victoryScene = "victoryScene";
    #endregion

    #region Singleton Definition
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (_instance == null)

            //if not, set instance to this
            _instance = this;

        //If instance already exists and it's not this:
        else if (_instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
    #endregion

    public string getCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuScene);
    }
}
