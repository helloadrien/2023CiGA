using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCtl : MonoBehaviour
{

    public string currentScene;
    public string nextScene;
    // Start is called before the first frame update

    private void Start()
    {
        AudioManager.PlayBgm(AudioManager.BGM_Fight);
    }

    // ս��ʧ��
    public void RestartScene()
    {
        AudioManager.PlayEffect(AudioManager.Effect_Failed);

        SceneTransition.Instance.StartFadeIn(currentScene);
    }

    // ս��ʤ��
    public void NextScene()
    {
        AudioManager.PlayEffect(AudioManager.Effect_Victory);

        SceneTransition.Instance.StartFadeIn(nextScene);
        
    }
}
