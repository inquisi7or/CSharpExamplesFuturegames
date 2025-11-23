using System.Collections.Generic;

public interface IWeaponFactory {
    public IWeapon CreateWeapon();
    public void AddAttachment(IAttachment attachment);
}

public class SniperFactory : IWeaponFactory {
    private Sniper sniper;
    public IWeapon CreateWeapon() {
        sniper = new Sniper() {
            ID = "Sniper"
        };
        sniper.AssembleWeapon("Sniper");
        return sniper;
    }
    public void AddAttachment(IAttachment attachment) {
        sniper.Attachments.Add(attachment);
    }
}

public class SmgFactory : IWeaponFactory {
    private Smg smg;
    public IWeapon CreateWeapon() {
        smg = new Smg() {
            ID = "Light SMG"
        };
        smg.AssembleWeapon("SMG");
        return smg;
    }
    public void AddAttachment(IAttachment attachment) {
        smg.Attachments.Add(attachment);
    }
}
