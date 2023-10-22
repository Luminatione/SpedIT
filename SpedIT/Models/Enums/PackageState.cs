using System.ComponentModel;

namespace SpedIT_Domain.Models.Enums
{
    public enum PackageState
    {
        ToBePickedUp,
        Waiting,
        ReadyToDeliver,
        InDelivery,
        Delivered
    }
}
