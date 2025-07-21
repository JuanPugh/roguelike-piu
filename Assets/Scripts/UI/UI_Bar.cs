using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bar : MonoBehaviour
{
    [SerializeField] private Slider fillBar;
    //[SerializeField] private TextMeshProUGUI numberBar;

    protected int max_value;
    protected int value;

    public virtual void Start()
    {
        fillBar = GetComponent<Slider>();
        //numberBar = transform.GetChild(transform.childCount - 1).GetComponent<TextMeshProUGUI>();
    }

    public virtual void UpdateMaxValue() { }

    protected void updateBar(int value)
    {
        fillBar.value = (float)value / (float)max_value;
        //numberBar.text = $"{value} / {max_value}";
    }
}
