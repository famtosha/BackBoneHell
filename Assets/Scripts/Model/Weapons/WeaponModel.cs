using System;

[Serializable]
public class WeaponModel
{
    public WeaponModel model { get; private set; }

    public WeaponModel(WeaponModel model)
    {
        this.model = model;
    }
}
