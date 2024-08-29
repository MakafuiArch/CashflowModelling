namespace IRR.Domain.Model
{

    enum ViewType: Byte
    {
        ArchView = 1, 
        StressView = 2,
        ClientView = 3
    }


    enum PremiumView: Byte
    {
        Proportional = 1,
        Finance = 2,
        Seasonal  = 3

    }

}
