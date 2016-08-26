using System.ComponentModel;

namespace Domain
{
    public enum MaritalStatusEnum
    {
        [Description("Married")]
        Married,
        [Description("Widowed")]
        Widowed,
        [Description("Divorced")]
        Divorced,
        [Description("Single")]
        Single,
    }
}
