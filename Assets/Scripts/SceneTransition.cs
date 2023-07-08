using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class SceneTransition : SingletonMonoBehaviour<SceneTransition>
{
    // Start is called before the first frame update
    public float fadeDuration = 2f;
    public string targetScene;
    AsyncOperation operation;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        // ��ȡ CanvasGroup ���
        canvasGroup = GetComponent<CanvasGroup>();
        //StartFadeIn(Const.BattleGuideScene);
    }

    private void Update()
    {
        if(operation != null)
        {
            if (operation.isDone)
            {
                canvasGroup.DOFade(0, fadeDuration);
                operation = null;
            }
        }
    }

    public void StartFadeIn(string name)
    {
        // ��ʼ��͸����Ϊ 0
        canvasGroup.alpha = 0;

        // ִ�н���Ч��
        canvasGroup.DOFade(1, fadeDuration).OnComplete(delegate { LoadTargetScene(name); });
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(name);
    }

    private void LoadTargetScene(string name)
    {
        // ʹ�� SceneManager ����Ŀ�곡��
        operation = SceneManager.LoadSceneAsync(name);
    }
}
