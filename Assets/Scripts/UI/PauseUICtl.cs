using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PauseUICtl : MonoBehaviour
{
    public Button ContinueBtn;
    public Button ReturnBtn;
    public Button ExitBtn;
    public GameObject root;
    public GameObject image;



    void Start()
    {
        ContinueBtn.onClick.AddListener(Continue);
        ReturnBtn.onClick.AddListener(Return);
        ExitBtn.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        AudioManager.PlayEffect(AudioManager.Effect_UIClick);

        Application.Quit();
    }

    private void Return()
    {
        AudioManager.PlayEffect(AudioManager.Effect_UIClick);


        Debug.Log("���ر���");
        root.SetActive(false);
        image.SetActive(false);
        Time.timeScale = 1;
        SceneTransition.Instance.StartFadeIn(Const.InitScene);
    }

    private void Continue()
    {
        AudioManager.PlayEffect(AudioManager.Effect_UIClick);
        
        
        Debug.Log("������Ϸ");
        root.SetActive(false);
        image.SetActive(false);
        Time.timeScale = 1;
    }



    // Update is called once per frame
    void Update()
    {
        // ��ͣ����
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("��ͣ");
            Time.timeScale = 0;
            if (root != null)
            {
                root.SetActive(true);
            }
            if (image != null)
            {
                image.SetActive(true);
            }
        }
    }
}
