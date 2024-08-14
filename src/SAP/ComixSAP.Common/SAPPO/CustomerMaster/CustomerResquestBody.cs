using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CustomerMaster
{
    /// <summary>
    /// 银行数据
    /// </summary>
    public class BankDataItem
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string BANKS { get; set;} = "";
        /// <summary>
        /// 银行代码
        /// </summary>
        public string BANKL { get; set;} = "";
        /// <summary>
        /// 银行账户
        /// </summary>
        public string BANKN { get; set;} = "";
        /// <summary>
        /// 银行户主
        /// </summary>
        public string KOINH { get; set;} = "";
        /// <summary>
        /// 参考细节
        /// </summary>
        public string BKREF { get; set;} = "";
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BANKA { get; set;} = "";
        /// <summary>
        /// 地区
        /// </summary>
        public string PROVZ { get; set;} = "";
        /// <summary>
        /// 街道
        /// </summary>
        public string STRAS { get; set;} = "";
        /// <summary>
        /// 城市
        /// </summary>
        public string ORT01 { get; set;} = "";
        /// <summary>
        /// 分行
        /// </summary>
        public string BRNCH { get; set;} = "";
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string ZRSV01 { get; set;} = "";
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set;} = "";
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set;} = "";
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set;} = "";
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set;} = "";
   } 
    /// <summary>
    /// 客户主要联系伙伴
    /// </summary>
    public class ContactBPItem
    {
        /// <summary>
        /// 称谓
        /// </summary>
        public string ANRED { get; set;} = "";
        /// <summary>
        /// 名称
        /// </summary>
        public string NAME1 { get; set;} = "";
        /// <summary>
        /// 名
        /// </summary>
        public string NAMEV { get; set;} = "";
        /// <summary>
        /// 电话
        /// </summary>
        public string TELF1 { get; set;} = "";
        /// <summary>
        /// 部门
        /// </summary>
        public string ABTNR { get; set;} = "";
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string ZRSV01 { get; set;} = "";
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set;} = "";
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set;} = "";
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set;} = "";
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set;} = "";
   } 
    /// <summary>
    /// 公司代码数据
    /// </summary>
    public class BukrsDataItem
    {
        /// <summary>
        /// 公司代码
        /// </summary>
        public string BUKRS { get; set;} = "";
        /// <summary>
        /// 统驭科目
        /// </summary>
        public string AKONT { get; set;} = "";
        /// <summary>
        /// 付款条件
        /// </summary>
        public string ZTERM { get; set;} = "";
        /// <summary>
        /// 会计人员的电话
        /// </summary>
        public string TLFNS { get; set;} = "";
        /// <summary>
        /// 员工的互联网
        /// </summary>
        public string INTAD { get; set;} = "";
        /// <summary>
        /// 对公司代码过账冻结
        /// </summary>
        public string SPERR { get; set;} = "";
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string ZRSV01 { get; set;} = "";
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set;} = "";
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set;} = "";
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set;} = "";
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set;} = "";
   }
    /// <summary>
    /// 合作伙伴视图
    /// </summary>
    public class ParvwDataItem
    {
        /// <summary>
        /// 合作伙伴功能
        /// </summary>
        public string PARVW { get; set;} = "";
        /// <summary>
        /// 业务伙伴的客户号
        /// </summary>
        public string KUNN2 { get; set;} = "";
        /// <summary>
        /// 伙伴名称
        /// </summary>
        public string NAME1 { get; set;} = "";
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string ZRSV01 { get; set;} = "";
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set;} = "";
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set;} = "";
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set;} = "";
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set;} = "";
   } 

    /// <summary>
    /// 销售视图
    /// </summary>
    public class SalesDataItem
    {
        /// <summary>
        /// 销售组织
        /// </summary>
        public string VKORG { get; set;} = "";
        /// <summary>
        /// 分销渠道
        /// </summary>
        public string VTWEG { get; set;} = "";
        /// <summary>
        /// 产品组
        /// </summary>
        public string SPART { get; set;} = "";
        /// <summary>
        /// 销售地区
        /// </summary>
        public string BZIRK { get; set;} = "";
        /// <summary>
        /// 订单可能性
        /// </summary>
        public string AWAHR { get; set;} = "";
        /// <summary>
        /// 销售部门
        /// </summary>
        public string VKBUR { get; set;} = "";
        /// <summary>
        /// 权限组
        /// </summary>
        public string BEGRU { get; set;} = "";
        /// <summary>
        /// 销售组
        /// </summary>
        public string VKGRP { get; set;} = "";
        /// <summary>
        /// 客户组
        /// </summary>
        public string KDGRP { get; set;} = "";
        /// <summary>
        /// ABC等级
        /// </summary>
        public string KLABC { get; set;} = "";
        /// <summary>
        /// 货币
        /// </summary>
        public string WAERS { get; set;} = "";
        /// <summary>
        /// 客户定价过程 
        /// </summary>
        public string KALKS { get; set;} = "";
        /// <summary>
        /// 价格清单
        /// </summary>
        public string PLTYP { get; set;} = "";
        /// <summary>
        /// 交货优先权
        /// </summary>
        public string LPRIO { get; set;} = "";
        /// <summary>
        /// 装运条件
        /// </summary>
        public string VSBED { get; set;} = "";
        /// <summary>
        /// 交货工厂
        /// </summary>
        public string VWERK { get; set;} = "";
        /// <summary>
        /// 国际贸易条款1
        /// </summary>
        public string INCO1 { get; set;} = "";
        /// <summary>
        /// 国际贸易条款2
        /// </summary>
        public string INCO2 { get; set;} = "";
        /// <summary>
        /// 付款条件
        /// </summary>
        public string ZTERM { get; set;} = "";
        /// <summary>
        /// 贷方控制范围
        /// </summary>
        public string KKBER { get; set;} = "";
        /// <summary>
        /// 账户分配组
        /// </summary>
        public string KTGRD { get; set;} = "";
        /// <summary>
        /// 税分类
        /// </summary>
        public string TAXKD { get; set;} = "";
        /// <summary>
        /// 客户的删除标记 (销售级别)
        /// </summary>
        public string LOEVM { get; set;} = "";
        /// <summary>
        /// 客户订单冻结(销售范围)
        /// </summary>
        public string AUFSD { get; set;} = "";
        /// <summary>
        /// 客户交货冻结(销售范围)
        /// </summary>
        public string LIFSD { get; set;} = "";
        /// <summary>
        /// 冻结客户出具发票（销售和分销）
        /// </summary>
        public string FAKSD { get; set;} = "";
        /// <summary>
        /// 客户的销售冻结（销售范围）
        /// </summary>
        public string CASSD { get; set;} = "";
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string ZRSV01 { get; set;} = "";
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set;} = "";
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set;} = "";
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set;} = "";
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set;} = "";
        /// <summary>
        /// array-合作伙伴视图
        /// </summary>
        public List<ParvwDataItem> PARVW_DATA { get; set; } = new List<ParvwDataItem>(); 
   } 
    /// <summary>
    /// 创建客户请求主体
    /// </summary>
    public class CustomerResquestBody
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MSGID { get; set;} = "";
        /// <summary>
        /// 客户
        /// </summary>
        public string KUNNR{ get; set;} = "";

        /// <summary>
        /// 基础数据
        /// </summary>
        public BasicData BASIC_DATA { get; set; } 

        /// <summary>
        /// 银行数据array
        /// </summary>
        public List<BankDataItem> BANK_DATA { get; set; } = new List<BankDataItem>();
        /// <summary>
        /// 客户主要联系伙伴array
        /// </summary>
        public List<ContactBPItem> CONTACT_BP { get; set; } = new List<ContactBPItem>();
        /// <summary>
        /// 公司代码数据-array
        /// </summary>
        public List<BukrsDataItem> BUKRS_DATA { get; set; } = new List<BukrsDataItem>();
        /// <summary>
        /// array-销售视图
        /// </summary>
        public List<SalesDataItem> SALES_DATA { get; set; } = new List<SalesDataItem>();

    } 

    public class BasicData {
        /// <summary>
        /// 科目组
        /// </summary>
        public string KTOKD { get; set;} = ""; 
        /// <summary>
        /// 称谓
        /// </summary>
        public string ANRED { get; set;} = "";
        /// <summary>
        /// 名称
        /// </summary>
        public string NAME1 { get; set;} = "";
        /// <summary>
        /// 名称2
        /// </summary>
        public string NAME2 { get; set;} = "";
        /// <summary>
        /// 搜索项1
        /// </summary>
        public string SORT1 { get; set;} = "";
        /// <summary>
        /// 搜索项2
        /// </summary>
        public string SORT2 { get; set;} = "";
        /// <summary>
        /// 街道
        /// </summary>
        public string STREET { get; set;} = "";
        /// <summary>
        /// 门牌号
        /// </summary>
        public string HOUSE_NUM1 { get; set;} = "";
        /// <summary>
        /// 街道5
        /// </summary>
        public string LOCATION { get; set;} = "";
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string POST_CODE1 { get; set;} = "";
        /// <summary>
        /// 城市
        /// </summary>
        public string CITY1 { get; set;} = "";
        /// <summary>
        /// 国家
        /// </summary>
        public string COUNTRY { get; set;} = "";
        /// <summary>
        /// 地区
        /// </summary>
        public string REGION { get; set;} = "";
        /// <summary>
        /// 邮政信箱
        /// </summary>
        public string PO_BOX { get; set;} = "";
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string POST_CODE2 { get; set;} = "";
        /// <summary>
        /// 公司邮政编码
        /// </summary>
        public string POST_CODE3 { get; set;} = "";
        /// <summary>
        /// 语言
        /// </summary>
        public string LANGU { get; set;} = "";
        /// <summary>
        /// 电话
        /// </summary>
        public string TEL_NUMBER { get; set;} = "";
        /// <summary>
        /// 移动电话
        /// </summary>
        public string TELF2 { get; set;} = "";
        /// <summary>
        /// 传真
        /// </summary>
        public string FAX_NUMBER { get; set;} = "";
        /// <summary>
        /// E-mail
        /// </summary>
        public string SMTP_ADDR { get; set;} = "";
        /// <summary>
        /// 注释
        /// </summary>
        public string REMARK { get; set;} = "";
        /// <summary>
        /// 供应商
        /// </summary>
        public string LIFNR { get; set;} = "";
        /// <summary>
        /// 权限组
        /// </summary>
        public string BEGRU { get; set;} = "";
        /// <summary>
        /// 贸易伙伴
        /// </summary>
        public string VBUND { get; set;} = "";
        /// <summary>
        /// 组代码
        /// </summary>
        public string KONZS { get; set;} = "";
        /// <summary>
        /// 国际区委代码1
        /// </summary>
        public string BBBNR { get; set;} = "";
        /// <summary>
        /// 国际区委代码2
        /// </summary>
        public string BBSNR { get; set;} = "";
        /// <summary>
        /// 校验位
        /// </summary>
        public string BUBKZ { get; set;} = "";
        /// <summary>
        /// 列车站
        /// </summary>
        public string BAHNS { get; set;} = "";
        /// <summary>
        /// 快运车站
        /// </summary>
        public string BAHNE { get; set;} = "";
        /// <summary>
        /// 运输区域
        /// </summary>
        public string LZONE { get; set;} = "";
        /// <summary>
        /// 位置代码
        /// </summary>
        public string LOCCO { get; set;} = "";
        /// <summary>
        /// 税号1
        /// </summary>
        public string STCD1 { get; set;} = "";
        /// <summary>
        /// 税号2
        /// </summary>
        public string STCD2 { get; set;} = "";
        /// <summary>
        /// □平衡税
        /// </summary>
        public string STKZA { get; set;} = "";
        /// <summary>
        /// □自然人
        /// </summary>
        public string STKZN { get; set;} = "";
        /// <summary>
        /// □销售/购买税
        /// </summary>
        public string STKZU { get; set;} = "";
        /// <summary>
        /// 财务地址
        /// </summary>
        public string FISKN { get; set;} = "";
        /// <summary>
        /// 县代码
        /// </summary>
        public string COUNC { get; set;} = "";
        /// <summary>
        /// 城市代码
        /// </summary>
        public string CITYC { get; set;} = "";
        /// <summary>
        /// 增值税登记号
        /// </summary>
        public string STCEG { get; set;} = "";
        /// <summary>
        /// 尼尔森指令符
        /// </summary>
        public string NIELS { get; set;} = "";
        /// <summary>
        /// 地区市场
        /// </summary>
        public string RPMKR { get; set;} = "";
        /// <summary>
        /// 客户分类
        /// </summary>
        public string KUKLA { get; set;} = "";
        /// <summary>
        /// 层次分配
        /// </summary>
        public string HZUOR { get; set;} = "";
        /// <summary>
        /// 行业
        /// </summary>
        public string BRSCH { get; set;} = "";
        /// <summary>
        /// 行业代码1
        /// </summary>
        public string BRAN1 { get; set;} = "";
        /// <summary>
        /// 年销售额
        /// </summary>
        public int UMSA1 { get; set;} = 0;
        /// <summary>
        /// 员工
        /// </summary>
        public string JMZAH { get; set;} = "";
        /// <summary>
        /// 会计年度变式
        /// </summary>
        public string PERIV { get; set;} = "";
        /// <summary>
        /// 记录创建日期
        /// </summary>
        public string ERDAT { get; set;} = "";
        /// <summary>
        /// 创建对象的人员名称 
        /// </summary>
        public string ERNAM { get; set;} = "";
        /// <summary>
        /// 客户的中央销售冻结 
        /// </summary>
        public string CASSD { get; set;} = "";
        /// <summary>
        /// 主记录的中心删除冻结
        /// </summary>
        public string NODEL { get; set;} = "";
        /// <summary>
        /// 客户主要订单块 
        /// </summary>
        public string AUFSD { get; set;} = "";
        /// <summary>
        /// 客户集中出具发票块 
        /// </summary>
        public string FAKSD { get; set;} = "";
        /// <summary>
        /// 客户主要交货块 
        /// </summary>
        public string LIFSD { get; set;} = "";
        /// <summary>
        /// 主记录的集中删除标志
        /// </summary>
        public string LOEVM { get; set;} = "";
        /// <summary>
        /// 中心记账冻结
        /// </summary>
        public string SPERR { get; set;} = "";
        /// <summary>
        /// 集中冻结
        /// </summary>
        public string XBLCK { get; set;} = "";
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string ZRSV01 { get; set;} = "";
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string ZRSV02 { get; set;} = "";
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string ZRSV03 { get; set;} = "";
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string ZRSV04 { get; set;} = "";
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string ZRSV05 { get; set;} = "";
      
   } 

}
