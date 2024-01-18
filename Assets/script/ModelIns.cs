using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelIns : MonoBehaviour
{
    public GameObject modelPrefab;
   

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate
        {
            GameObject go = Instantiate(modelPrefab);
            go.transform.position = new Vector3(13f,0,-7f);
            go.layer = LayerMask.NameToLayer("modes");
        });
    }

}
