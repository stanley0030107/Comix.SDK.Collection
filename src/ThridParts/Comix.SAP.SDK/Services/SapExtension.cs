namespace Comix.SAP.SDK.Services;

public class SapExtension
{
    public static string GetSapTaxCode(decimal taxRate)
    {
        string sapTaxCode;
        if (taxRate == 0m)
        {
            sapTaxCode = "0";
        }
        else if (taxRate == 0.13m)
        {
            sapTaxCode = "1";
        }
        else if (taxRate == 0.09m)
        {
            sapTaxCode = "2";
        }
        else if (taxRate == 0.06m)
        {
            sapTaxCode = "3";
        }
        else if (taxRate == 0.05m)
        {
            sapTaxCode = "5";
        }
        else
        {
            sapTaxCode = null;
        }

        return sapTaxCode;
    }
}