using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoruceDetector : MonoBehaviour
{
    //Variables publicas
    public ResourceManager resourceManager;

    //Si entra un objeto en el trigger
    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto es un recuerso
        if(other.gameObject.GetComponent<Resource>())
        {
            resourceManager.AddResource(other.gameObject.GetComponent<Resource>().value);
            Destroy(other.gameObject);
        }
    }
}

