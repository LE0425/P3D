using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl : MonoBehaviour
{
    public GameObject jiajuzu;
    //public GameObject jiajuanniuzu;


    void Start()
    {
        int pos = this.transform.GetSiblingIndex();
        this.GetComponent<Button>().onClick.AddListener(delegate
        {
            for(int i = 0; i < jiajuzu.transform.childCount; i++)
            {
                if (pos == i)
                {
                    jiajuzu.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    jiajuzu.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        });
    }

}
