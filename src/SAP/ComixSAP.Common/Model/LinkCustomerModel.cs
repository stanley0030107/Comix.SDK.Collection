using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class LinkCustomerModel
    {
        /// <summary>
        /// 客户帐户组
        /// </summary>
        private string _KTOKD = "";
        public string KTOKD
        {
            get { return _KTOKD; }
            set { _KTOKD = value; }
        }
        /// <summary>
        /// 公司代码
        /// </summary>
        private string _BUKRS = "";
        public string BUKRS
        {
            get { return _BUKRS; }
            set { _BUKRS = value; }
        }
        /// <summary>
        /// 销售组织
        /// </summary>
        private string _VKORG = "";
        public string VKORG
        {
            get { return _VKORG; }
            set { _VKORG = value; }
        }
        /// <summary>
        /// 分销渠道
        /// </summary>
        private string _VTWEG = "";
        public string VTWEG
        {
            get { return _VTWEG; }
            set { _VTWEG = value; }
        }
        /// <summary>
        /// 客户编号1
        /// </summary>
        private string _KUNNR = "";
        public string KUNNR
        {
            get { return _KUNNR; }
            set { _KUNNR = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        private string _NAME1 = "";
        public string NAME1
        {
            get { return _NAME1; }
            set { _NAME1 = value; }
        }
        /// <summary>
        /// 街道 5
        /// </summary>
        private string _LOCATION = "";
        public string LOCATION
        {
            get { return _LOCATION; }
            set { _LOCATION = value; }
        }
        /// <summary>
        /// 县代码编号
        /// </summary>
        private string _COUNC = "";
        public string COUNC
        {
            get { return _COUNC; }
            set { _COUNC = value; }
        }
        /// <summary>
        /// 地区 (州、省、县)编号
        /// </summary>
        private string _REGION = "";
        public string REGION
        {
            get { return _REGION; }
            set { _REGION = value; }
        }
        /// <summary>
        /// 城市编号
        /// </summary>
        private string _CITY = "";
        public string CITY
        {
            get { return _CITY; }
            set { _CITY = value; }
        }
        /// <summary>
        /// 客户分类
        /// </summary>
        private string _KUKLA = "";
        public string KUKLA
        {
            get { return _KUKLA; }
            set { _KUKLA = value; }
        }
        /// <summary>
        /// 销售地区
        /// </summary>
        private string _BZIRK = "";
        public string BZIRK
        {
            get { return _BZIRK; }
            set { _BZIRK = value; }
        }
        /// <summary>
        /// 销售部门
        /// </summary>
        private string _VKBUR = "";
        public string VKBUR
        {
            get { return _VKBUR; }
            set { _VKBUR = value; }
        }
        /// <summary>
        /// 销售组
        /// </summary>
        private string _VKGRP = "";
        public string VKGRP
        {
            get { return _VKGRP; }
            set { _VKGRP = value; }
        }
        /// <summary>
        /// 交货工厂 (自有或外部)
        /// </summary>
        private string _VWERK = "";
        public string VWERK
        {
            get { return _VWERK; }
            set { _VWERK = value; }
        }
        /// <summary>
        /// 名称 1
        /// </summary>
        private string _NXNAME1 = "";
        public string NXNAME1
        {
            get { return _NXNAME1; }
            set { _NXNAME1 = value; }
        }
        /// <summary>
        /// 第一个电话号
        /// </summary>
        private string _TELF1 = "";
        public string TELF1
        {
            get { return _TELF1; }
            set { _TELF1 = value; }
        }
        /// <summary>
        /// 平衡税（普票）
        /// </summary>
        private string _STKZA = "";
        public string STKZA
        {
            get { return _STKZA; }
            set { _STKZA = value; }
        }
        /// <summary>
        /// 增值税登记号
        /// </summary>
        private string _STCEG = "";
        public string STCEG
        {
            get { return _STCEG; }
            set { _STCEG = value; }
        }
        /// <summary>
        /// 增票银行帐户号码
        /// </summary>
        private string _BANKN = "";
        public string BANKN
        {
            get { return _BANKN; }
            set { _BANKN = value; }
        }
        /// <summary>
        /// 增票帐户持有人姓名
        /// </summary>
        private string _KOINH = "";
        public string KOINH
        {
            get { return _KOINH; }
            set { _KOINH = value; }
        }
        /// <summary>
        /// 增票电话
        /// </summary>
        private string _TLFNS = "";
        public string TLFNS
        {
            get { return _TLFNS; }
            set { _TLFNS = value; }
        }
        /// <summary>
        /// 增票地址
        /// </summary>
        private string _INTAD = "";
        public string INTAD
        {
            get { return _INTAD; }
            set { _INTAD = value; }
        }
        /// <summary>
        /// 名
        /// </summary>
        private string _NAMEV = "";
        public string NAMEV
        {
            get { return _NAMEV; }
            set { _NAMEV = value; }
        }
        /// <summary>
        /// 产品组
        /// </summary>
        private string _SPART = "";
        public string SPART
        {
            get { return _SPART; }
            set { _SPART = value; }
        }
        /// <summary>
        /// 街道
        /// </summary>
        private string _STREET = "";
        public string STREET
        {
            get { return _STREET; }
            set { _STREET = value; }
        }
        /// <summary>
        /// 城市邮政编码
        /// </summary>
        private string _POST_COD1 = "";
        public string POST_COD1
        {
            get { return _POST_COD1; }
            set { _POST_COD1 = value; }
        }
        /// <summary>
        /// 客户分类( ABC 分析)
        /// </summary>
        private string _KLABC = "";
        public string KLABC
        {
            get { return _KLABC; }
            set { _KLABC = value; }
        }
        /// <summary>
        /// 总帐中的统驭科目
        /// </summary>
        private string _AKONT = "";
        public string AKONT
        {
            get { return _AKONT; }
            set { _AKONT = value; }
        }
        /// <summary>
        /// 付款条件代码
        /// </summary>
        private string _ZTERM = "";
        public string ZTERM
        {
            get { return _ZTERM; }
            set { _ZTERM = value; }
        }
        /// <summary>
        /// 货币码
        /// </summary>
        private string _WAERS = "";
        public string WAERS
        {
            get { return _WAERS; }
            set { _WAERS = value; }
        }
        /// <summary>
        /// 银行国家代码
        /// </summary>
        private string _BANKS = "";
        public string BANKS
        {
            get { return _BANKS; }
            set { _BANKS = value; }
        }
        /// <summary>
        /// 国家代码
        /// </summary>
        private string _COUNTRY = "";
        public string COUNTRY
        {
            get { return _COUNTRY; }
            set { _COUNTRY = value; }
        }
        /// <summary>
        /// 语言代码
        /// </summary>
        private string _LANGU = "";
        public string LANGU
        {
            get { return _LANGU; }
            set { _LANGU = value; }
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        private string _ABTNR = "";
        public string ABTNR
        {
            get { return _ABTNR; }
            set { _ABTNR = value; }
        }
        /// <summary>
        /// 定价过程分配到该客户
        /// </summary>
        private string _KALKS = "";
        public string KALKS
        {
            get { return _KALKS; }
            set { _KALKS = value; }
        }
        /// <summary>
        /// 第一个电话号码: 拨号 + 编号
        /// </summary>
        private string _TEL_NUMBER = "";
        public string TEL_NUMBER
        {
            get { return _TEL_NUMBER; }
            set { _TEL_NUMBER = value; }
        }
        /// <summary>
        /// 交货优先权
        /// </summary>
        private decimal _LPRIO = 0;
        public decimal LPRIO
        {
            get { return _LPRIO; }
            set { _LPRIO = value; }
        }
        /// <summary>
        /// 客户组的帐户分配
        /// </summary>
        private string _KTGRD = "";
        public string KTGRD
        {
            get { return _KTGRD; }
            set { _KTGRD = value; }
        }
        /// <summary>
        /// 客户税分类
        /// </summary>
        private string _TAXKD = "";
        public string TAXKD
        {
            get { return _TAXKD; }
            set { _TAXKD = value; }
        }
        /// <summary>
        /// 装运条件
        /// </summary>
        private string _VSBED = "";
        public string VSBED
        {
            get { return _VSBED; }
            set { _VSBED = value; }
        }
        /// <summary>
        /// 每个项目允许的部分交货最大数
        /// </summary>
        private decimal _ANTLF = 0;
        public decimal ANTLF
        {
            get { return _ANTLF; }
            set { _ANTLF = value; }
        }
        /// <summary>
        /// 价格组(客户)
        /// </summary>
        private string _KONDA = "";
        public string KONDA
        {
            get { return _KONDA; }
            set { _KONDA = value; }
        }
        /// <summary>
        /// 价格清单类型
        /// </summary>
        private string _PLTYP = "";
        public string PLTYP
        {
            get { return _PLTYP; }
            set { _PLTYP = value; }
        }
        /// <summary>
        /// 客户统计组
        /// </summary>
        private string _VERSG = "";
        public string VERSG
        {
            get { return _VERSG; }
            set { _VERSG = value; }
        }
        /// <summary>
        /// 国际贸易条款 (部分1)
        /// </summary>
        private string _INCO1 = "";
        public string INCO1
        {
            get { return _INCO1; }
            set { _INCO1 = value; }
        }
        /// <summary>
        /// 国际贸易条件(部分2)
        /// </summary>
        private string _INCO2 = "";
        public string INCO2
        {
            get { return _INCO2; }
            set { _INCO2 = value; }
        }
        /// <summary>
        /// 地址关键字的表格
        /// </summary>
        private string _TITLE = "";
        public string TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        /// <summary>
        /// 第一个移动电话号码：区号 + 电话号码
        /// </summary>
        private string _MOB_NUMBER = "";
        public string MOB_NUMBER
        {
            get { return _MOB_NUMBER; }
            set { _MOB_NUMBER = value; }
        }
        /// <summary>
        /// 第一个传真号: 拨号 + 编号
        /// </summary>
        private string _FAX_NUMBER = "";
        public string FAX_NUMBER
        {
            get { return _FAX_NUMBER; }
            set { _FAX_NUMBER = value; }
        }
        /// <summary>
        /// 检索项1
        /// </summary>
        private string _SORT1 = "";
        public string SORT1
        {
            get { return _SORT1; }
            set { _SORT1 = value; }
        }
        /// <summary>
        /// 检索项2
        /// </summary>
        private string _SORT2 = "";
        public string SORT2
        {
            get { return _SORT2; }
            set { _SORT2 = value; }
        }
        /// <summary>
        /// 第二级分类，行业代码
        /// </summary>
        private string _BRSCH = "";
        public string BRSCH
        {
            get { return _BRSCH; }
            set { _BRSCH = value; }
        }
        /// <summary>
        /// 第三级分类，行业代码1
        /// </summary>
        private string _BRAN1 = "";
        public string BRAN1
        {
            get { return _BRAN1; }
            set { _BRAN1 = value; }
        }
        /// <summary>
        /// 地区市场
        /// </summary>
        private string _RPMKR = "";
        public string RPMKR
        {
            get { return _RPMKR; }
            set { _RPMKR = value; }
        }
        /// <summary>
        /// Nielsen 标识（尼尔森指示符)
        /// </summary>
        private string _NIELS = "";
        public string NIELS
        {
            get { return _NIELS; }
            set { _NIELS = value; }
        }

        /// <summary>
        /// 邮件
        /// </summary>
        private string _EMAIL = "";
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }      
        /// <summary>
        /// 客户组
        /// </summary>
        private string _KDGRP = "";
        public string KDGRP
        {
            get { return _KDGRP; }
            set { _KDGRP = value; }
        }        
    }
}


