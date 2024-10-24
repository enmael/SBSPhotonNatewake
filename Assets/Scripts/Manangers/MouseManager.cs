
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    public static MouseManager instance;

    public static MouseManager Instance {  get { return instance; } }  
    private void Awake()
    {
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
       if(instance ==null)
        {
            instance = this;    
        }
       else
        {
            Destroy(gameObject);
            return;
        }
       DontDestroyOnLoad(gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch(scene.buildIndex)
        {
            case 2: SetMouse(false); 
                break;
            default: SetMouse(true);
                break;
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }


    //private void LockMouse()
    //{
    //    Cursor.lockState = CursorLockMode.Locked; 
    //    Cursor.visible = false;
    //}

    //private void LoadScene(int number)
    //{
    //    SceneManager.LoadScene(number);
    //}


    public void SetMouse(bool state)
    {
        Cursor.visible = state;
        // Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;

    }





}
