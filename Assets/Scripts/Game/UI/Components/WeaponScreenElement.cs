using UnityEngine;
using UnityEngine.UI;
using UnityTools.Extentions;

public class WeaponScreenElement : MonoBehaviour
{
    [SerializeField] private Image _weaponImage;

    private WeaponDisplayComponent _linkedWeapon;

    public void Init(WeaponDisplayComponent weapon)
    {
        _linkedWeapon = weapon;
        _linkedWeapon.WeaponChanged.AddListener(OnWeaponChanged);
    }

    private void OnWeaponChanged()
    {
        if (_linkedWeapon.linkedWeapon != null)
        {
            _weaponImage.SetSpriteWithoutBackground(_linkedWeapon.linkedWeapon.displaySprite);
        }
        else
        {
            _weaponImage.SetSpriteWithoutBackground(null);
        }
    }
}
