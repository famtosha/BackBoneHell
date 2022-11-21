using TMPro;
using UnityEngine;

public class SoulCountScreen : UIScreen
{
    [SerializeField] private TMP_Text _count;

    private Wallet _wallet;

    protected override void Awaked()
    {
        _wallet = FindObjectOfType<SystemsSolver>().Get<LevelLoadingSystem>().gameData.soulCount;
        UpdateInfo(_wallet);
    }

    protected override void Opened()
    {
        _wallet.CountChanged.AddListener(UpdateInfo);
    }

    protected override void Closed()
    {
        _wallet.CountChanged.RemoveListener(UpdateInfo);
    }

    private void UpdateInfo(Wallet wallet)
    {
        _count.text = wallet.count.ToString();
    }
}
