using ComixSAP.Common.Entity;

namespace ComixSAP.Service
{
    public class ManualInvoiceBLL 
    {
        public virtual bool CreateManualInvoice(ZomsManualInvoiceEntity invoiceEntity, out string errorMessage)
        {
            errorMessage = "";

            invoiceEntity.Validate();
            SapStructureService<ZomsManualInvoiceEntity>.GetSAPRFCEntity(invoiceEntity);
            if (invoiceEntity.ReturnMessageList[0].Equals("S"))
            {
                return true;
            }
            else
            {
                errorMessage = invoiceEntity.ReturnMessageList[0].Message;
                //系统已存在该客户的编号，请去查看sap其他资料信息是否一致！0002011590
                return false;
            }
        }
    }
}