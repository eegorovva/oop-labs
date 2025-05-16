namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.UpdatesForShip;

public class PhotonDeflector
{
    private const int UsedCharge = 1;
    private int _charges;

    public PhotonDeflector()
    {
        _charges = 3;
    }

    public int Charges
    {
        get
        {
            return _charges;
        }
    }

    public void ActivatePhotonDeflector()
    {
        _charges -= UsedCharge;
    }
}