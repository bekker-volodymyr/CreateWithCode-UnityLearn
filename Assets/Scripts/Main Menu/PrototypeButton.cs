using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrototypeButton : MonoBehaviour
{
    private Button _button;

    [SerializeField]
    private string _sceneName;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LoadPrototype);
    }

    private void LoadPrototype()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
