using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UpperPanelManager : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.DOScale(Vector3.one, 0.5f);
        }
    }

    public void CloseUpperPanel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.DOScale(Vector3.zero, 0.5f);
        }
    }

    public void ShowArrowsAsGray(int arrowCount)
    {
        GameObject arrowGrid = transform.GetChild(0).gameObject;
        for (int i = 0; i < 10; i++)
        {
            GameObject child =arrowGrid.transform.GetChild(i).gameObject;
            if (arrowCount > i)
            {
                child.gameObject.SetActive(true);
                child.GetComponent<Image>().color = Color.gray;
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowArrowColorful(int currentArrowCount)
    {
        transform.GetChild(0).transform.GetChild(currentArrowCount).GetComponent<Image>().color = Color.white;
    }

    public void CloseAnArrow(int currentArrowCount)
    {
        transform.GetChild(0).transform.GetChild(currentArrowCount).gameObject.SetActive(false);
    }
}
