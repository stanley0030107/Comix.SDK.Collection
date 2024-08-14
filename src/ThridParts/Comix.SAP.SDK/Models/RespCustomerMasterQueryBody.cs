using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models
{
    /// <summary>
    /// 客户主数据信息
    /// </summary>
    public class RespCustomerMasterQueryBody
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public int KUNNR { get; set; }
        /// <summary>
        /// 国家/地区代码
        /// </summary>
        public string LAND1 { get; set; }
        /// <summary>
        /// 名称 1
        /// </summary>
        public string NAME1 { get; set; }

        //下面这些没用，注释了
        //public string BBBNR { get; set; }
        //public string BBSNR { get; set; }
        //public int BUBKZ { get; set; }
        //public int ERDAT { get; set; }
        //public string ERNAM { get; set; }
        //public string KONZS { get; set; }
        //public string KTOKD { get; set; }
        //public int KUKLA { get; set; }
        //public int COUNC { get; set; }
        //public int CITYC { get; set; }
        //public string STCEG { get; set; }
        //public int BRAN1 { get; set; }
        //public string UMSAT { get; set; }
        //public string UMJAH { get; set; }
        //public string JMZAH { get; set; }
        //public string UMSA1 { get; set; }
        //public string STCD5 { get; set; }
        //public string LOEVM { get; set; }
        //public string SORT1 { get; set; }
        //public string SORT2 { get; set; }
        //public string STREET { get; set; }
        //public string LOCATION { get; set; }
        //public int POST_CODE1 { get; set; }
        //public int REGION { get; set; }
        //public string NAMEV { get; set; }
        //public long TELF1 { get; set; }
        
        //public RespCustomerMasterQueryBody_SALES_DATA[] SALES_DATA { get; set; }
        //public RespCustomerMasterQueryBody_BUKRS_DATA[] BUKRS_DATA { get; set; }
        //public RespCustomerMasterQueryBody_BANK_DATA[] BANK_DATA { get; set; }
        //public RespCustomerMasterQueryBody_CONTACT_BP[] CONTACT_BP { get; set; }
    }
    /*
    public class RespCustomerMasterQueryBody_SALES_DATA
    {
        public int VKORG { get; set; }
        public int VTWEG { get; set; }
        public int SPART { get; set; }
        public int KDGRP { get; set; }
        public string BZIRK { get; set; }
        public int KALKS { get; set; }
        public string WAERS { get; set; }
        public string KTGRD { get; set; }
        public string ZTERM { get; set; }
        public int VWERK { get; set; }
        public string VKGRP { get; set; }
        public string VKBUR { get; set; }
        public RespCustomerMasterQueryBody_PARTNER_DATA[] PARTNER_DATA { get; set; }
        public string PLTYP { get; set; }
        public string KLABC { get; set; }
        public string KVGR3 { get; set; }
        public string KG3_BEZEI { get; set; }
    }

    public class RespCustomerMasterQueryBody_PARTNER_DATA
    {
        public string PARVW { get; set; }
        public int KUNN2 { get; set; }
        public string PERNR { get; set; }
        public string NAME1 { get; set; }
    }

    public class RespCustomerMasterQueryBody_BUKRS_DATA
    {
        public int BUKRS { get; set; }
        public int ZRSV03 { get; set; }
        public string ZRSV01 { get; set; }
        public string ZRSV02 { get; set; }
    }

    public class RespCustomerMasterQueryBody_BANK_DATA
    {
        public string BANKS { get; set; }
        public long BANKL { get; set; }
        public string BANKN { get; set; }
        public string KOINH { get; set; }
        public string BANKA { get; set; }
        public string BKVID { get; set; }
        public string BKONT { get; set; }
        public string BK_VALID_FROM { get; set; }
        public string BK_VALID_TO { get; set; }
    }

    public class RespCustomerMasterQueryBody_CONTACT_BP
    {
        public string NAME1 { get; set; }
        public string NAMEV { get; set; }
        public long TELF1 { get; set; }
        public string ABTNR { get; set; }
    }

    */
}
