using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class GetFBL5NReturnModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "COMP_CODE","CUSTOMER","SP_GL_IND","CLEAR_DATE","CLR_DOC_NO","ALLOC_NMBR","FISC_YEAR","DOC_NO","ITEM_NUM","PSTNG_DATE","DOC_DATE","ENTRY_DATE","CURRENCY","LOC_CURRCY","REF_DOC_NO","DOC_TYPE","FIS_PERIOD","POST_KEY","DB_CR_IND","BUS_AREA","TAX_CODE","LC_AMOUNT","AMT_DOCCUR","LC_TAX","TX_DOC_CUR","ITEM_TEXT","BRANCH","BLINE_DATE","PMNTTRMS","DSCT_DAYS1","DSCT_DAYS2","NETTERMS","DSCT_PCT1","DSCT_PCT2","DISC_BASE","DSC_AMT_LC","DSC_AMT_DC","PYMT_METH","PMNT_BLOCK","FIXEDTERMS","INV_REF","INV_YEAR","INV_ITEM","DUNN_BLOCK","DUNN_KEY","LAST_DUNN","DUNN_LEVEL","DUNN_AREA","DOC_STATUS","NXT_DOCTYP","VAT_REG_NO","REASON_CDE","PMTMTHSUPL","REF_KEY_1","REF_KEY_2","T_CURRENCY","AMOUNT","NET_AMOUNT","NAME","NAME_2","NAME_3","NAME_4","POSTL_CODE","CITY","COUNTRY","STREET","PO_BOX","POBX_PCD","POBK_CURAC","BANK_ACCT","BANK_KEY","BANK_CTRY","TAX_NO_1","TAX_NO_2","TAX","EQUAL_TAX","REGION","CTRL_KEY","INSTR_KEY","PAYEE_CODE","LANGU","BILL_LIFE","BE_TAXCODE","BILLTAX_LC","BILLTAX_FC","LC_COL_CHG","COLL_CHARG","CHGS_TX_CD","ISSUE_DATE","USAGEDATE","BILL_USAGE","DOMICILE","DRAWER","CTRBNK_LOC","DRAW_CITY1","DRAWEE","DRAW_CITY2","DISCT_DAYS","DISCT_RATE","ACCEPTED","BILLSTATUS","PRTEST_IND","BE_DEMAND","OBJ_TYPE","REF_DOC","REF_ORG_UN","REVERSAL_DOC","SP_GL_TYPE","NEG_POSTNG","FAEDT","VERZN"};
        }

        [DataMember]
        //公司代码
        public string Companycode
        {
            get
            {
                return base.GetProperty<string>("COMP_CODE");
            }
            set
            {
                base.SetProperty("COMP_CODE", value);
            }
        }

        [DataMember]
        //客户编号
        public string Customercode
        {
            get
            {
                return base.GetProperty<string>("CUSTOMER");
            }
            set
            {
                base.SetProperty("CUSTOMER", value);
            }
        }

        [DataMember]
        //特殊总帐标识
        public string Spglind
        {
            get
            {
                return base.GetProperty<string>("SP_GL_IND");
            }
            set
            {
                base.SetProperty("SP_GL_IND", value);
            }
        }

        [DataMember]
        //清帐日期
        public string Cleardate
        {
            get
            {
                return base.GetProperty<string>("CLEAR_DATE");
            }
            set
            {
                base.SetProperty("CLEAR_DATE", value);
            }
        }

        [DataMember]
        //清算单据的单据号码 
        public string Cleardocno
        {
            get
            {
                return base.GetProperty<string>("CLR_DOC_NO");
            }
            set
            {
                base.SetProperty("CLR_DOC_NO", value);
            }
        }

        [DataMember]
        //分配编号
        public string Allocnumber
        {
            get
            {
                return base.GetProperty<string>("ALLOC_NMBR");
            }
            set
            {
                base.SetProperty("ALLOC_NMBR", value);
            }
        }

        [DataMember]
        //会计年度
        public decimal Fiscyear
        {
            get
            {
                return base.GetProperty<decimal>("FISC_YEAR");
            }
            set
            {
                base.SetProperty("FISC_YEAR", value);
            }
        }

        [DataMember]
        //会计凭证编号
        public string Docno
        {
            get
            {
                return base.GetProperty<string>("DOC_NO");
            }
            set
            {
                base.SetProperty("DOC_NO", value);
            }
        }

        [DataMember]
        //会计凭证中的行项目数
        public decimal Itemnum
        {
            get
            {
                return base.GetProperty<decimal>("ITEM_NUM");
            }
            set
            {
                base.SetProperty("ITEM_NUM", value);
            }
        }

        [DataMember]
        //凭证中的过帐日期
        public string Pstngdate
        {
            get
            {
                return base.GetProperty<string>("PSTNG_DATE");
            }
            set
            {
                base.SetProperty("PSTNG_DATE", value);
            }
        }

        [DataMember]
        //凭证中的凭证日期
        public string Docdate
        {
            get
            {
                return base.GetProperty<string>("DOC_DATE");
            }
            set
            {
                base.SetProperty("DOC_DATE", value);
            }
        }

        [DataMember]
        //会计凭证录入日期
        public string Entrydate
        {
            get
            {
                return base.GetProperty<string>("ENTRY_DATE");
            }
            set
            {
                base.SetProperty("ENTRY_DATE", value);
            }
        }

        [DataMember]
        //货币码 
        public string Currency
        {
            get
            {
                return base.GetProperty<string>("CURRENCY");
            }
            set
            {
                base.SetProperty("CURRENCY", value);
            }
        }

        [DataMember]
        //本币
        public string Loccurrency
        {
            get
            {
                return base.GetProperty<string>("LOC_CURRCY");
            }
            set
            {
                base.SetProperty("LOC_CURRCY", value);
            }
        }

        [DataMember]
        //参考凭证编号 
        public string Refdocno
        {
            get
            {
                return base.GetProperty<string>("REF_DOC_NO");
            }
            set
            {
                base.SetProperty("REF_DOC_NO", value);
            }
        }

        [DataMember]
        //凭证类型
        public string Doctype
        {
            get
            {
                return base.GetProperty<string>("DOC_TYPE");
            }
            set
            {
                base.SetProperty("DOC_TYPE", value);
            }
        }

        [DataMember]
        //会计期间
        public decimal Fistype
        {
            get
            {
                return base.GetProperty<decimal>("FIS_PERIOD");
            }
            set
            {
                base.SetProperty("FIS_PERIOD", value);
            }
        }

        [DataMember]
        //记帐代码
        public string Postkey
        {
            get
            {
                return base.GetProperty<string>("POST_KEY");
            }
            set
            {
                base.SetProperty("POST_KEY", value);
            }
        }

        [DataMember]
        //借方/贷方标识
        public string Dbcrind
        {
            get
            {
                return base.GetProperty<string>("DB_CR_IND");
            }
            set
            {
                base.SetProperty("DB_CR_IND", value);
            }
        }

        [DataMember]
        //业务范围
        public string Busarea
        {
            get
            {
                return base.GetProperty<string>("BUS_AREA");
            }
            set
            {
                base.SetProperty("BUS_AREA", value);
            }
        }

        [DataMember]
        //销售/购买税代码 
        public string Taxcode
        {
            get
            {
                return base.GetProperty<string>("TAX_CODE");
            }
            set
            {
                base.SetProperty("TAX_CODE", value);
            }
        }

        [DataMember]
        //按本币计的金额 
        public decimal Lcamount
        {
            get
            {
                return base.GetProperty<decimal>("LC_AMOUNT");
            }
            set
            {
                base.SetProperty("LC_AMOUNT", value);
            }
        }

        [DataMember]
        //凭证货币金额
        public decimal Amountdoccur
        {
            get
            {
                return base.GetProperty<decimal>("AMT_DOCCUR");
            }
            set
            {
                base.SetProperty("AMT_DOCCUR", value);
            }
        }

        [DataMember]
        //用本币计的税收金额 
        public decimal Lctax
        {
            get
            {
                return base.GetProperty<decimal>("LC_TAX");
            }
            set
            {
                base.SetProperty("LC_TAX", value);
            }
        }

        [DataMember]
        //用凭证货币表示的税收金额
        public decimal Txdoccur
        {
            get
            {
                return base.GetProperty<decimal>("TX_DOC_CUR");
            }
            set
            {
                base.SetProperty("TX_DOC_CUR", value);
            }
        }

        [DataMember]
        //项目文本
        public string Itemtext
        {
            get
            {
                return base.GetProperty<string>("ITEM_TEXT");
            }
            set
            {
                base.SetProperty("ITEM_TEXT", value);
            }
        }

        [DataMember]
        //分支帐号
        public string Branch
        {
            get
            {
                return base.GetProperty<string>("BRANCH");
            }
            set
            {
                base.SetProperty("BRANCH", value);
            }
        }

        [DataMember]
        //用于到期日计算的基准日期
        public string Blinedate
        {
            get
            {
                return base.GetProperty<string>("BLINE_DATE");
            }
            set
            {
                base.SetProperty("BLINE_DATE", value);
            }
        }

        [DataMember]
        //付款条件代码
        public string Paymentcode
        {
            get
            {
                return base.GetProperty<string>("PMNTTRMS");
            }
            set
            {
                base.SetProperty("PMNTTRMS", value);
            }
        }

        [DataMember]
        //现金折扣天数 1
        public decimal Discountdays1
        {
            get
            {
                return base.GetProperty<decimal>("DSCT_DAYS1");
            }
            set
            {
                base.SetProperty("DSCT_DAYS1", value);
            }
        }

        [DataMember]
        //现金折扣天数 2
        public decimal Discountdays2
        {
            get
            {
                return base.GetProperty<decimal>("DSCT_DAYS2");
            }
            set
            {
                base.SetProperty("DSCT_DAYS2", value);
            }
        }

        [DataMember]
        //净支付条件期段
        public decimal Netterms
        {
            get
            {
                return base.GetProperty<decimal>("NETTERMS");
            }
            set
            {
                base.SetProperty("NETTERMS", value);
            }
        }

        [DataMember]
        //现金折扣百分率1
        public decimal Dsctpct1
        {
            get
            {
                return base.GetProperty<decimal>("DSCT_PCT1");
            }
            set
            {
                base.SetProperty("DSCT_PCT1", value);
            }
        }

        [DataMember]
        //现金折扣百分比2
        public decimal Dsctpct2
        {
            get
            {
                return base.GetProperty<decimal>("DSCT_PCT2");
            }
            set
            {
                base.SetProperty("DSCT_PCT2", value);
            }
        }

        [DataMember]
        //可使用的凭证货币的现金折扣金额 
        public decimal Discbase
        {
            get
            {
                return base.GetProperty<decimal>("DISC_BASE");
            }
            set
            {
                base.SetProperty("DISC_BASE", value);
            }
        }

        [DataMember]
        //本币的现金折扣金额 
        public decimal Discountamountlc
        {
            get
            {
                return base.GetProperty<decimal>("DSC_AMT_LC");
            }
            set
            {
                base.SetProperty("DSC_AMT_LC", value);
            }
        }

        [DataMember]
        //以凭证货币表示的现金折扣金额
        public decimal Discountamountdc
        {
            get
            {
                return base.GetProperty<decimal>("DSC_AMT_DC");
            }
            set
            {
                base.SetProperty("DSC_AMT_DC", value);
            }
        }

        [DataMember]
        //付款方式
        public string Paymenttype
        {
            get
            {
                return base.GetProperty<string>("PYMT_METH");
            }
            set
            {
                base.SetProperty("PYMT_METH", value);
            }
        }

        [DataMember]
        //收付冻结码 
        public string Paymentblock
        {
            get
            {
                return base.GetProperty<string>("PMNT_BLOCK");
            }
            set
            {
                base.SetProperty("PMNT_BLOCK", value);
            }
        }

        [DataMember]
        //固定付款条件
        public string Fixedterms
        {
            get
            {
                return base.GetProperty<string>("FIXEDTERMS");
            }
            set
            {
                base.SetProperty("FIXEDTERMS", value);
            }
        }

        [DataMember]
        //业务所属的发票号码
        public string Invoiceref
        {
            get
            {
                return base.GetProperty<string>("INV_REF");
            }
            set
            {
                base.SetProperty("INV_REF", value);
            }
        }

        [DataMember]
        //有关发票的财政年度 (贷项凭单)
        public decimal Invoiceyear
        {
            get
            {
                return base.GetProperty<decimal>("INV_YEAR");
            }
            set
            {
                base.SetProperty("INV_YEAR", value);
            }
        }

        [DataMember]
        //相关发票中的行项目 
        public decimal Invoiceitem
        {
            get
            {
                return base.GetProperty<decimal>("INV_ITEM");
            }
            set
            {
                base.SetProperty("INV_ITEM", value);
            }
        }

        [DataMember]
        //催款冻结
        public string Dunnblock
        {
            get
            {
                return base.GetProperty<string>("DUNN_BLOCK");
            }
            set
            {
                base.SetProperty("DUNN_BLOCK", value);
            }
        }

        [DataMember]
        //催款代码
        public string Dunnkey
        {
            get
            {
                return base.GetProperty<string>("DUNN_KEY");
            }
            set
            {
                base.SetProperty("DUNN_KEY", value);
            }
        }

        [DataMember]
        //上次催款通知日期
        public string Lastdunn
        {
            get
            {
                return base.GetProperty<string>("LAST_DUNN");
            }
            set
            {
                base.SetProperty("LAST_DUNN", value);
            }
        }

        [DataMember]
        //催款级别
        public decimal Dunnlevel
        {
            get
            {
                return base.GetProperty<decimal>("DUNN_LEVEL");
            }
            set
            {
                base.SetProperty("DUNN_LEVEL", value);
            }
        }

        [DataMember]
        //催款范围
        public string Dunnarea
        {
            get
            {
                return base.GetProperty<string>("DUNN_AREA");
            }
            set
            {
                base.SetProperty("DUNN_AREA", value);
            }
        }

        [DataMember]
        //凭证状态 
        public string Docstatus
        {
            get
            {
                return base.GetProperty<string>("DOC_STATUS");
            }
            set
            {
                base.SetProperty("DOC_STATUS", value);
            }
        }

        [DataMember]
        //下列凭证类型
        public string Netdoctype
        {
            get
            {
                return base.GetProperty<string>("NXT_DOCTYP");
            }
            set
            {
                base.SetProperty("NXT_DOCTYP", value);
            }
        }

        [DataMember]
        //增值税登记号 
        public string Vatregno
        {
            get
            {
                return base.GetProperty<string>("VAT_REG_NO");
            }
            set
            {
                base.SetProperty("VAT_REG_NO", value);
            }
        }

        [DataMember]
        //付款原因代码
        public string Reasoncode
        {
            get
            {
                return base.GetProperty<string>("REASON_CDE");
            }
            set
            {
                base.SetProperty("REASON_CDE", value);
            }
        }

        [DataMember]
        //付款方式补充
        public string Paymentsupl
        {
            get
            {
                return base.GetProperty<string>("PMTMTHSUPL");
            }
            set
            {
                base.SetProperty("PMTMTHSUPL", value);
            }
        }

        [DataMember]
        //业务伙伴参考码
        public string Refkey1
        {
            get
            {
                return base.GetProperty<string>("REF_KEY_1");
            }
            set
            {
                base.SetProperty("REF_KEY_1", value);
            }
        }

        [DataMember]
        //业务伙伴参考码
        public string Refkey2
        {
            get
            {
                return base.GetProperty<string>("REF_KEY_2");
            }
            set
            {
                base.SetProperty("REF_KEY_2", value);
            }
        }

        [DataMember]
        //更新总分类帐交易数字货币
        public string Tcurrency
        {
            get
            {
                return base.GetProperty<string>("T_CURRENCY");
            }
            set
            {
                base.SetProperty("T_CURRENCY", value);
            }
        }

        [DataMember]
        //总帐中更新的金额
        public decimal Amount
        {
            get
            {
                return base.GetProperty<decimal>("AMOUNT");
            }
            set
            {
                base.SetProperty("AMOUNT", value);
            }
        }

        [DataMember]
        //净收付金额
        public decimal Netamount
        {
            get
            {
                return base.GetProperty<decimal>("NET_AMOUNT");
            }
            set
            {
                base.SetProperty("NET_AMOUNT", value);
            }
        }

        [DataMember]
        //名称 1
        public string Name
        {
            get
            {
                return base.GetProperty<string>("NAME");
            }
            set
            {
                base.SetProperty("NAME", value);
            }
        }

        [DataMember]
        //名称 2
        public string Name2
        {
            get
            {
                return base.GetProperty<string>("NAME_2");
            }
            set
            {
                base.SetProperty("NAME_2", value);
            }
        }

        [DataMember]
        //名称 3
        public string Name3
        {
            get
            {
                return base.GetProperty<string>("NAME_3");
            }
            set
            {
                base.SetProperty("NAME_3", value);
            }
        }

        [DataMember]
        //名称 4
        public string Name4
        {
            get
            {
                return base.GetProperty<string>("NAME_4");
            }
            set
            {
                base.SetProperty("NAME_4", value);
            }
        }

        [DataMember]
        //邮政编码
        public string Postcode
        {
            get
            {
                return base.GetProperty<string>("POSTL_CODE");
            }
            set
            {
                base.SetProperty("POSTL_CODE", value);
            }
        }

        [DataMember]
        //城市
        public string Citycode
        {
            get
            {
                return base.GetProperty<string>("CITY");
            }
            set
            {
                base.SetProperty("CITY", value);
            }
        }

        [DataMember]
        //国家/地区代码
        public string Country
        {
            get
            {
                return base.GetProperty<string>("COUNTRY");
            }
            set
            {
                base.SetProperty("COUNTRY", value);
            }
        }

        [DataMember]
        //住宅号及街道
        public string Street
        {
            get
            {
                return base.GetProperty<string>("STREET");
            }
            set
            {
                base.SetProperty("STREET", value);
            }
        }

        [DataMember]
        //邮政信箱
        public string Pobox
        {
            get
            {
                return base.GetProperty<string>("PO_BOX");
            }
            set
            {
                base.SetProperty("PO_BOX", value);
            }
        }

        [DataMember]
        //邮箱的邮编 
        public string Pobxpcd
        {
            get
            {
                return base.GetProperty<string>("POBX_PCD");
            }
            set
            {
                base.SetProperty("POBX_PCD", value);
            }
        }

        [DataMember]
        //邮政银行的往来帐户号
        public string Pobkcurac
        {
            get
            {
                return base.GetProperty<string>("POBK_CURAC");
            }
            set
            {
                base.SetProperty("POBK_CURAC", value);
            }
        }

        [DataMember]
        //银行帐户号码
        public string Bankaccount
        {
            get
            {
                return base.GetProperty<string>("BANK_ACCT");
            }
            set
            {
                base.SetProperty("BANK_ACCT", value);
            }
        }

        [DataMember]
        //银行代码
        public string Bankkey
        {
            get
            {
                return base.GetProperty<string>("BANK_KEY");
            }
            set
            {
                base.SetProperty("BANK_KEY", value);
            }
        }

        [DataMember]
        //银行国家代码
        public string Bankcountrycode
        {
            get
            {
                return base.GetProperty<string>("BANK_CTRY");
            }
            set
            {
                base.SetProperty("BANK_CTRY", value);
            }
        }

        [DataMember]
        //税号 1
        public string Taxno1
        {
            get
            {
                return base.GetProperty<string>("TAX_NO_1");
            }
            set
            {
                base.SetProperty("TAX_NO_1", value);
            }
        }

        [DataMember]
        //税号 2
        public string Taxno2
        {
            get
            {
                return base.GetProperty<string>("TAX_NO_2");
            }
            set
            {
                base.SetProperty("TAX_NO_2", value);
            }
        }

        [DataMember]
        //增值税义务
        public string Tax
        {
            get
            {
                return base.GetProperty<string>("TAX");
            }
            set
            {
                base.SetProperty("TAX", value);
            }
        }

        [DataMember]
        //标识: 业务合作伙伴属于平衡税?
        public string Equaltax
        {
            get
            {
                return base.GetProperty<string>("EQUAL_TAX");
            }
            set
            {
                base.SetProperty("EQUAL_TAX", value);
            }
        }

        [DataMember]
        //地区（省/自治区/直辖市、市、县） 
        public string Region
        {
            get
            {
                return base.GetProperty<string>("REGION");
            }
            set
            {
                base.SetProperty("REGION", value);
            }
        }

        [DataMember]
        //银行控制代码
        public string Ctrlkey
        {
            get
            {
                return base.GetProperty<string>("CTRL_KEY");
            }
            set
            {
                base.SetProperty("CTRL_KEY", value);
            }
        }

        [DataMember]
        //数据媒介交换指令码 
        public string Instrkey
        {
            get
            {
                return base.GetProperty<string>("INSTR_KEY");
            }
            set
            {
                base.SetProperty("INSTR_KEY", value);
            }
        }

        [DataMember]
        //收款人代码 
        public string Payercode
        {
            get
            {
                return base.GetProperty<string>("PAYEE_CODE");
            }
            set
            {
                base.SetProperty("PAYEE_CODE", value);
            }
        }

        [DataMember]
        //语言代码
        public string Lanuage
        {
            get
            {
                return base.GetProperty<string>("LANGU");
            }
            set
            {
                base.SetProperty("LANGU", value);
            }
        }

        [DataMember]
        //汇票的有效期
        public decimal Billvaliddate
        {
            get
            {
                return base.GetProperty<decimal>("BILL_LIFE");
            }
            set
            {
                base.SetProperty("BILL_LIFE", value);
            }
        }

        [DataMember]
        //汇票税码
        public string Betaxcode
        {
            get
            {
                return base.GetProperty<string>("BE_TAXCODE");
            }
            set
            {
                base.SetProperty("BE_TAXCODE", value);
            }
        }

        [DataMember]
        //本币计的汇票税 
        public decimal Billtaxlc
        {
            get
            {
                return base.GetProperty<decimal>("BILLTAX_LC");
            }
            set
            {
                base.SetProperty("BILLTAX_LC", value);
            }
        }

        [DataMember]
        //外币计的汇票税 
        public decimal Billtaxfc
        {
            get
            {
                return base.GetProperty<decimal>("BILLTAX_FC");
            }
            set
            {
                base.SetProperty("BILLTAX_FC", value);
            }
        }

        [DataMember]
        //汇票托收的费用 (本币计)
        public decimal Lccolchg
        {
            get
            {
                return base.GetProperty<decimal>("LC_COL_CHG");
            }
            set
            {
                base.SetProperty("LC_COL_CHG", value);
            }
        }

        [DataMember]
        //以凭证货币计的托收汇票的费用
        public decimal Collcharg
        {
            get
            {
                return base.GetProperty<decimal>("COLL_CHARG");
            }
            set
            {
                base.SetProperty("COLL_CHARG", value);
            }
        }

        [DataMember]
        //汇票费用的税码 
        public string Chgstxcd
        {
            get
            {
                return base.GetProperty<string>("CHGS_TX_CD");
            }
            set
            {
                base.SetProperty("CHGS_TX_CD", value);
            }
        }

        [DataMember]
        //汇票签发日 
        public string Issuedate
        {
            get
            {
                return base.GetProperty<string>("ISSUE_DATE");
            }
            set
            {
                base.SetProperty("ISSUE_DATE", value);
            }
        }

        [DataMember]
        //汇票使用日期
        public string Usagedate
        {
            get
            {
                return base.GetProperty<string>("USAGEDATE");
            }
            set
            {
                base.SetProperty("USAGEDATE", value);
            }
        }

        [DataMember]
        //汇票的计划用途 
        public string Billusage
        {
            get
            {
                return base.GetProperty<string>("BILL_USAGE");
            }
            set
            {
                base.SetProperty("BILL_USAGE", value);
            }
        }

        [DataMember]
        //可以支付汇票的银行地址(国内)
        public string Domicile
        {
            get
            {
                return base.GetProperty<string>("DOMICILE");
            }
            set
            {
                base.SetProperty("DOMICILE", value);
            }
        }

        [DataMember]
        //汇票出票人的名字
        public string Drawer
        {
            get
            {
                return base.GetProperty<string>("DRAWER");
            }
            set
            {
                base.SetProperty("DRAWER", value);
            }
        }

        [DataMember]
        //国家中央银行所在地
        public string Ctrbankloc
        {
            get
            {
                return base.GetProperty<string>("CTRBNK_LOC");
            }
            set
            {
                base.SetProperty("CTRBNK_LOC", value);
            }
        }

        [DataMember]
        //汇票出票人的城市
        public string Drawcity1
        {
            get
            {
                return base.GetProperty<string>("DRAW_CITY1");
            }
            set
            {
                base.SetProperty("DRAW_CITY1", value);
            }
        }

        [DataMember]
        //汇票付款人 
        public string Drawee
        {
            get
            {
                return base.GetProperty<string>("DRAWEE");
            }
            set
            {
                base.SetProperty("DRAWEE", value);
            }
        }

        [DataMember]
        //汇票受票人的城市
        public string Drawcity2
        {
            get
            {
                return base.GetProperty<string>("DRAW_CITY2");
            }
            set
            {
                base.SetProperty("DRAW_CITY2", value);
            }
        }

        [DataMember]
        //贴现天数
        public decimal Disctdays
        {
            get
            {
                return base.GetProperty<decimal>("DISCT_DAYS");
            }
            set
            {
                base.SetProperty("DISCT_DAYS", value);
            }
        }

        [DataMember]
        //经过收费的汇票折扣百分率
        public decimal Disctrate
        {
            get
            {
                return base.GetProperty<decimal>("DISCT_RATE");
            }
            set
            {
                base.SetProperty("DISCT_RATE", value);
            }
        }

        [DataMember]
        //标志：汇票已接收
        public string Accepted
        {
            get
            {
                return base.GetProperty<string>("ACCEPTED");
            }
            set
            {
                base.SetProperty("ACCEPTED", value);
            }
        }

        [DataMember]
        //汇票状态 
        public string Billstatus
        {
            get
            {
                return base.GetProperty<string>("BILLSTATUS");
            }
            set
            {
                base.SetProperty("BILLSTATUS", value);
            }
        }

        [DataMember]
        //拒付汇票标志
        public string Prtestind
        {
            get
            {
                return base.GetProperty<string>("PRTEST_IND");
            }
            set
            {
                base.SetProperty("PRTEST_IND", value);
            }
        }

        [DataMember]
        //标记：即期汇票 
        public string Bedemand
        {
            get
            {
                return base.GetProperty<string>("BE_DEMAND");
            }
            set
            {
                base.SetProperty("BE_DEMAND", value);
            }
        }

        [DataMember]
        //参考交易 
        public string Objtype
        {
            get
            {
                return base.GetProperty<string>("OBJ_TYPE");
            }
            set
            {
                base.SetProperty("OBJ_TYPE", value);
            }
        }

        [DataMember]
        //参考凭证编号 
        public string Refloc
        {
            get
            {
                return base.GetProperty<string>("REF_DOC");
            }
            set
            {
                base.SetProperty("REF_DOC", value);
            }
        }

        [DataMember]
        //参考组织单位 
        public string Reforgun
        {
            get
            {
                return base.GetProperty<string>("REF_ORG_UN");
            }
            set
            {
                base.SetProperty("REF_ORG_UN", value);
            }
        }

        [DataMember]
        //冲销凭证号 
        public string Reversalloc
        {
            get
            {
                return base.GetProperty<string>("REVERSAL_DOC");
            }
            set
            {
                base.SetProperty("REVERSAL_DOC", value);
            }
        }

        [DataMember]
        //特殊总分类帐事务类型
        public string Spgltype
        {
            get
            {
                return base.GetProperty<string>("SP_GL_TYPE");
            }
            set
            {
                base.SetProperty("SP_GL_TYPE", value);
            }
        }

        [DataMember]
        //标识: 反记帐 
        public string Negposting
        {
            get
            {
                return base.GetProperty<string>("NEG_POSTNG");
            }
            set
            {
                base.SetProperty("NEG_POSTNG", value);
            }
        }

        [DataMember]
        //净价到期日
        public string Faedt
        {
            get
            {
                return base.GetProperty<string>("FAEDT");
            }
            set
            {
                base.SetProperty("FAEDT", value);
            }
        }

        [DataMember]
        //净到期日后的逾期天数
        public decimal Verzn
        {
            get
            {
                return base.GetProperty<decimal>("VERZN");
            }
            set
            {
                base.SetProperty("VERZN", value);
            }
        }

    }
}


