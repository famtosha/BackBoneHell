using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
        Opened();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Closed();
    }

    protected virtual void Opened()
    {

    }

    protected virtual void Closed()
    {

    }
}
