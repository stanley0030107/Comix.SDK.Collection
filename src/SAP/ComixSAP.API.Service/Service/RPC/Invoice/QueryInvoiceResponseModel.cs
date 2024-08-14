using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.API.Service.RPC
{
    /// <summary>
    /// 查询发票
    /// </summary>
    public class QueryInvoiceResponseModel
    {
        /// <summary>
        ///主键
        /// </summary>
        public virtual string OID { get; set; }

        /// <summary>
        ///BELNR
        /// </summary>
        public virtual string BELNR { get; set; }

        /// <summary>
        ///记录的创建日期
        /// </summary>
        public virtual string ERDAT { get; set; }

        /// <summary>
        ///输入时间
        /// </summary>
        public virtual string ERZET { get; set; }

        /// <summary>
        ///公司代码
        /// </summary>
      
        public virtual string BUKRS { get; set; }

        /// <summary>
        ///公司代码或公司的名称
        /// </summary>
      
        public virtual string BUTXT { get; set; }

        /// <summary>
        ///分销渠道
        /// </summary>
        public virtual string VTWEG { get; set; }

        /// <summary>
        ///名称
        /// </summary>
        public virtual string VTEXT { get; set; }

        /// <summary>
        ///Billing Document  开票凭证号
        /// </summary>
        public virtual string VBELN { get; set; }

        /// <summary>
        ///开票类型
        /// </summary>
        public virtual string FKART { get; set; }

        /// <summary>
        ///客户编号
        /// </summary>
      
        public virtual string KUNNR { get; set; }

        /// <summary>
        ///名称
        /// </summary>
        public virtual string KUNNR_NAME { get; set; }

        /// <summary>
        ///增值税登记号
        /// </summary>
        public virtual string STCEG { get; set; }

        /// <summary>
        ///出具发票索引和打印的出具发票日期
        /// </summary>
        public virtual string FKDAT { get; set; }

        /// <summary>
        ///文本行
        /// </summary>
        public virtual string TDLINE { get; set; }

        /// <summary>
        ///银行名称
        /// </summary>
        public virtual string BANKA { get; set; }

        /// <summary>
        ///银行账户
        /// </summary>
        public virtual string BANKN { get; set; }

        /// <summary>
        ///帐户持有人姓名
        /// </summary>
        public virtual string KOINH { get; set; }

        /// <summary>
        ///交易伙伴公司员工的互联网地址
        /// </summary>
        public virtual string ADRESS { get; set; }

        /// <summary>
        ///第一个电话号码：区号 + 号码
        /// </summary>
        public virtual string TEL_NUMBER { get; set; }

        /// <summary>
        ///享受优惠政策内容
        /// </summary>
        public virtual string PRE_TEXT { get; set; }

        /// <summary>
        ///已取消的出具发票凭证编号
        /// </summary>
        public virtual string SFAKN { get; set; }

        /// <summary>
        ///FKSTO
        /// </summary>
        public virtual string FKSTO { get; set; }

        /// <summary>
        ///客户采购订单编号
        /// </summary>
        public virtual string BSTKD { get; set; }

        /// <summary>
        /// 搜索词2
        /// <summary>
        public virtual string SORT2 { get; set; }
        /// <summary>
        /// 中国信保买方代码
        /// <summary>
        public virtual string SORT3 { get; set; }
        /// <summary>
        /// 出运货币代码
        /// <summary>
        public virtual string WAERK { get; set; }
        /// <summary>
        /// 出运日期
        /// <summary>
        public virtual string CYDAT { get; set; }
        /// <summary>
        /// 投保日期
        /// <summary>
        public string TBDAT { get; set; }
        /// <summary>
        /// 业务员名称 
        /// <summary>
        public virtual string ERNAM { get; set; }
        /// <summary>
        /// 合同支付期限（天） 
        /// <summary>
        public virtual string ZTAG1 { get; set; }
        /// <summary>
        /// 合同支付方式
        /// <summary>
        public virtual string TEXT1 { get; set; }
        /// <summary>
        /// abc分类
        /// <summary>
        public virtual string KLABC { get; set; }
        /// <summary>
        /// 开票类型
        /// <summary>
        public virtual string FKARTT { get; set; }
        /// <summary>
        /// 净价
        /// <summary>
        public virtual string NETWR { get; set; }
        /// <summary>
        /// 税额
        /// <summary>
        public virtual string MWSBP { get; set; }
        /// <summary>
        /// 付款方
        /// <summary>
        public virtual string KUNRG { get; set; }
        /// <summary>
        /// 销售组织
        /// <summary>
        public virtual string VKORG { get; set; }
        /// <summary>
        /// 付款方名称
        /// <summary>
        public virtual string KUNRG_NAME { get; set; }
        /// <summary>
        /// 货币码
        /// <summary>
        public virtual string WAERS { get; set; }
        /// <summary>
        /// 收票方
        /// <summary>
        public virtual string KUNRE { get; set; }
        /// <summary>
        /// 收票方名称
        /// <summary>
        public virtual string KUNRE_NAME { get; set; }

        /// <summary>
        ///接收时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        ///0无需发送到大贲   1需要发送至大贲  2发送成功  3发送失败，需要重新发送
        /// </summary>
        public virtual int SendStatus { get; set; }

        /// <summary>
        ///同步次数
        /// </summary>
        public virtual int SyncNum { get; set; }

        /// <summary>
        ///最后同步时间
        /// </summary>
        public virtual DateTime? LastSyncTime { get; set; }

        /// <summary>
        ///备注，异常原因
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        ///通过系统票中的交货单号VGBEL，关联出对应的商城合约LINK订单
        /// </summary>
        public virtual string SourceBillno { get; set; }

        /// <summary>
        ///合约单号对应的合约集采项目编号
        /// </summary>
        public virtual string CustomerGroupCode { get; set; }

        /// <summary>
        ///合约单号对应的合约集采项目名称
        /// </summary>
        public virtual string CustomerGroupName { get; set; }

        /// <summary>
        ///关联源 se  or  do
        /// </summary>
        public virtual string RelSource { get; set; }

        #region  自定义内容
        /// <summary>
        /// 发票明细
        /// </summary>
        public virtual List<QueryInvoiceDetail> Details { get; set; }
        #endregion
    }
    public class QueryInvoiceDetail
    {
        public QueryInvoiceDetail()
        {
            SendStatus = 1;//需要同步，如果主表SRC_SAP_INVOICE_HEADER中状态为  不需要同步，此状态作废，无意义
        }
        /// <summary>
 		///主键
 		/// </summary>
        public virtual string OID { get; set; }

        /// <summary>
        ///Billing Document/开票凭证号
        /// </summary>
        public virtual string VBELN { get; set; }

        /// <summary>
        ///Billing item/开票凭证序号
        /// </summary>
        public virtual string POSNR { get; set; }

        /// <summary>
        ///参考单据的单据编号/SAP交货单号
        /// </summary>
        public virtual string VGBEL { get; set; }

        /// <summary>
        ///SAP交货单行号
        /// </summary>
        public virtual string VGPOS { get; set; }

        /// <summary>
        ///物料号
        /// </summary>
        public virtual string MATNR { get; set; }

        /// <summary>
        ///物料描述（短文本）
        /// </summary>
        public virtual string MAKTX { get; set; }

        /// <summary>
        ///以库存单位出具发票量/物料数量
        /// </summary>
        public virtual string FKLMG { get; set; }

        /// <summary>
        ///单价
        /// </summary>
        public virtual decimal? PRICE { get; set; }

        /// <summary>
        ///基本计量单位
        /// </summary>
        public virtual string MEINS { get; set; }

        /// <summary>
        ///旧物料号
        /// </summary>
        public virtual string BISMT { get; set; }

        /// <summary>
        ///税收分类编号
        /// </summary>
        public virtual string TAX_CLASSIFY { get; set; }

        /// <summary>
        ///产品层次
        /// </summary>
        public virtual string PRDHA { get; set; }

        /// <summary>
        ///描述
        /// </summary>
        public virtual string PRDHA_VTEXT { get; set; }

        /// <summary>
        ///工厂
        /// </summary>
        public virtual string WERKS { get; set; }

        /// <summary>
        ///标识: 业务合作伙伴属于平衡税?
        /// </summary>
        public virtual string STKZA { get; set; }

        /// <summary>
        ///凭证货币计量的净价值/税率
        /// </summary>
        public virtual decimal? TAXRATE { get; set; }

        /// <summary>
        ///零税率标识
        /// </summary>
        public virtual string PRE_FLAG { get; set; }

        /// <summary>
        ///凭证货币计量的净价值/SAP计算的原开票金额
        /// </summary>
        public virtual decimal? AMOUNT { get; set; }

        /// <summary>
        ///客户采购订单编号
        /// </summary>
        public virtual string BSTKD { get; set; }

        /// <summary>
        /// 度量单位文本
        /// <summary>
        public virtual string MSEHL { get; set; }
        /// <summary>
        /// 实际已开票数量
        /// <summary>
        public virtual string FKIMG { get; set; }
        /// <summary>
        /// 销售单位
        /// <summary>
        public virtual string VRKME { get; set; }
        /// <summary>
        /// 税率
        /// <summary>
        public virtual decimal? KURRF { get; set; }
        /// <summary>
        /// 成本价
        /// <summary>
        public virtual decimal? KBETR { get; set; }
        /// <summary>
        /// 净价
        /// <summary>
        public virtual decimal? NETWR { get; set; }
        /// <summary>
        /// 税额
        /// <summary>
        public virtual decimal? MWSBP { get; set; }

        /// <summary>
        ///重新按中移动未税计算的行金额
        /// </summary>
        public virtual decimal AdjustPrice { get; set; }

        /// <summary>
        ///重新计算时间
        /// </summary>
        public virtual DateTime? AdjustTime { get; set; }

        /// <summary>
        ///备注，异常原因
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        ///0无需发送到大贲   1需要发送至大贲  2发送成功  3发送失败，需要重新发送
        /// </summary>
        public virtual int SendStatus { get; set; }
        #region  自定义内容
        ///// <summary>
        ///// 含税总金额(SAP) 其实就是 AMOUNT
        ///// </summary>
        //public decimal TotalAmountIncludingTaxSap { get; set; }

        #endregion
    }
}
