using System.Linq;
using UnityEngine;
using UnityTools.Extentions;

public class UISolver : MonoBehaviour
{
    public UIScreen[] screens { get; private set; }

    private void Awake()
    {
        screens = GetComponentsInChildren<UIScreen>();
    }

    public T Get<T>() where T : UIScreen
    {
        return screens.OfType<T>().FirstOrDefault();
    }
}
