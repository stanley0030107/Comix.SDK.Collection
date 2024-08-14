using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CreateSapVou
{
    //如果好用，请收藏地址，帮忙分享。
    public class SapVouItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string MSGID { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public int BUZEI { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        public string ZFLAG_C { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BSCHL { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string HKONT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string KUNNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string LIFNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string UMSKZ { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public decimal WRBTR { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public decimal DMBTR { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public decimal KURSR { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string ZLSCH { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string AUFNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZTERM { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string MWSKZ { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string SGTXT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZFBDT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string VALUT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZUONR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string XREF1 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string XREF2 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string XREF3 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string KOSTL { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string PRCTR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string XNEGP { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string RSTGR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string GSBER { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string SPART { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string VKORG { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string VTWEG { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string KNDNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string FWBAS { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string TXBHW { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string WW003 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string WERKS { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string KKBER { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string VBELN { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string VBUND { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZZHKONT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZZPOSID { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZZCHGTY { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZZINVES { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV01 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV02 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV03 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV04 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV05 { get; set; } = "";

        public string ZBANKST { get; set; } = "";
    }

    public class SapVouResquestBody
    {
        /// <summary>
        /// 
        /// </summary>
        public string MSGID { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZKUBUN { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZFLAG_C { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BLART { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BUKRS { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BELNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public int GJAHR { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public int MONAT { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string BLDAT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BUDAT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string WAERS { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public decimal KURSF { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string BKTXT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string XBLNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string USERNAME { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV01 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV02 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV03 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV04 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV05 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public List<SapVouItem> Items { get; set; }
    }


}
