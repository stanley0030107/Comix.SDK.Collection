using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComixSAP.Service;

namespace ComixSAP.Service
{
    public class SAPService
    {
        // private readonly static SrcFinAccountBLL finAccountService = new SrcFinAccountBLL();
        // public static SrcFinAccountBLL FinAccountService
        // {
        //     get
        //     {
        //         if (finAccountService == null)
        //         {
        //            
        //         }
        //         return finAccountService;
        //     }
        // }
        //
        // private readonly static B2CEnterpriseBLL b2cEnerprisetService = new B2CEnterpriseBLL();
        // public static B2CEnterpriseBLL B2CEnerprisetService
        // {
        //     get
        //     {
        //         if (b2cEnerprisetService == null)
        //         {
        //             
        //         }
        //         return b2cEnerprisetService;
        //     }
        // }

        private readonly static LinkCustomerBLL linkCustomerService = new LinkCustomerBLL();
        public static LinkCustomerBLL LinkCustomerService
        {
            get
            {
                if (linkCustomerService == null)
                {
                  
                }
                return linkCustomerService;
            }
        }

        private readonly static ManualInvoiceBLL linkInvoiceService = new ManualInvoiceBLL();
        public static ManualInvoiceBLL LinkInvoiceService
        {
            get
            {
                if (linkInvoiceService == null)
                {
                   
                }
                return linkInvoiceService;
            }
        }

        private readonly static CreateProductBLL createSapProductService = new CreateProductBLL();
        public static CreateProductBLL CreateSapProductService
        {
            get
            {
                if (createSapProductService == null)
                {
                  
                }
                return createSapProductService;
            }
        }

        private readonly static CreateSapSalesOrgBLL createSapSalesOrgService = new CreateSapSalesOrgBLL();
        public static CreateSapSalesOrgBLL CreateSapSalesOrgService
        {
            get
            {
                if (createSapSalesOrgService == null)
                {
                   
                }
                return createSapSalesOrgService;
            }
        }

        #region GetInvoiceInfo
        private readonly static GetInvoiceInfoBLL getInvoiceService = new GetInvoiceInfoBLL();
        public static GetInvoiceInfoBLL GetInvoiceService
        {
            get
            {
                if (getInvoiceService == null)
                {
                  
                }
                return getInvoiceService;
            }
        }
        #endregion

        #region GetInvoiceInfo
        private readonly static GetFBL5NInfoBLL getCustomerBalanceService = new GetFBL5NInfoBLL();
        public static GetFBL5NInfoBLL GetCustomerBalanceService
        {
            get
            {
                if (getCustomerBalanceService == null)
                {
                   
                }
                return getCustomerBalanceService;
            }
        }
        #endregion

        #region GetInvoiceInfo
        private readonly static CreateSapVoucherBLL createSapVoucherService = new CreateSapVoucherBLL();
        public static CreateSapVoucherBLL CreateSapVoucherService
        {
            get
            {
                if (createSapVoucherService == null)
                {
                   
                }
                return createSapVoucherService;
            }
        }
        #endregion

        #region SyncProductCategoryToSap
        private readonly static SyncProductCategoryToSapBLL syncProductCategoryToSapService = new SyncProductCategoryToSapBLL();
        public static SyncProductCategoryToSapBLL SyncProductCategoryToSapService
        {
            get
            {
                if (syncProductCategoryToSapService == null)
                {
                   
                }
                return syncProductCategoryToSapService;
            }
        }
        #endregion

    }
}
