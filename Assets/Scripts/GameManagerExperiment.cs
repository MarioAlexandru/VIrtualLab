using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerExperiment : MonoBehaviour
{

    public TextMeshProUGUI ElementSymbol;
    public TextMeshProUGUI ElementName;
    public TextMeshProUGUI ElementColour;

    private static GameManagerExperiment _Instance;

    public static GameManagerExperiment Instance { get => _Instance; }

    private void Awake()
    {
        if(_Instance !=null && _Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _Instance = this;
        }
    }

    void Start()
    {
        ElementSymbol.SetText("");
        ElementName.SetText("");
        ElementColour.SetText("");
    }

    public void ShowSelectedElement(Element element)
    {
        ElementSymbol.SetText(element.ElementName);
        ElementName.SetText(element.Symbol);
    }
    public void ShowElementColour(Element element)
    {
        ElementColour.SetText(element.FlameColour);
    }

    public void HideElementText()
    {
        ElementSymbol.SetText("");
        ElementName.SetText("");
        ElementColour.SetText("");
    }
}
