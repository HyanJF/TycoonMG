using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    // Variables publicas
    public Text resourceText;
    // Variables privadas
    private float currentResource;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar variables
        currentResource = 0f;
        UpdateUI();
    }

    // Funcion para agregar recursos
    public void AddResource(float _value)
    {
        currentResource += _value;
        UpdateUI();
    }
    // Funcion para quitar recursos
    public void RemoveResources(float _value)
    {
        currentResource -= _value;
        UpdateUI();
    }

    // Funcion para devolver recursos actuales
    public float CurrentResources()
    {
        return currentResource;
    }

    // Funcion para actualizar el UI
    public void UpdateUI()
    {
        resourceText.text = "PejePesos $" + currentResource;
    }
}
