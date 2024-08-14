using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class CreateCustomerModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "KTOKD","BUKRS","VKORG","VTWEG","KUNNR","NAME1","LOCATION","COUNC","REGION","CITY","KUKLA","BZIRK","VKBUR","VKGRP","VWERK","NXNAME1","TELF1","STKZA","STCEG","BANKN","KOINH","TLFNS","INTAD","NAMEV","SPART","STREET","POST_COD1","KLABC","AKONT","ZTERM","WAERS","BANKS","COUNTRY","LANGU","ABTNR","KALKS","TEL_NUMBER","LPRIO","KTGRD","TAXKD","VSBED","ANTLF","KONDA","PLTYP","VERSG","INCO1","INCO2","TITLE","MOB_NUMBER","FAX_NUMBER","SORT1","SORT2","BRSCH","BRAN1","RPMKR","NIELS","EMAIL","KDGRP","ALTKN","HOUSE_NO","CITY1","AGREL","UMSA1","UWAER"};
        }

        [DataMember]
        //客户帐户组 
        public string Ktokd
        {
            get
            {
                return base.GetProperty<string>("KTOKD");
            }
            set
            {
                base.SetProperty("KTOKD", value);
            }
        }

        [DataMember]
        //公司代码
        public string Bukrs
        {
            get
            {
                return base.GetProperty<string>("BUKRS");
            }
            set
            {
                base.SetProperty("BUKRS", value);
            }
        }

        [DataMember]
        //销售组织 
        public string Vkorg
        {
            get
            {
                return base.GetProperty<string>("VKORG");
            }
            set
            {
                base.SetProperty("VKORG", value);
            }
        }

        [DataMember]
        //分销渠道
        public string Vtweg
        {
            get
            {
                return base.GetProperty<string>("VTWEG");
            }
            set
            {
                base.SetProperty("VTWEG", value);
            }
        }

        [DataMember]
        //客户编号1
        public string Kunnr
        {
            get
            {
                return base.GetProperty<string>("KUNNR");
            }
            set
            {
                base.SetProperty("KUNNR", value);
            }
        }

        [DataMember]
        //名称
        public string Name1
        {
            get
            {
                return base.GetProperty<string>("NAME1");
            }
            set
            {
                base.SetProperty("NAME1", value);
            }
        }

        [DataMember]
        //街道 5
        public string Location
        {
            get
            {
                return base.GetProperty<string>("LOCATION");
            }
            set
            {
                base.SetProperty("LOCATION", value);
            }
        }

        [DataMember]
        //县代码编号
        public string Counc
        {
            get
            {
                return base.GetProperty<string>("COUNC");
            }
            set
            {
                base.SetProperty("COUNC", value);
            }
        }

        [DataMember]
        //地区 (州、省、县)编号
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
        //城市编号
        public string City
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
        //客户分类
        public string Kukla
        {
            get
            {
                return base.GetProperty<string>("KUKLA");
            }
            set
            {
                base.SetProperty("KUKLA", value);
            }
        }

        [DataMember]
        //销售地区 
        public string Bzirk
        {
            get
            {
                return base.GetProperty<string>("BZIRK");
            }
            set
            {
                base.SetProperty("BZIRK", value);
            }
        }

        [DataMember]
        //销售部门 
        public string Vkbur
        {
            get
            {
                return base.GetProperty<string>("VKBUR");
            }
            set
            {
                base.SetProperty("VKBUR", value);
            }
        }

        [DataMember]
        //销售组
        public string Vkgrp
        {
            get
            {
                return base.GetProperty<string>("VKGRP");
            }
            set
            {
                base.SetProperty("VKGRP", value);
            }
        }

        [DataMember]
        //交货工厂 (自有或外部)
        public string Vwerk
        {
            get
            {
                return base.GetProperty<string>("VWERK");
            }
            set
            {
                base.SetProperty("VWERK", value);
            }
        }

        [DataMember]
        //名称 1
        public string Nxname1
        {
            get
            {
                return base.GetProperty<string>("NXNAME1");
            }
            set
            {
                base.SetProperty("NXNAME1", value);
            }
        }

        [DataMember]
        //第一个电话号
        public string Telf1
        {
            get
            {
                return base.GetProperty<string>("TELF1");
            }
            set
            {
                base.SetProperty("TELF1", value);
            }
        }

        [DataMember]
        //平衡税（普票）
        public string Stkza
        {
            get
            {
                return base.GetProperty<string>("STKZA");
            }
            set
            {
                base.SetProperty("STKZA", value);
            }
        }

        [DataMember]
        //增值税登记号 
        public string Stceg
        {
            get
            {
                return base.GetProperty<string>("STCEG");
            }
            set
            {
                base.SetProperty("STCEG", value);
            }
        }

        [DataMember]
        //增票银行帐户号码
        public string Bankn
        {
            get
            {
                return base.GetProperty<string>("BANKN");
            }
            set
            {
                base.SetProperty("BANKN", value);
            }
        }

        [DataMember]
        //增票帐户持有人姓名 
        public string Koinh
        {
            get
            {
                return base.GetProperty<string>("KOINH");
            }
            set
            {
                base.SetProperty("KOINH", value);
            }
        }

        [DataMember]
        //增票电话
        public string Tlfns
        {
            get
            {
                return base.GetProperty<string>("TLFNS");
            }
            set
            {
                base.SetProperty("TLFNS", value);
            }
        }

        [DataMember]
        //增票地址
        public string Intad
        {
            get
            {
                return base.GetProperty<string>("INTAD");
            }
            set
            {
                base.SetProperty("INTAD", value);
            }
        }

        [DataMember]
        //名 
        public string Namev
        {
            get
            {
                return base.GetProperty<string>("NAMEV");
            }
            set
            {
                base.SetProperty("NAMEV", value);
            }
        }

        [DataMember]
        //产品组 
        public string Spart
        {
            get
            {
                return base.GetProperty<string>("SPART");
            }
            set
            {
                base.SetProperty("SPART", value);
            }
        }

        [DataMember]
        //街道
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
        //城市邮政编码
        public string PostCod1
        {
            get
            {
                return base.GetProperty<string>("POST_COD1");
            }
            set
            {
                base.SetProperty("POST_COD1", value);
            }
        }

        [DataMember]
        //客户分类( ABC 分析)
        public string Klabc
        {
            get
            {
                return base.GetProperty<string>("KLABC");
            }
            set
            {
                base.SetProperty("KLABC", value);
            }
        }

        [DataMember]
        //总帐中的统驭科目
        public string Akont
        {
            get
            {
                return base.GetProperty<string>("AKONT");
            }
            set
            {
                base.SetProperty("AKONT", value);
            }
        }

        [DataMember]
        //付款条件代码
        public string Zterm
        {
            get
            {
                return base.GetProperty<string>("ZTERM");
            }
            set
            {
                base.SetProperty("ZTERM", value);
            }
        }

        [DataMember]
        //货币码 
        public string Waers
        {
            get
            {
                return base.GetProperty<string>("WAERS");
            }
            set
            {
                base.SetProperty("WAERS", value);
            }
        }

        [DataMember]
        //银行国家代码
        public string Banks
        {
            get
            {
                return base.GetProperty<string>("BANKS");
            }
            set
            {
                base.SetProperty("BANKS", value);
            }
        }

        [DataMember]
        //国家代码
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
        //语言代码
        public string Langu
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
        //部门编号
        public string Abtnr
        {
            get
            {
                return base.GetProperty<string>("ABTNR");
            }
            set
            {
                base.SetProperty("ABTNR", value);
            }
        }

        [DataMember]
        //定价过程分配到该客户
        public string Kalks
        {
            get
            {
                return base.GetProperty<string>("KALKS");
            }
            set
            {
                base.SetProperty("KALKS", value);
            }
        }

        [DataMember]
        //第一个电话号码: 拨号 + 编号
        public string TelNumber
        {
            get
            {
                return base.GetProperty<string>("TEL_NUMBER");
            }
            set
            {
                base.SetProperty("TEL_NUMBER", value);
            }
        }

        [DataMember]
        //交货优先权 
        public decimal Lprio
        {
            get
            {
                return base.GetProperty<decimal>("LPRIO");
            }
            set
            {
                base.SetProperty("LPRIO", value);
            }
        }

        [DataMember]
        //客户组的帐户分配
        public string Ktgrd
        {
            get
            {
                return base.GetProperty<string>("KTGRD");
            }
            set
            {
                base.SetProperty("KTGRD", value);
            }
        }

        [DataMember]
        //客户税分类 
        public string Taxkd
        {
            get
            {
                return base.GetProperty<string>("TAXKD");
            }
            set
            {
                base.SetProperty("TAXKD", value);
            }
        }

        [DataMember]
        //装运条件
        public string Vsbed
        {
            get
            {
                return base.GetProperty<string>("VSBED");
            }
            set
            {
                base.SetProperty("VSBED", value);
            }
        }

        [DataMember]
        //每个项目允许的部分交货最大数
        public decimal Antlf
        {
            get
            {
                return base.GetProperty<decimal>("ANTLF");
            }
            set
            {
                base.SetProperty("ANTLF", value);
            }
        }

        [DataMember]
        //价格组(客户)
        public string Konda
        {
            get
            {
                return base.GetProperty<string>("KONDA");
            }
            set
            {
                base.SetProperty("KONDA", value);
            }
        }

        [DataMember]
        //价格清单类型
        public string Pltyp
        {
            get
            {
                return base.GetProperty<string>("PLTYP");
            }
            set
            {
                base.SetProperty("PLTYP", value);
            }
        }

        [DataMember]
        //客户统计组 
        public string Versg
        {
            get
            {
                return base.GetProperty<string>("VERSG");
            }
            set
            {
                base.SetProperty("VERSG", value);
            }
        }

        [DataMember]
        //国际贸易条款 (部分1)
        public string Inco1
        {
            get
            {
                return base.GetProperty<string>("INCO1");
            }
            set
            {
                base.SetProperty("INCO1", value);
            }
        }

        [DataMember]
        //国际贸易条件(部分2)
        public string Inco2
        {
            get
            {
                return base.GetProperty<string>("INCO2");
            }
            set
            {
                base.SetProperty("INCO2", value);
            }
        }

        [DataMember]
        //地址关键字的表格
        public string Title
        {
            get
            {
                return base.GetProperty<string>("TITLE");
            }
            set
            {
                base.SetProperty("TITLE", value);
            }
        }

        [DataMember]
        //第一个移动电话号码：区号 + 电话号码
        public string MobNumber
        {
            get
            {
                return base.GetProperty<string>("MOB_NUMBER");
            }
            set
            {
                base.SetProperty("MOB_NUMBER", value);
            }
        }

        [DataMember]
        //第一个传真号: 拨号 + 编号
        public string FaxNumber
        {
            get
            {
                return base.GetProperty<string>("FAX_NUMBER");
            }
            set
            {
                base.SetProperty("FAX_NUMBER", value);
            }
        }

        [DataMember]
        //检索项1
        public string Sort1
        {
            get
            {
                return base.GetProperty<string>("SORT1");
            }
            set
            {
                base.SetProperty("SORT1", value);
            }
        }

        [DataMember]
        //检索项2
        public string Sort2
        {
            get
            {
                return base.GetProperty<string>("SORT2");
            }
            set
            {
                base.SetProperty("SORT2", value);
            }
        }

        [DataMember]
        //第二级分类，行业代码
        public string Brsch
        {
            get
            {
                return base.GetProperty<string>("BRSCH");
            }
            set
            {
                base.SetProperty("BRSCH", value);
            }
        }

        [DataMember]
        //第三级分类，行业代码1
        public string Bran1
        {
            get
            {
                return base.GetProperty<string>("BRAN1");
            }
            set
            {
                base.SetProperty("BRAN1", value);
            }
        }

        [DataMember]
        //地区市场
        public string Rpmkr
        {
            get
            {
                return base.GetProperty<string>("RPMKR");
            }
            set
            {
                base.SetProperty("RPMKR", value);
            }
        }

        [DataMember]
        //Nielsen 标识（尼尔森指示符)
        public string Niels
        {
            get
            {
                return base.GetProperty<string>("NIELS");
            }
            set
            {
                base.SetProperty("NIELS", value);
            }
        }

        [DataMember]
        //Nielsen 标识（尼尔森指示符)
        public string Email
        {
            get
            {
                return base.GetProperty<string>("EMAIL");
            }
            set
            {
                base.SetProperty("EMAIL", value);
            }
        }

        [DataMember]
        //Nielsen 标识（客户组)
        public string Kdgrp
        {
            get
            {
                return base.GetProperty<string>("KDGRP");
            }
            set
            {
                base.SetProperty("KDGRP", value);
            }
        }
        //DRP客户编号
        public string Altkn
        {
            get
            {
                return base.GetProperty<string>("ALTKN");
            }
            set
            {
                base.SetProperty("ALTKN", value);
            }
        }
        //门牌号
        public string HouseNO
        {
            get
            {
                return base.GetProperty<string>("HOUSE_NO");
            }
            set
            {
                base.SetProperty("HOUSE_NO", value);
            }
        }
        //城市
        public string City1
        {
            get
            {
                return base.GetProperty<string>("CITY1");
            }
            set
            {
                base.SetProperty("CITY1", value);
            }
        }
        //是否代理
        public string Agrel
        {
            get
            {
                return base.GetProperty<string>("AGREL");
            }
            set
            {
                base.SetProperty("AGREL", value);
            }
        }
        //毛利比
        public string Umsa1
        {
            get
            {
                return base.GetProperty<string>("UMSA1");
            }
            set
            {
                base.SetProperty("UMSA1", value);
            }
        }
        //毛利比货币
        public string Uwaer
        {
            get
            {
                return base.GetProperty<string>("UWAER");
            }
            set
            {
                base.SetProperty("UWAER", value);
            }
        }


    }
}


