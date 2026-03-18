using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MainMenuBtn : MonoBehaviour, ISelectHandler, IDeselectHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Outline outline;
    [SerializeField]
    private Button btn;
    [SerializeField]
    private Color outlineColorOnSelect = Color.blue;
    private Color lastColor = Color.black;
    public void Start()
    {
        if (outline == null)
            outline = GetComponent<Outline>();
    
        if (btn == null)
            btn = GetComponent<Button>();
    }
    public void OnSelected()
    {
        lastColor = outline.effectColor;
        outline.effectColor = outlineColorOnSelect;
    }
    public void OnDeselected()
    {
        outline.effectColor = lastColor;
    }
    public void OnSelect(BaseEventData eventData)
    {
        OnSelected();
    }
    public void OnDeselect(BaseEventData eventData)
    {
        OnDeselected();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnSelected();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnDeselected();
    }
}