using System;
using System.Collections.Generic;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class SyncProductCategoryToSapBLL 
    {
        public virtual bool SyncProductCategoryToSap(ProductCategoryModel model, out string errorMessage)
        {
            errorMessage = "";
            string emailContent = "";
            try
            {
                SyncProcutCategoryToSapEntity entity = new SyncProcutCategoryToSapEntity();
                List < ProductCategoryModel > list = new List<ProductCategoryModel>();
                list.Add(model);
                entity.ProductCategoryList = list;

                entity.Validate();
                SapStructureService<SyncProcutCategoryToSapEntity>.GetSAPRFCEntity(entity);

                if (entity.returnType.ToUpper() == "S")
                {
                    return true;
                }
                else
                {
                    errorMessage = entity.returnMessage;
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
