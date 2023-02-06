using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr Instance { get; set; }
    private int _lastSceneIndex = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void ChangeSceneById(int sceneId)
    {
        UIManager.Instance.RemoveAllPanel();
        _lastSceneIndex = GetCurrentSceneIndex();
        SceneManager.LoadScene(sceneId);
    }

    public void ChangeSceneByName(string sceneName)
    {
        _lastSceneIndex = GetCurrentSceneIndex();
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeLastScene()
    {
        SceneManager.LoadScene(_lastSceneIndex);
    }

    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}