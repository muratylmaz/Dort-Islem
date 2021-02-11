using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefsBase : MonoBehaviour
{
    [SerializeField]
    private Sprite ImageOn;
    [SerializeField]
    private Sprite ImageOff;
    private Image childSourceImage;
    public string key;
    
    public void Start()
    {
        childSourceImage = transform.GetChild(0).GetComponent<Image>();

        if (PlayerPrefs.HasKey(key))
        {
            if (PlayerPrefs.GetInt(key) == 1)
            {
                childSourceImage.sprite = ImageOn;
            }
            else
            {
                childSourceImage.sprite = ImageOff;
            }
        }
        else
        {
            PlayerPrefs.SetInt(key, 1);
            childSourceImage.sprite = ImageOn;
        }
    }

    public void ChangeImage()
    {
        if (PlayerPrefs.GetInt(key) == 1)
        {
            childSourceImage.sprite = ImageOff;
            PlayerPrefs.SetInt(key, 0);
        }
        else
        {
            childSourceImage.sprite = ImageOn;
            PlayerPrefs.SetInt(key, 1);
        }
    }
}
