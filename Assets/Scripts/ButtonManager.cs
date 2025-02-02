using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject codeWindow;
    public BlockManager blockManager;
    private Coroutine playCoroutine;
    public FadeController fadeController;
    
    public void ResetButton()
    {
        fadeController.Fade();
        Transform[] childBlock = new Transform[codeWindow.transform.childCount];
        for (int i = 0; i < codeWindow.transform.childCount; i++)
        {
            childBlock[i] = codeWindow.transform.GetChild(i);
        }
        
        foreach (Transform child in childBlock)
        {
            Destroy(child.gameObject);
        }
        
        blockManager.listOfLists.Clear();
    }

    public void PlayButton()
    {
        int listCnt = 0;
        int listNum = -1;
        for (int i = 0; i < blockManager.listOfLists.Count; i++)
        {
            if (blockManager.listOfLists[i].blockList.Count > 0)
            {
                listCnt++;
                listNum = i;
            }
        }

        if (listCnt != 1)
        {
            Debug.Log("실행하기 위해선 하나의 블록 리스트만 존재해야 합니다.");
            return;
        }
        
        Debug.Log(listNum);

        if (playCoroutine != null)
        {
            StopCoroutine(playCoroutine);
        }
        
        playCoroutine = StartCoroutine(blockManager.PlayBlocks(blockManager.listOfLists[listNum].blockList));
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        blockManager = FindObjectOfType<BlockManager>();
        fadeController = FindObjectOfType<FadeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
