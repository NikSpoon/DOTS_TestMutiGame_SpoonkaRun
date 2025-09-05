using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMeniMenu : MonoBehaviour
{
    [SerializeField] private GameObject _options;
   
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Options() 
    {
        _options.SetActive(true);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Закрывает билд
#endif
    }
    public void Update()
    {

        if (_options.activeSelf &&  Input.GetKey(KeyCode.Escape))
        {
            _options.SetActive(false);
            return;
        }
    }
}
