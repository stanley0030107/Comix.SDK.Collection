using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
     [DataContract]
    public class CreateProductDetailModel : SapModelBase
     {
          public override void SetFieldNames()
          {
             this.PropertyNames = new List<string> { 
           "MATNR","MEINS","BSTME","WRKST","AESZN","XCHPF","SERLV","MTPOS","KZKFG","MATKL","BISMT","EXTWG","SPART","LABOR","FORMT","FERTH","RAUBE","TRAGR","NORMT","PRODH","KOSCH","BRGEW","GEWEI","NTGEW","GROES","PROC_CLS","WERKS","EKGRP","DISMM","DISPO","PLIFZ","WEBAZ","PERKZ","SCHGT","VRMOD","VINT1","VINT2","ATPKZ","VBAMG","VBEAZ","VRVEZ","SERNP","DISLS","BESKZ","SOBSL","EISBE","BSTMI","BSTMA","BSTFE","BSTRF","SBDKZ","KAUSF","ALTSL","MISKZ","FHORI","RGEKM","FEVOR","DZEIT","WZEIT","INSMK","LADGR","USEQU","MTVFP","PRCTR","LOSGR","LGPRO","DISGR","AWSLS","STRGR","LGFSB","EPRIO","MMSTA","SFCPF","NCOST","KAUTB","KORDB","FXHOR","SHZET","AUSSS","KZKRI","SHFLG","XMCNG","MFRGR","MTVER","STAWN","HERKL","HERKR","VPRSV","PEINH","STPRS","BKLAS","VERPR","HRKFT","KOSGR","HKMAT","EKALR","MLAST","VERSG","KONDM","KTGRM","DWERK","VKORG","VTWEG","MV_MTPOS","LGORT","MAKTX","TAXKM","TAX_CLASSIFY","ALT_UNIT","NUMER","DENOM","EAN_UPC","VOLUM","VOLEH"};
           }

  [DataMember]
  //物料号 
  public string Matnr
  {
      get
      {
          return base.GetProperty<string>("MATNR");
       }
       set
       {
          base.SetProperty("MATNR", value);
       }
   }
 
  [DataMember]
  //基本计量单位
  public string Meins
  {
      get
      {
          return base.GetProperty<string>("MEINS");
       }
       set
       {
          base.SetProperty("MEINS", value);
       }
   }
 
  [DataMember]
  //采购订单的计量单位 
  public string Bstme
  {
      get
      {
          return base.GetProperty<string>("BSTME");
       }
       set
       {
          base.SetProperty("BSTME", value);
       }
   }
 
  [DataMember]
  //基本物料
  public string Wrkst
  {
      get
      {
          return base.GetProperty<string>("WRKST");
       }
       set
       {
          base.SetProperty("WRKST", value);
       }
   }
 
  [DataMember]
  //文档变更号(无文档管理系统)
  public string Aeszn
  {
      get
      {
          return base.GetProperty<string>("AESZN");
       }
       set
       {
          base.SetProperty("AESZN", value);
       }
   }
 
  [DataMember]
  //批次管理需求的标识
  public string Xchpf
  {
      get
      {
          return base.GetProperty<string>("XCHPF");
       }
       set
       {
          base.SetProperty("XCHPF", value);
       }
   }
 
  [DataMember]
  //序列号的清晰的级别 
  public string Serlv
  {
      get
      {
          return base.GetProperty<string>("SERLV");
       }
       set
       {
          base.SetProperty("SERLV", value);
       }
   }
 
  [DataMember]
  //来自物料主文件的项目类别组 
  public string Mtpos
  {
      get
      {
          return base.GetProperty<string>("MTPOS");
       }
       set
       {
          base.SetProperty("MTPOS", value);
       }
   }
 
  [DataMember]
  //可配置的物料
  public string Kzkfg
  {
      get
      {
          return base.GetProperty<string>("KZKFG");
       }
       set
       {
          base.SetProperty("KZKFG", value);
       }
   }
 
  [DataMember]
  //物料组 
  public string Matkl
  {
      get
      {
          return base.GetProperty<string>("MATKL");
       }
       set
       {
          base.SetProperty("MATKL", value);
       }
   }
 
  [DataMember]
  //旧物料号
  public string Bismt
  {
      get
      {
          return base.GetProperty<string>("BISMT");
       }
       set
       {
          base.SetProperty("BISMT", value);
       }
   }
 
  [DataMember]
  //外部物料组 
  public string EXTWG
  {
      get
      {
          return base.GetProperty<string>("EXTWG");
       }
       set
       {
           base.SetProperty("EXTWG", value);
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
  //实验室/设计室 
  public string Labor
  {
      get
      {
          return base.GetProperty<string>("LABOR");
       }
       set
       {
          base.SetProperty("LABOR", value);
       }
   }
 
  [DataMember]
  //生产备忘录的页格式 
  public string Formt
  {
      get
      {
          return base.GetProperty<string>("FORMT");
       }
       set
       {
          base.SetProperty("FORMT", value);
       }
   }
 
  [DataMember]
  //生产/检验备忘录
  public string Ferth
  {
      get
      {
          return base.GetProperty<string>("FERTH");
       }
       set
       {
          base.SetProperty("FERTH", value);
       }
   }
 
  [DataMember]
  //存储条件
  public string Raube
  {
      get
      {
          return base.GetProperty<string>("RAUBE");
       }
       set
       {
          base.SetProperty("RAUBE", value);
       }
   }
 
  [DataMember]
  //运输组 
  public string Tragr
  {
      get
      {
          return base.GetProperty<string>("TRAGR");
       }
       set
       {
          base.SetProperty("TRAGR", value);
       }
   }
 
  [DataMember]
  //行业标准描述（例如 ANSI 或 ISO） 
  public string Normt
  {
      get
      {
          return base.GetProperty<string>("NORMT");
       }
       set
       {
          base.SetProperty("NORMT", value);
       }
   }
 
  [DataMember]
  //产品层次
  public string Prodh
  {
      get
      {
          return base.GetProperty<string>("PRODH");
       }
       set
       {
          base.SetProperty("PRODH", value);
       }
   }
 
  [DataMember]
  //产品分配确定程序
  public string Kosch
  {
      get
      {
          return base.GetProperty<string>("KOSCH");
       }
       set
       {
          base.SetProperty("KOSCH", value);
       }
   }
 
  [DataMember]
  //毛重
  public decimal Brgew
  {
      get
      {
          return base.GetProperty<decimal>("BRGEW");
       }
       set
       {
          base.SetProperty("BRGEW", value);
       }
   }
 
  [DataMember]
  //重量单位
  public string Gewei
  {
      get
      {
          return base.GetProperty<string>("GEWEI");
       }
       set
       {
          base.SetProperty("GEWEI", value);
       }
   }
 
  [DataMember]
  //净重 
  public decimal Ntgew
  {
      get
      {
          return base.GetProperty<decimal>("NTGEW");
       }
       set
       {
          base.SetProperty("NTGEW", value);
       }
   }
 
  [DataMember]
  //大小/量纲
  public string Groes
  {
      get
      {
          return base.GetProperty<string>("GROES");
       }
       set
       {
          base.SetProperty("GROES", value);
       }
   }
 
  [DataMember]
  //基本物料
  public string ProcCls
  {
      get
      {
          return base.GetProperty<string>("PROC_CLS");
       }
       set
       {
          base.SetProperty("PROC_CLS", value);
       }
   }
 
  [DataMember]
  //工厂
  public string Werks
  {
      get
      {
          return base.GetProperty<string>("WERKS");
       }
       set
       {
          base.SetProperty("WERKS", value);
       }
   }
 
  [DataMember]
  //采购组 
  public string Ekgrp
  {
      get
      {
          return base.GetProperty<string>("EKGRP");
       }
       set
       {
          base.SetProperty("EKGRP", value);
       }
   }
 
  [DataMember]
  //物料需求计划类型 
  public string Dismm
  {
      get
      {
          return base.GetProperty<string>("DISMM");
       }
       set
       {
          base.SetProperty("DISMM", value);
       }
   }
 
  [DataMember]
  //MRP 控制者（物料计划人）
  public string Dispo
  {
      get
      {
          return base.GetProperty<string>("DISPO");
       }
       set
       {
          base.SetProperty("DISPO", value);
       }
   }
 
  [DataMember]
  //计划的天数内交货
  public decimal Plifz
  {
      get
      {
          return base.GetProperty<decimal>("PLIFZ");
       }
       set
       {
          base.SetProperty("PLIFZ", value);
       }
   }
 
  [DataMember]
  //以天计的收货处理时间
  public decimal Webaz
  {
      get
      {
          return base.GetProperty<decimal>("WEBAZ");
       }
       set
       {
          base.SetProperty("WEBAZ", value);
       }
   }
 
  [DataMember]
  //期间标识
  public string Perkz
  {
      get
      {
          return base.GetProperty<string>("PERKZ");
       }
       set
       {
          base.SetProperty("PERKZ", value);
       }
   }
 
  [DataMember]
  //标识：散装物料 
  public string Schgt
  {
      get
      {
          return base.GetProperty<string>("SCHGT");
       }
       set
       {
          base.SetProperty("SCHGT", value);
       }
   }
 
  [DataMember]
  //消耗模式 
  public string Vrmod
  {
      get
      {
          return base.GetProperty<string>("VRMOD");
       }
       set
       {
          base.SetProperty("VRMOD", value);
       }
   }
 
  [DataMember]
  //消耗期间:逆向
  public decimal Vint1
  {
      get
      {
          return base.GetProperty<decimal>("VINT1");
       }
       set
       {
          base.SetProperty("VINT1", value);
       }
   }
 
  [DataMember]
  //消耗时期-向前
  public decimal Vint2
  {
      get
      {
          return base.GetProperty<decimal>("VINT2");
       }
       set
       {
          base.SetProperty("VINT2", value);
       }
   }
 
  [DataMember]
  //替换部件
  public string Atpkz
  {
      get
      {
          return base.GetProperty<string>("ATPKZ");
       }
       set
       {
          base.SetProperty("ATPKZ", value);
       }
   }
 
  [DataMember]
  //在装运中有关能力计划的基准数量 
  public decimal Vbamg
  {
      get
      {
          return base.GetProperty<decimal>("VBAMG");
       }
       set
       {
          base.SetProperty("VBAMG", value);
       }
   }
 
  [DataMember]
  //处理时间: 装运
  public decimal Vbeaz
  {
      get
      {
          return base.GetProperty<decimal>("VBEAZ");
       }
       set
       {
          base.SetProperty("VBEAZ", value);
       }
   }
 
  [DataMember]
  //装运建立时间
  public decimal Vrvez
  {
      get
      {
          return base.GetProperty<decimal>("VRVEZ");
       }
       set
       {
          base.SetProperty("VRVEZ", value);
       }
   }
 
  [DataMember]
  //序列号参数文件 
  public string Sernp
  {
      get
      {
          return base.GetProperty<string>("SERNP");
       }
       set
       {
          base.SetProperty("SERNP", value);
       }
   }
 
  [DataMember]
  //批量 (物料计划)
  public string Disls
  {
      get
      {
          return base.GetProperty<string>("DISLS");
       }
       set
       {
          base.SetProperty("DISLS", value);
       }
   }
 
  [DataMember]
  //采购类型
  public string Beskz
  {
      get
      {
          return base.GetProperty<string>("BESKZ");
       }
       set
       {
          base.SetProperty("BESKZ", value);
       }
   }
 
  [DataMember]
  //特殊采购类型
  public string Sobsl
  {
      get
      {
          return base.GetProperty<string>("SOBSL");
       }
       set
       {
          base.SetProperty("SOBSL", value);
       }
   }
 
  [DataMember]
  //安全库存
  public decimal Eisbe
  {
      get
      {
          return base.GetProperty<decimal>("EISBE");
       }
       set
       {
          base.SetProperty("EISBE", value);
       }
   }
 
  [DataMember]
  //最小批量 
  public decimal Bstmi
  {
      get
      {
          return base.GetProperty<decimal>("BSTMI");
       }
       set
       {
          base.SetProperty("BSTMI", value);
       }
   }
 
  [DataMember]
  //最大批量大小 
  public decimal Bstma
  {
      get
      {
          return base.GetProperty<decimal>("BSTMA");
       }
       set
       {
          base.SetProperty("BSTMA", value);
       }
   }
 
  [DataMember]
  //固定批量大小
  public decimal Bstfe
  {
      get
      {
          return base.GetProperty<decimal>("BSTFE");
       }
       set
       {
          base.SetProperty("BSTFE", value);
       }
   }
 
  [DataMember]
  //采购订单数量的舍入值 
  public decimal Bstrf
  {
      get
      {
          return base.GetProperty<decimal>("BSTRF");
       }
       set
       {
          base.SetProperty("BSTRF", value);
       }
   }
 
  [DataMember]
  //对于独立和集中需求的相关需求标识 
  public string Sbdkz
  {
      get
      {
          return base.GetProperty<string>("SBDKZ");
       }
       set
       {
          base.SetProperty("SBDKZ", value);
       }
   }
 
  [DataMember]
  //部件废品百分数 
  public decimal Kausf
  {
      get
      {
          return base.GetProperty<decimal>("KAUSF");
       }
       set
       {
          base.SetProperty("KAUSF", value);
       }
   }
 
  [DataMember]
  //选择可替换物料单的方法 
  public string Altsl
  {
      get
      {
          return base.GetProperty<string>("ALTSL");
       }
       set
       {
          base.SetProperty("ALTSL", value);
       }
   }
 
  [DataMember]
  //综合MRP标识
  public string Miskz
  {
      get
      {
          return base.GetProperty<string>("MISKZ");
       }
       set
       {
          base.SetProperty("MISKZ", value);
       }
   }
 
  [DataMember]
  //浮动的计划边际码
  public string Fhori
  {
      get
      {
          return base.GetProperty<string>("FHORI");
       }
       set
       {
          base.SetProperty("FHORI", value);
       }
   }
 
  [DataMember]
  //标识：反冲 
  public string Rgekm
  {
      get
      {
          return base.GetProperty<string>("RGEKM");
       }
       set
       {
          base.SetProperty("RGEKM", value);
       }
   }
 
  [DataMember]
  //生产管理员 
  public string Fevor
  {
      get
      {
          return base.GetProperty<string>("FEVOR");
       }
       set
       {
          base.SetProperty("FEVOR", value);
       }
   }
 
  [DataMember]
  //厂内生产时间
  public decimal Dzeit
  {
      get
      {
          return base.GetProperty<decimal>("DZEIT");
       }
       set
       {
          base.SetProperty("DZEIT", value);
       }
   }
 
  [DataMember]
  //总计补货提前时间(按工作日)
  public decimal Wzeit
  {
      get
      {
          return base.GetProperty<decimal>("WZEIT");
       }
       set
       {
          base.SetProperty("WZEIT", value);
       }
   }
 
  [DataMember]
  //库存类型
  public string Insmk
  {
      get
      {
          return base.GetProperty<string>("INSMK");
       }
       set
       {
          base.SetProperty("INSMK", value);
       }
   }
 
  [DataMember]
  //装载组 
  public string Ladgr
  {
      get
      {
          return base.GetProperty<string>("LADGR");
       }
       set
       {
          base.SetProperty("LADGR", value);
       }
   }
 
  [DataMember]
  //配额分配使用
  public string Usequ
  {
      get
      {
          return base.GetProperty<string>("USEQU");
       }
       set
       {
          base.SetProperty("USEQU", value);
       }
   }
 
  [DataMember]
  //可用性检查的检查组
  public string Mtvfp
  {
      get
      {
          return base.GetProperty<string>("MTVFP");
       }
       set
       {
          base.SetProperty("MTVFP", value);
       }
   }
 
  [DataMember]
  //利润中心
  public string Prctr
  {
      get
      {
          return base.GetProperty<string>("PRCTR");
       }
       set
       {
          base.SetProperty("PRCTR", value);
       }
   }
 
  [DataMember]
  //计划批量
  public decimal Losgr
  {
      get
      {
          return base.GetProperty<decimal>("LOSGR");
       }
       set
       {
          base.SetProperty("LOSGR", value);
       }
   }
 
  [DataMember]
  //发货库存地点
  public string Lgpro
  {
      get
      {
          return base.GetProperty<string>("LGPRO");
       }
       set
       {
          base.SetProperty("LGPRO", value);
       }
   }
 
  [DataMember]
  //物料需求计划组
  public string Disgr
  {
      get
      {
          return base.GetProperty<string>("DISGR");
       }
       set
       {
          base.SetProperty("DISGR", value);
       }
   }
 
  [DataMember]
  //差异码 
  public string Awsls
  {
      get
      {
          return base.GetProperty<string>("AWSLS");
       }
       set
       {
          base.SetProperty("AWSLS", value);
       }
   }
 
  [DataMember]
  //计划策略组 
  public string Strgr
  {
      get
      {
          return base.GetProperty<string>("STRGR");
       }
       set
       {
          base.SetProperty("STRGR", value);
       }
   }
 
  [DataMember]
  //外部采购的缺省仓储位置 
  public string Lgfsb
  {
      get
      {
          return base.GetProperty<string>("LGFSB");
       }
       set
       {
          base.SetProperty("LGFSB", value);
       }
   }
 
  [DataMember]
  //库存的领料顺序组
  public string Eprio
  {
      get
      {
          return base.GetProperty<string>("EPRIO");
       }
       set
       {
          base.SetProperty("EPRIO", value);
       }
   }
 
  [DataMember]
  //工厂特定的物料状态 
  public string Mmsta
  {
      get
      {
          return base.GetProperty<string>("MMSTA");
       }
       set
       {
          base.SetProperty("MMSTA", value);
       }
   }
 
  [DataMember]
  //生产计划参数文件
  public string Sfcpf
  {
      get
      {
          return base.GetProperty<string>("SFCPF");
       }
       set
       {
          base.SetProperty("SFCPF", value);
       }
   }
 
  [DataMember]
  //无成本核算 
  public string Ncost
  {
      get
      {
          return base.GetProperty<string>("NCOST");
       }
       set
       {
          base.SetProperty("NCOST", value);
       }
   }
 
  [DataMember]
  //标识: "允许自动采购订单"
  public string Kautb
  {
      get
      {
          return base.GetProperty<string>("KAUTB");
       }
       set
       {
          base.SetProperty("KAUTB", value);
       }
   }
 
  [DataMember]
  //标识: 源清单要求 
  public string Kordb
  {
      get
      {
          return base.GetProperty<string>("KORDB");
       }
       set
       {
          base.SetProperty("KORDB", value);
       }
   }
 
  [DataMember]
  //计划的时界 
  public decimal Fxhor
  {
      get
      {
          return base.GetProperty<decimal>("FXHOR");
       }
       set
       {
          base.SetProperty("FXHOR", value);
       }
   }
 
  [DataMember]
  //安全时间（按工作日计算）
  public decimal Shzet
  {
      get
      {
          return base.GetProperty<decimal>("SHZET");
       }
       set
       {
          base.SetProperty("SHZET", value);
       }
   }
 
  [DataMember]
  //装配报废百分比 
  public decimal Ausss
  {
      get
      {
          return base.GetProperty<decimal>("AUSSS");
       }
       set
       {
          base.SetProperty("AUSSS", value);
       }
   }
 
  [DataMember]
  //标志：关键部件 
  public string Kzkri
  {
      get
      {
          return base.GetProperty<string>("KZKRI");
       }
       set
       {
          base.SetProperty("KZKRI", value);
       }
   }
 
  [DataMember]
  //安全时间标识（含或不含安全时间）
  public string Shflg
  {
      get
      {
          return base.GetProperty<string>("SHFLG");
       }
       set
       {
          base.SetProperty("SHFLG", value);
       }
   }
 
  [DataMember]
  //工厂中允许负库存
  public string Xmcng
  {
      get
      {
          return base.GetProperty<string>("XMCNG");
       }
       set
       {
          base.SetProperty("XMCNG", value);
       }
   }
 
  [DataMember]
  //物料运输组 
  public string Mfrgr
  {
      get
      {
          return base.GetProperty<string>("MFRGR");
       }
       set
       {
          base.SetProperty("MFRGR", value);
       }
   }
 
  [DataMember]
  //出口/进口物料组 
  public string Mtver
  {
      get
      {
          return base.GetProperty<string>("MTVER");
       }
       set
       {
          base.SetProperty("MTVER", value);
       }
   }
 
  [DataMember]
  //外贸的商品代码和进口代码
  public string Stawn
  {
      get
      {
          return base.GetProperty<string>("STAWN");
       }
       set
       {
          base.SetProperty("STAWN", value);
       }
   }
 
  [DataMember]
  //物料原产地国家 
  public string Herkl
  {
      get
      {
          return base.GetProperty<string>("HERKL");
       }
       set
       {
          base.SetProperty("HERKL", value);
       }
   }
 
  [DataMember]
  //物料原产地（非特惠货源）
  public string Herkr
  {
      get
      {
          return base.GetProperty<string>("HERKR");
       }
       set
       {
          base.SetProperty("HERKR", value);
       }
   }
 
  [DataMember]
  //价格控制指示符 
  public string Vprsv
  {
      get
      {
          return base.GetProperty<string>("VPRSV");
       }
       set
       {
          base.SetProperty("VPRSV", value);
       }
   }
 
  [DataMember]
  //价格单位
  public decimal Peinh
  {
      get
      {
          return base.GetProperty<decimal>("PEINH");
       }
       set
       {
          base.SetProperty("PEINH", value);
       }
   }
 
  [DataMember]
  //标准价格
  public decimal Stprs
  {
      get
      {
          return base.GetProperty<decimal>("STPRS");
       }
       set
       {
          base.SetProperty("STPRS", value);
       }
   }
 
  [DataMember]
  //评估类 
  public string Bklas
  {
      get
      {
          return base.GetProperty<string>("BKLAS");
       }
       set
       {
          base.SetProperty("BKLAS", value);
       }
   }
 
  [DataMember]
  //移动平均价格/周期单价
  public decimal Verpr
  {
      get
      {
          return base.GetProperty<decimal>("VERPR");
       }
       set
       {
          base.SetProperty("VERPR", value);
       }
   }
 
  [DataMember]
  //作为成本要素子组的原始组
  public string Hrkft
  {
      get
      {
          return base.GetProperty<string>("HRKFT");
       }
       set
       {
          base.SetProperty("HRKFT", value);
       }
   }
 
  [DataMember]
  //成本核算间接费用组 
  public string Kosgr
  {
      get
      {
          return base.GetProperty<string>("KOSGR");
       }
       set
       {
          base.SetProperty("KOSGR", value);
       }
   }
 
  [DataMember]
  //物料相关的源
  public string Hkmat
  {
      get
      {
          return base.GetProperty<string>("HKMAT");
       }
       set
       {
          base.SetProperty("HKMAT", value);
       }
   }
 
  [DataMember]
  //物料根据数量结构进行成本核算
  public string Ekalr
  {
      get
      {
          return base.GetProperty<string>("EKALR");
       }
       set
       {
          base.SetProperty("EKALR", value);
       }
   }
 
  [DataMember]
  //物料价格确定: 控制
  public string Mlast
  {
      get
      {
          return base.GetProperty<string>("MLAST");
       }
       set
       {
          base.SetProperty("MLAST", value);
       }
   }
 
  [DataMember]
  //统计组 
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
  //物料定价组 
  public string Kondm
  {
      get
      {
          return base.GetProperty<string>("KONDM");
       }
       set
       {
          base.SetProperty("KONDM", value);
       }
   }
 
  [DataMember]
  //该物料的科目设置组 
  public string Ktgrm
  {
      get
      {
          return base.GetProperty<string>("KTGRM");
       }
       set
       {
          base.SetProperty("KTGRM", value);
       }
   }
 
  [DataMember]
  //交货工厂
  public string Dwerk
  {
      get
      {
          return base.GetProperty<string>("DWERK");
       }
       set
       {
          base.SetProperty("DWERK", value);
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
  //来自物料主文件的项目类别组 
  public string MvMtpos
  {
      get
      {
          return base.GetProperty<string>("MV_MTPOS");
       }
       set
       {
          base.SetProperty("MV_MTPOS", value);
       }
   }
 
  [DataMember]
  //库存地点
  public string Lgort
  {
      get
      {
          return base.GetProperty<string>("LGORT");
       }
       set
       {
          base.SetProperty("LGORT", value);
       }
   }
 
  [DataMember]
  //物料描述（短文本） 
  public string Maktx
  {
      get
      {
          return base.GetProperty<string>("MAKTX");
       }
       set
       {
          base.SetProperty("MAKTX", value);
       }
   }
 
  [DataMember]
  //物料的税分类
  public string Taxkm
  {
      get
      {
          return base.GetProperty<string>("TAXKM");
       }
       set
       {
          base.SetProperty("TAXKM", value);
       }
   }
  [DataMember]
         //税分类编码
  public string TAX_CLASSIFY
  {
      get
      {
          return base.GetProperty<string>("TAX_CLASSIFY");
      }
      set
      {
          base.SetProperty("TAX_CLASSIFY", value);
      }
  }
 
  [DataMember]
  //帐面库存单位的可选计量单位 
  public decimal AltUnit
  {
      get
      {
          return base.GetProperty<decimal>("ALT_UNIT");
       }
       set
       {
          base.SetProperty("ALT_UNIT", value);
       }
   }
 
  [DataMember]
  //基本计量单位转换分子
  public decimal Numer
  {
      get
      {
          return base.GetProperty<decimal>("NUMER");
       }
       set
       {
          base.SetProperty("NUMER", value);
       }
   }
 
  [DataMember]
  //转换为基本计量单位的分母
  public decimal Denom
  {
      get
      {
          return base.GetProperty<decimal>("DENOM");
       }
       set
       {
          base.SetProperty("DENOM", value);
       }
   }
 
  [DataMember]
  //国际文件号(EAN/UPC)
  public string EanUpc
  {
      get
      {
          return base.GetProperty<string>("EAN_UPC");
       }
       set
       {
          base.SetProperty("EAN_UPC", value);
       }
   }
 
  [DataMember]
  //业务量 
  public decimal Volum
  {
      get
      {
          return base.GetProperty<decimal>("VOLUM");
       }
       set
       {
          base.SetProperty("VOLUM", value);
       }
   }
 
  [DataMember]
  //体积单位
  public decimal Voleh
  {
      get
      {
          return base.GetProperty<decimal>("VOLEH");
       }
       set
       {
          base.SetProperty("VOLEH", value);
       }
   }
 
   }
}


