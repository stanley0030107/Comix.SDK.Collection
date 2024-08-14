using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.QueryCustomerBalance
{
    /// <summary>
    /// 创建客户返回结果
    /// </summary>
    public class QueryCustomerBalanceResponseBody
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 消息类型S-成功；E-失败
        /// </summary>
        public string MSGTY { get; set; }
        /// <summary>
        /// 消息的具体信息文本
        /// </summary>
        public string MSGTX { get; set; }
        /// <summary>
        /// 结果表
        /// </summary>
        public List<ETFBL5NItem> ET_FBL5N { get; set; }
       
    }

    /// <summary>
    /// 明细
    /// </summary>
    public class ETFBL5NItem
    {
        /// <summary>
        /// 公司代码
        /// </summary>
        public string COMP_CODE { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CUSTOMER { get; set; }
        /// <summary>
        /// 特殊总帐标识
        /// </summary>
        public string SP_GL_IND { get; set; }
        /// <summary>
        /// 清帐日期
        /// </summary>
        public string CLEAR_DATE { get; set; }
        /// <summary>
        /// 清算单据的单据号码
        /// </summary>
        public string CLR_DOC_NO { get; set; }
        /// <summary>
        /// 分配编号
        /// </summary>
        public string ALLOC_NMBR { get; set; }
        /// <summary>
        /// 会计年度
        /// </summary>
        public int FISC_YEAR { get; set; }
        /// <summary>
        /// 会计凭证编号
        /// </summary>
        public string DOC_NO { get; set; }
        /// <summary>
        /// 会计凭证中的行项目数
        /// </summary>
        public int ITEM_NUM { get; set; }
        /// <summary>
        /// 凭证中的过帐日期
        /// </summary>
        public string PSTNG_DATE { get; set; }
        /// <summary>
        /// 凭证中的凭证日期
        /// </summary>
        public string DOC_DATE { get; set; }
        /// <summary>
        /// 会计凭证录入日期
        /// </summary>
        public string ENTRY_DATE { get; set; }
        /// <summary>
        /// 货币码 
        /// </summary>
        public string CURRENCY { get; set; }
        /// <summary>
        ///  本币
        /// </summary>
        public string LOC_CURRCY { get; set; }
        /// <summary>
        /// 参考凭证编号
        /// </summary>
        public string REF_DOC_NO { get; set; }
        /// <summary>
        /// 凭证类型
        /// </summary>
        public string DOC_TYPE { get; set; }
        /// <summary>
        /// 会计期间
        /// </summary>
        public int FIS_PERIOD { get; set; }
        /// <summary>
        /// 记帐代码
        /// </summary>
        public string POST_KEY { get; set; }
        /// <summary>
        /// 借方/贷方标识
        /// </summary>
        public string DB_CR_IND { get; set; }
        /// <summary>
        /// 业务范围
        /// </summary>
        public string BUS_AREA { get; set; }
        /// <summary>
        /// 销售/购买税代码 
        /// </summary>
        public string TAX_CODE { get; set; }
        /// <summary>
        /// 按本币计的金额 
        /// </summary>
        public decimal LC_AMOUNT { get; set; }
        /// <summary>
        /// 凭证货币金额
        /// </summary>
        public decimal AMT_DOCCUR { get; set; }
        /// <summary>
        /// 用本币计的税收金额 
        /// </summary>
        public decimal LC_TAX { get; set; }
        /// <summary>
        /// 用凭证货币表示的税收金额
        /// </summary>
        public decimal TX_DOC_CUR { get; set; }
        /// <summary>
        /// 项目文本
        /// </summary>
        public string ITEM_TEXT { get; set; }
        /// <summary>
        /// 分支帐号
        /// </summary>
        public string BRANCH { get; set; }
        /// <summary>
        /// 用于到期日计算的基准日期
        /// </summary>
        public string BLINE_DATE { get; set; }
        /// <summary>
        /// 付款条件代码
        /// </summary>
        public string PMNTTRMS { get; set; }
        /// <summary>
        /// 现金折扣天数 1
        /// </summary>
        public decimal DSCT_DAYS1 { get; set; }
        /// <summary>
        /// 现金折扣天数 2
        /// </summary>
        public decimal DSCT_DAYS2 { get; set; }
        /// <summary>
        /// 净支付条件期段
        /// </summary>
        public decimal NETTERMS { get; set; }
        /// <summary>
        /// 现金折扣百分率1
        /// </summary>
        public decimal DSCT_PCT1 { get; set; }
        /// <summary>
        /// 现金折扣百分比2
        /// </summary>
        public decimal DSCT_PCT2 { get; set; }
        /// <summary>
        /// 可使用的凭证货币的现金折扣金额 
        /// </summary>
        public decimal DISC_BASE { get; set; }
        /// <summary>
        /// 本币的现金折扣金额 
        /// </summary>
        public decimal DSC_AMT_LC { get; set; }
        /// <summary>
        /// 以凭证货币表示的现金折扣金额
        /// </summary>
        public decimal DSC_AMT_DC { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string PYMT_METH { get; set; }
        /// <summary>
        /// 收付冻结码 
        /// </summary>
        public string PMNT_BLOCK { get; set; }
        /// <summary>
        /// 固定付款条件
        /// </summary>
        public string FIXEDTERMS { get; set; }
        /// <summary>
        /// 业务所属的发票号码
        /// </summary>
        public string INV_REF { get; set; }
        /// <summary>
        /// 有关发票的财政年度 (贷项凭单)
        /// </summary>
        public int INV_YEAR { get; set; }
        /// <summary>
        /// 相关发票中的行项目 
        /// </summary>
        public int INV_ITEM { get; set; }
        /// <summary>
        /// 催款冻结
        /// </summary>
        public string DUNN_BLOCK { get; set; }
        /// <summary>
        /// 催款代码
        /// </summary>
        public string DUNN_KEY { get; set; }
        /// <summary>
        /// 上次催款通知日期
        /// </summary>
        public string LAST_DUNN { get; set; }
        /// <summary>
        /// 催款级别
        /// </summary>
        public int DUNN_LEVEL { get; set; }
        /// <summary>
        /// 催款范围
        /// </summary>
        public string DUNN_AREA { get; set; }
        /// <summary>
        /// 凭证状态 
        /// </summary>
        public string DOC_STATUS { get; set; }
        /// <summary>
        /// 下列凭证类型
        /// </summary>
        public string NXT_DOCTYP { get; set; }
        /// <summary>
        /// 增值税登记号 
        /// </summary>
        public string VAT_REG_NO { get; set; }
        /// <summary>
        /// 付款原因代码
        /// </summary>
        public string REASON_CDE { get; set; }
        /// <summary>
        /// 付款方式补充
        /// </summary>
        public string PMTMTHSUPL { get; set; }
        /// <summary>
        /// 业务伙伴参考码
        /// </summary>
        public string REF_KEY_1 { get; set; }
        /// <summary>
        /// 业务伙伴参考码
        /// </summary>
        public string REF_KEY_2 { get; set; }
        /// <summary>
        /// 更新总分类帐交易数字货币
        /// </summary>
        public string T_CURRENCY { get; set; }
        /// <summary>
        /// 总帐中更新的金额
        /// </summary>
        public decimal AMOUNT { get; set; }
        /// <summary>
        /// 净收付金额
        /// </summary>
        public decimal NET_AMOUNT { get; set; }
        /// <summary>
        /// 名称 1
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 名称 2
        /// </summary>
        public string NAME_2 { get; set; }
        /// <summary>
        /// 名称 3
        /// </summary>
        public string NAME_3 { get; set; }
        /// <summary>
        /// 名称 4
        /// </summary>
        public string NAME_4 { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string POSTL_CODE { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string CITY { get; set; }
        /// <summary>
        /// 国家/地区代码
        /// </summary>
        public string COUNTRY { get; set; }
        /// <summary>
        /// 住宅号及街道
        /// </summary>
        public string STREET { get; set; }
        /// <summary>
        /// 邮政信箱
        /// </summary>
        public string PO_BOX { get; set; }
        /// <summary>
        /// 邮箱的邮编 
        /// </summary>
        public string POBX_PCD { get; set; }
        /// <summary>
        /// 邮政银行的往来帐户号
        /// </summary>
        public string POBK_CURAC { get; set; }
        /// <summary>
        /// 银行帐户号码
        /// </summary>
        public string BANK_ACCT { get; set; }
        /// <summary>
        /// 银行代码
        /// </summary>
        public string BANK_KEY { get; set; }
        /// <summary>
        /// 银行国家代码
        /// </summary>
        public string BANK_CTRY { get; set; }
        /// <summary>
        /// 税号 1
        /// </summary>
        public string TAX_NO_1 { get; set; }
        /// <summary>
        /// 税号 2
        /// </summary>
        public string TAX_NO_2 { get; set; }
        /// <summary>
        /// 增值税义务
        /// </summary>
        public string TAX { get; set; }
        /// <summary>
        /// 标识: 业务合作伙伴属于平衡税?
        /// </summary>
        public string EQUAL_TAX { get; set; }
        /// <summary>
        /// 地区（省/自治区/直辖市、市、县）
        /// </summary>
        public string REGION { get; set; }
        /// <summary>
        /// 银行控制代码
        /// </summary>
        public string CTRL_KEY { get; set; }
        /// <summary>
        /// 数据媒介交换指令码 
        /// </summary>
        public string INSTR_KEY { get; set; }
        /// <summary>
        /// 收款人代码 
        /// </summary>
        public string PAYEE_CODE { get; set; }
        /// <summary>
        /// 语言代码
        /// </summary>
        public string LANGU { get; set; }
        /// <summary>
        /// 汇票的有效期
        /// </summary>
        public decimal BILL_LIFE { get; set; }
        /// <summary>
        /// 汇票税码
        /// </summary>
        public string BE_TAXCODE { get; set; }
        /// <summary>
        /// 本币计的汇票税 
        /// </summary>
        public decimal BILLTAX_LC { get; set; }
        /// <summary>
        /// 外币计的汇票税 
        /// </summary>
        public decimal BILLTAX_FC { get; set; }
        /// <summary>
        /// 汇票托收的费用 (本币计)
        /// </summary>
        public decimal LC_COL_CHG { get; set; }
        /// <summary>
        /// 以凭证货币计的托收汇票的费用
        /// </summary>
        public decimal COLL_CHARG { get; set; }
        /// <summary>
        /// 汇票费用的税码 
        /// </summary>
        public string CHGS_TX_CD { get; set; }
        /// <summary>
        /// 汇票签发日 
        /// </summary>
        public string ISSUE_DATE { get; set; }
        /// <summary>
        /// 汇票使用日期
        /// </summary>
        public string USAGEDATE { get; set; }
        /// <summary>
        /// 汇票的计划用途 
        /// </summary>
        public string BILL_USAGE { get; set; }
        /// <summary>
        /// 可以支付汇票的银行地址(国内)
        /// </summary>
        public string DOMICILE { get; set; }
        /// <summary>
        /// 汇票出票人的名字
        /// </summary>
        public string DRAWER { get; set; }
        /// <summary>
        /// 国家中央银行所在地
        /// </summary>
        public string CTRBNK_LOC { get; set; }
        /// <summary>
        /// 汇票出票人的城市
        /// </summary>
        public string DRAW_CITY1 { get; set; }
        /// <summary>
        /// 汇票付款人 
        /// </summary>
        public string DRAWEE { get; set; }
        /// <summary>
        /// 汇票受票人的城市
        /// </summary>
        public string DRAW_CITY2 { get; set; }
        /// <summary>
        /// 贴现天数
        /// </summary>
        public decimal DISCT_DAYS { get; set; }
        /// <summary>
        /// 经过收费的汇票折扣百分率
        /// </summary>
        public decimal DISCT_RATE { get; set; }
        /// <summary>
        /// 标志：汇票已接收
        /// </summary>
        public string ACCEPTED { get; set; }
        /// <summary>
        /// 汇票状态 
        /// </summary>
        public string BILLSTATUS { get; set; }
        /// <summary>
        /// 拒付汇票标志
        /// </summary>
        public string PRTEST_IND { get; set; }
        /// <summary>
        /// 标记：即期汇票 
        /// </summary>
        public string BE_DEMAND { get; set; }
        /// <summary>
        /// 参考交易 
        /// </summary>
        public string OBJ_TYPE { get; set; }
        /// <summary>
        /// 参考凭证编号 
        /// </summary>
        public string REF_DOC { get; set; }
        /// <summary>
        /// 参考组织单位 
        /// </summary>
        public string REF_ORG_UN { get; set; }
        /// <summary>
        /// 冲销凭证号 
        /// </summary>
        public string REVERSAL_DOC { get; set; }
        /// <summary>
        /// 特殊总分类帐事务类型
        /// </summary>
        public string SP_GL_TYPE { get; set; }
        /// <summary>
        /// 标识: 反记帐 
        /// </summary>
        public string NEG_POSTNG { get; set; }
        /// <summary>
        /// 净价到期日
        /// </summary>
        public string FAEDT { get; set; }
        /// <summary>
        /// 净到期日后的逾期天数
        /// </summary>
        public string VERZN { get; set; }
    }
   

}
