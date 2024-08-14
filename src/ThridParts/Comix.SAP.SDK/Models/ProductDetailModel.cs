using System.Runtime.Serialization;

namespace Comix.SAP.SDK.Models;

    [DataContract]
    public class ProductDetailModel
    {
        /// <summary>
        /// 物料号_500000052_是
        /// </summary>
        private string _MATNR = "";
        public string MATNR
        {
            get { return _MATNR; }
            set { _MATNR = value; }
        }
        /// <summary>
        /// 基本计量单位_PCS_是
        /// </summary>
        private string _MEINS = "";
        public string MEINS
        {
            get { return _MEINS; }
            set { _MEINS = value; }
        }
        /// <summary>
        /// 采购订单的计量单位__否
        /// </summary>
        private string _BSTME = "";
        public string BSTME
        {
            get { return _BSTME; }
            set { _BSTME = value; }
        }
        /// <summary>
        /// 基本物料__否
        /// </summary>
        private string _WRKST = "";
        public string WRKST
        {
            get { return _WRKST; }
            set { _WRKST = value; }
        }
        /// <summary>
        /// 文档变更号(无文档管理系统)__否
        /// </summary>
        private string _AESZN = "";
        public string AESZN
        {
            get { return _AESZN; }
            set { _AESZN = value; }
        }
        /// <summary>
        /// 批次管理需求的标识__否
        /// </summary>
        private string _XCHPF = "";
        public string XCHPF
        {
            get { return _XCHPF; }
            set { _XCHPF = value; }
        }
        /// <summary>
        /// 序列号的清晰的级别__否
        /// </summary>
        private string _SERLV = "";
        public string SERLV
        {
            get { return _SERLV; }
            set { _SERLV = value; }
        }
        /// <summary>
        /// 来自物料主文件的项目类别组_NORM_是
        /// </summary>
        private string _MTPOS = "";
        public string MTPOS
        {
            get { return _MTPOS; }
            set { _MTPOS = value; }
        }
        /// <summary>
        /// 可配置的物料__否
        /// </summary>
        private string _KZKFG = "";
        public string KZKFG
        {
            get { return _KZKFG; }
            set { _KZKFG = value; }
        }
        /// <summary>
        /// 物料组_10001_否
        /// </summary>
        private string _MATKL = "";
        public string MATKL
        {
            get { return _MATKL; }
            set { _MATKL = value; }
        }
        /// <summary>
        /// 旧物料号__否
        /// </summary>
        private string _BISMT = "";
        public string BISMT
        {
            get { return _BISMT; }
            set { _BISMT = value; }
        }
        /// <summary>
        /// 外部物料组_1001_否
        /// </summary>
        private string _EXTWG = "";
        public string EXTWG
        {
            get { return _EXTWG; }
            set { _EXTWG = value; }
        }
        /// <summary>
        /// 产品组_21_否
        /// </summary>
        private string _SPART = "";
        public string SPART
        {
            get { return _SPART; }
            set { _SPART = value; }
        }
        /// <summary>
        /// 实验室/设计室__否
        /// </summary>
        private string _LABOR = "";
        public string LABOR
        {
            get { return _LABOR; }
            set { _LABOR = value; }
        }
        /// <summary>
        /// 生产备忘录的页格式__否
        /// </summary>
        private string _FORMT = "";
        public string FORMT
        {
            get { return _FORMT; }
            set { _FORMT = value; }
        }
        /// <summary>
        /// 生产/检验备忘录__否
        /// </summary>
        private string _FERTH = "";
        public string FERTH
        {
            get { return _FERTH; }
            set { _FERTH = value; }
        }
        /// <summary>
        /// 存储条件__否
        /// </summary>
        private string _RAUBE = "";
        public string RAUBE
        {
            get { return _RAUBE; }
            set { _RAUBE = value; }
        }
        /// <summary>
        /// 运输组_0001_是
        /// </summary>
        private string _TRAGR = "";
        public string TRAGR
        {
            get { return _TRAGR; }
            set { _TRAGR = value; }
        }
        /// <summary>
        /// 行业标准描述（例如 ANSI 或 ISO）__否
        /// </summary>
        private string _NORMT = "";
        public string NORMT
        {
            get { return _NORMT; }
            set { _NORMT = value; }
        }
        /// <summary>
        /// 产品层次_21_否
        /// </summary>
        private string _PRODH = "";
        public string PRODH
        {
            get { return _PRODH; }
            set { _PRODH = value; }
        }
        /// <summary>
        /// 产品分配确定程序__否
        /// </summary>
        private string _KOSCH = "";
        public string KOSCH
        {
            get { return _KOSCH; }
            set { _KOSCH = value; }
        }
        /// <summary>
        /// 毛重__否
        /// </summary>
        private decimal _BRGEW;
        public decimal BRGEW
        {
            get { return _BRGEW; }
            set { _BRGEW = value; }
        }
        /// <summary>
        /// 重量单位_G_是
        /// </summary>
        private string _GEWEI = "";
        public string GEWEI
        {
            get { return _GEWEI; }
            set { _GEWEI = value; }
        }
        /// <summary>
        /// 净重__否
        /// </summary>
        private decimal _NTGEW;
        public decimal NTGEW
        {
            get { return _NTGEW; }
            set { _NTGEW = value; }
        }
        /// <summary>
        /// 大小/量纲__否
        /// </summary>
        private string _GROES = "";
        public string GROES
        {
            get { return _GROES; }
            set { _GROES = value; }
        }
        /// <summary>
        /// 基本物料__否
        /// </summary>
        private string _PROC_CLS = "";
        public string PROC_CLS
        {
            get { return _PROC_CLS; }
            set { _PROC_CLS = value; }
        }
        /// <summary>
        /// 工厂_1905_是
        /// </summary>
        private string _WERKS = "";
        public string WERKS
        {
            get { return _WERKS; }
            set { _WERKS = value; }
        }
        /// <summary>
        /// 采购组_21_是
        /// </summary>
        private string _EKGRP = "";
        public string EKGRP
        {
            get { return _EKGRP; }
            set { _EKGRP = value; }
        }
        /// <summary>
        /// 物料需求计划类型_PD_是
        /// </summary>
        private string _DISMM = "";
        public string DISMM
        {
            get { return _DISMM; }
            set { _DISMM = value; }
        }
        /// <summary>
        /// MRP 控制者（物料计划人）_21_是
        /// </summary>
        private string _DISPO = "";
        public string DISPO
        {
            get { return _DISPO; }
            set { _DISPO = value; }
        }
        /// <summary>
        /// 计划的天数内交货__否
        /// </summary>
        private decimal _PLIFZ;
        public decimal PLIFZ
        {
            get { return _PLIFZ; }
            set { _PLIFZ = value; }
        }
        /// <summary>
        /// 以天计的收货处理时间__否
        /// </summary>
        private string _WEBAZ = "";
        public string WEBAZ
        {
            get { return _WEBAZ; }
            set { _WEBAZ = value; }
        }
        /// <summary>
        /// 期间标识__否
        /// </summary>
        private string _PERKZ = "";
        public string PERKZ
        {
            get { return _PERKZ; }
            set { _PERKZ = value; }
        }
        /// <summary>
        /// 标识：散装物料__否
        /// </summary>
        private string _SCHGT = "";
        public string SCHGT
        {
            get { return _SCHGT; }
            set { _SCHGT = value; }
        }
        /// <summary>
        /// 消耗模式__否
        /// </summary>
        private string _VRMOD = "";
        public string VRMOD
        {
            get { return _VRMOD; }
            set { _VRMOD = value; }
        }
        /// <summary>
        /// 消耗期间:逆向__否
        /// </summary>
        private string _VINT1 = "";
        public string VINT1
        {
            get { return _VINT1; }
            set { _VINT1 = value; }
        }
        /// <summary>
        /// 消耗时期-向前__否
        /// </summary>
        private string _VINT2 = "";
        public string VINT2
        {
            get { return _VINT2; }
            set { _VINT2 = value; }
        }
        /// <summary>
        /// 替换部件__否
        /// </summary>
        private string _ATPKZ = "";
        public string ATPKZ
        {
            get { return _ATPKZ; }
            set { _ATPKZ = value; }
        }
        /// <summary>
        /// 在装运中有关能力计划的基准数量__否
        /// </summary>
        private string _VBAMG = "";
        public string VBAMG
        {
            get { return _VBAMG; }
            set { _VBAMG = value; }
        }
        /// <summary>
        /// 处理时间: 装运__否
        /// </summary>
        private string _VBEAZ = "";
        public string VBEAZ
        {
            get { return _VBEAZ; }
            set { _VBEAZ = value; }
        }
        /// <summary>
        /// 装运建立时间__否
        /// </summary>
        private string _VRVEZ = "";
        public string VRVEZ
        {
            get { return _VRVEZ; }
            set { _VRVEZ = value; }
        }
        /// <summary>
        /// 序列号参数文件__否
        /// </summary>
        private string _SERNP = "";
        public string SERNP
        {
            get { return _SERNP; }
            set { _SERNP = value; }
        }
        /// <summary>
        /// 批量 (物料计划)_WB_是
        /// </summary>
        private string _DISLS = "";
        public string DISLS
        {
            get { return _DISLS; }
            set { _DISLS = value; }
        }
        /// <summary>
        /// 采购类型_F_是
        /// </summary>
        private string _BESKZ = "";
        public string BESKZ
        {
            get { return _BESKZ; }
            set { _BESKZ = value; }
        }
        /// <summary>
        /// 特殊采购类型__否
        /// </summary>
        private string _SOBSL = "";
        public string SOBSL
        {
            get { return _SOBSL; }
            set { _SOBSL = value; }
        }
        /// <summary>
        /// 安全库存__否
        /// </summary>
        private string _EISBE = "";
        public string EISBE
        {
            get { return _EISBE; }
            set { _EISBE = value; }
        }
        /// <summary>
        /// 最小批量__否
        /// </summary>
        private string _BSTMI = "";
        public string BSTMI
        {
            get { return _BSTMI; }
            set { _BSTMI = value; }
        }
        /// <summary>
        /// 最大批量大小__否
        /// </summary>
        private string _BSTMA = "";
        public string BSTMA
        {
            get { return _BSTMA; }
            set { _BSTMA = value; }
        }
        /// <summary>
        /// 固定批量大小__否
        /// </summary>
        private string _BSTFE = "";
        public string BSTFE
        {
            get { return _BSTFE; }
            set { _BSTFE = value; }
        }
        /// <summary>
        /// 采购订单数量的舍入值__否
        /// </summary>
        private string _BSTRF = "";
        public string BSTRF
        {
            get { return _BSTRF; }
            set { _BSTRF = value; }
        }
        /// <summary>
        /// 对于独立和集中需求的相关需求标识__否
        /// </summary>
        private string _SBDKZ = "";
        public string SBDKZ
        {
            get { return _SBDKZ; }
            set { _SBDKZ = value; }
        }
        /// <summary>
        /// 部件废品百分数__否
        /// </summary>
        private string _KAUSF = "";
        public string KAUSF
        {
            get { return _KAUSF; }
            set { _KAUSF = value; }
        }
        /// <summary>
        /// 选择可替换物料单的方法__否
        /// </summary>
        private string _ALTSL = "";
        public string ALTSL
        {
            get { return _ALTSL; }
            set { _ALTSL = value; }
        }
        /// <summary>
        /// 综合MRP标识__否
        /// </summary>
        private string _MISKZ = "";
        public string MISKZ
        {
            get { return _MISKZ; }
            set { _MISKZ = value; }
        }
        /// <summary>
        /// 浮动的计划边际码_000_是
        /// </summary>
        private string _FHORI = "";
        public string FHORI
        {
            get { return _FHORI; }
            set { _FHORI = value; }
        }
        /// <summary>
        /// 标识：反冲__否
        /// </summary>
        private string _RGEKM = "";
        public string RGEKM
        {
            get { return _RGEKM; }
            set { _RGEKM = value; }
        }
        /// <summary>
        /// 生产管理员__否
        /// </summary>
        private string _FEVOR = "";
        public string FEVOR
        {
            get { return _FEVOR; }
            set { _FEVOR = value; }
        }
        /// <summary>
        /// 厂内生产时间__否
        /// </summary>
        private string _DZEIT = "";
        public string DZEIT
        {
            get { return _DZEIT; }
            set { _DZEIT = value; }
        }
        /// <summary>
        /// 总计补货提前时间(按工作日)__否
        /// </summary>
        private string _WZEIT = "";
        public string WZEIT
        {
            get { return _WZEIT; }
            set { _WZEIT = value; }
        }
        /// <summary>
        /// 库存类型__否
        /// </summary>
        private string _INSMK = "";
        public string INSMK
        {
            get { return _INSMK; }
            set { _INSMK = value; }
        }
        /// <summary>
        /// 装载组_0001_是
        /// </summary>
        private string _LADGR = "";
        public string LADGR
        {
            get { return _LADGR; }
            set { _LADGR = value; }
        }
        /// <summary>
        /// 配额分配使用__否
        /// </summary>
        private string _USEQU = "";
        public string USEQU
        {
            get { return _USEQU; }
            set { _USEQU = value; }
        }
        /// <summary>
        /// 可用性检查的检查组_02_是
        /// </summary>
        private string _MTVFP = "";
        public string MTVFP
        {
            get { return _MTVFP; }
            set { _MTVFP = value; }
        }
        /// <summary>
        /// 利润中心_P110000004_是
        /// </summary>
        private string _PRCTR = "";
        public string PRCTR
        {
            get { return _PRCTR; }
            set { _PRCTR = value; }
        }
        /// <summary>
        /// 计划批量_1_是
        /// </summary>
        private decimal _LOSGR ;
        public decimal LOSGR
        {
            get { return _LOSGR; }
            set { _LOSGR = value; }
        }
        /// <summary>
        /// 发货库存地点__否
        /// </summary>
        private string _LGPRO = "";
        public string LGPRO
        {
            get { return _LGPRO; }
            set { _LGPRO = value; }
        }
        /// <summary>
        /// 物料需求计划组__否
        /// </summary>
        private string _DISGR = "";
        public string DISGR
        {
            get { return _DISGR; }
            set { _DISGR = value; }
        }
        /// <summary>
        /// 差异码__否
        /// </summary>
        private string _AWSLS = "";
        public string AWSLS
        {
            get { return _AWSLS; }
            set { _AWSLS = value; }
        }
        /// <summary>
        /// 计划策略组__否
        /// </summary>
        private string _STRGR = "";
        public string STRGR
        {
            get { return _STRGR; }
            set { _STRGR = value; }
        }
        /// <summary>
        /// 外部采购的缺省仓储位置__否
        /// </summary>
        private string _LGFSB = "";
        public string LGFSB
        {
            get { return _LGFSB; }
            set { _LGFSB = value; }
        }
        /// <summary>
        /// 库存的领料顺序组__否
        /// </summary>
        private string _EPRIO = "";
        public string EPRIO
        {
            get { return _EPRIO; }
            set { _EPRIO = value; }
        }
        /// <summary>
        /// 工厂特定的物料状态__否
        /// </summary>
        private string _MMSTA = "";
        public string MMSTA
        {
            get { return _MMSTA; }
            set { _MMSTA = value; }
        }
        /// <summary>
        /// 生产计划参数文件__否
        /// </summary>
        private string _SFCPF = "";
        public string SFCPF
        {
            get { return _SFCPF; }
            set { _SFCPF = value; }
        }
        /// <summary>
        /// 无成本核算__否
        /// </summary>
        private string _NCOST = "";
        public string NCOST
        {
            get { return _NCOST; }
            set { _NCOST = value; }
        }
        /// <summary>
        /// 标识: "允许自动采购订单"__否
        /// </summary>
        private string _KAUTB = "";
        public string KAUTB
        {
            get { return _KAUTB; }
            set { _KAUTB = value; }
        }
        /// <summary>
        /// 标识: 源清单要求__否
        /// </summary>
        private string _KORDB = "";
        public string KORDB
        {
            get { return _KORDB; }
            set { _KORDB = value; }
        }
        /// <summary>
        /// 计划的时界__否
        /// </summary>
        private string _FXHOR = "";
        public string FXHOR
        {
            get { return _FXHOR; }
            set { _FXHOR = value; }
        }
        /// <summary>
        /// 安全时间（按工作日计算）__否
        /// </summary>
        private string _SHZET = "";
        public string SHZET
        {
            get { return _SHZET; }
            set { _SHZET = value; }
        }
        /// <summary>
        /// 装配报废百分比__否
        /// </summary>
        private string _AUSSS = "";
        public string AUSSS
        {
            get { return _AUSSS; }
            set { _AUSSS = value; }
        }
        /// <summary>
        /// 标志：关键部件__否
        /// </summary>
        private string _KZKRI = "";
        public string KZKRI
        {
            get { return _KZKRI; }
            set { _KZKRI = value; }
        }
        /// <summary>
        /// 安全时间标识（含或不含安全时间）__否
        /// </summary>
        private string _SHFLG = "";
        public string SHFLG
        {
            get { return _SHFLG; }
            set { _SHFLG = value; }
        }
        /// <summary>
        /// 工厂中允许负库存__否
        /// </summary>
        private string _XMCNG = "";
        public string XMCNG
        {
            get { return _XMCNG; }
            set { _XMCNG = value; }
        }
        /// <summary>
        /// 物料运输组__否
        /// </summary>
        private string _MFRGR = "";
        public string MFRGR
        {
            get { return _MFRGR; }
            set { _MFRGR = value; }
        }
        /// <summary>
        /// 出口/进口物料组__否
        /// </summary>
        private string _MTVER = "";
        public string MTVER
        {
            get { return _MTVER; }
            set { _MTVER = value; }
        }
        /// <summary>
        /// 外贸的商品代码和进口代码__否
        /// </summary>
        private string _STAWN = "";
        public string STAWN
        {
            get { return _STAWN; }
            set { _STAWN = value; }
        }
        /// <summary>
        /// 物料原产地国家__否
        /// </summary>
        private string _HERKL = "";
        public string HERKL
        {
            get { return _HERKL; }
            set { _HERKL = value; }
        }
        /// <summary>
        /// 物料原产地（非特惠货源）__否
        /// </summary>
        private string _HERKR = "";
        public string HERKR
        {
            get { return _HERKR; }
            set { _HERKR = value; }
        }
        /// <summary>
        /// 价格控制指示符_V_是
        /// </summary>
        private string _VPRSV = "";
        public string VPRSV
        {
            get { return _VPRSV; }
            set { _VPRSV = value; }
        }
        /// <summary>
        /// 价格单位_1_是
        /// </summary>
        private decimal _PEINH  ;
        public decimal PEINH
        {
            get { return _PEINH; }
            set { _PEINH = value; }
        }
        /// <summary>
        /// 标准价格__否
        /// </summary>
        private string _STPRS = "";
        public string STPRS
        {
            get { return _STPRS; }
            set { _STPRS = value; }
        }
        /// <summary>
        /// 评估类_1405_是
        /// </summary>
        private string _BKLAS = "";
        public string BKLAS
        {
            get { return _BKLAS; }
            set { _BKLAS = value; }
        }
        /// <summary>
        /// 移动平均价格/周期单价__否
        /// </summary>
        private string _VERPR = "";
        public string VERPR
        {
            get { return _VERPR; }
            set { _VERPR = value; }
        }
        /// <summary>
        /// 作为成本要素子组的原始组__否
        /// </summary>
        private string _HRKFT = "";
        public string HRKFT
        {
            get { return _HRKFT; }
            set { _HRKFT = value; }
        }
        /// <summary>
        /// 成本核算间接费用组__否
        /// </summary>
        private string _KOSGR = "";
        public string KOSGR
        {
            get { return _KOSGR; }
            set { _KOSGR = value; }
        }
        /// <summary>
        /// 物料相关的源__否
        /// </summary>
        private string _HKMAT = "";
        public string HKMAT
        {
            get { return _HKMAT; }
            set { _HKMAT = value; }
        }
        /// <summary>
        /// 物料根据数量结构进行成本核算__否
        /// </summary>
        private string _EKALR = "";
        public string EKALR
        {
            get { return _EKALR; }
            set { _EKALR = value; }
        }
        /// <summary>
        /// 物料价格确定: 控制__否
        /// </summary>
        private string _MLAST = "";
        public string MLAST
        {
            get { return _MLAST; }
            set { _MLAST = value; }
        }
        /// <summary>
        /// 统计组__否
        /// </summary>
        private string _VERSG = "";
        public string VERSG
        {
            get { return _VERSG; }
            set { _VERSG = value; }
        }
        /// <summary>
        /// 物料定价组_01_是
        /// </summary>
        private string _KONDM = "";
        public string KONDM
        {
            get { return _KONDM; }
            set { _KONDM = value; }
        }
        /// <summary>
        /// 该物料的科目设置组_03_是
        /// </summary>
        private string _KTGRM = "";
        public string KTGRM
        {
            get { return _KTGRM; }
            set { _KTGRM = value; }
        }
        /// <summary>
        /// 交货工厂_1905_是
        /// </summary>
        private string _DWERK = "";
        public string DWERK
        {
            get { return _DWERK; }
            set { _DWERK = value; }
        }
        /// <summary>
        /// 销售组织_1100_是
        /// </summary>
        private string _VKORG = "";
        public string VKORG
        {
            get { return _VKORG; }
            set { _VKORG = value; }
        }
        /// <summary>
        /// 分销渠道_30_是
        /// </summary>
        private string _VTWEG = "";
        public string VTWEG
        {
            get { return _VTWEG; }
            set { _VTWEG = value; }
        }
        /// <summary>
        /// 来自物料主文件的项目类别组_BANS_是
        /// </summary>
        private string _MV_MTPOS = "";
        public string MV_MTPOS
        {
            get { return _MV_MTPOS; }
            set { _MV_MTPOS = value; }
        }
        /// <summary>
        /// 库存地点_1001_是
        /// </summary>
        private string _LGORT = "";
        public string LGORT
        {
            get { return _LGORT; }
            set { _LGORT = value; }
        }
        /// <summary>
        /// 物料描述（短文本）_测试物料描述_是
        /// </summary>
        private string _MAKTX = "";
        public string MAKTX
        {
            get { return _MAKTX; }
            set { _MAKTX = value; }
        }
        /// <summary>
        /// 物料的税分类_1_否
        /// </summary>
        private string _TAXKM = "";
        public string TAXKM
        {
            get { return _TAXKM; }
            set { _TAXKM = value; }
        }
        /// <summary>
        /// 税分类编码
        /// </summary>
        private string _TAX_CLASSIFY = "";
        public string TAX_CLASSIFY
        {
            get { return _TAX_CLASSIFY; }
            set { _TAX_CLASSIFY = value; }
        }
        /// <summary>
        /// 帐面库存单位的可选计量单位__否
        /// </summary>
        private string _ALT_UNIT = "";
        public string ALT_UNIT
        {
            get { return _ALT_UNIT; }
            set { _ALT_UNIT = value; }
        }
        /// <summary>
        /// 基本计量单位转换分子__否
        /// </summary>
        private string _NUMER = "";
        public string NUMER
        {
            get { return _NUMER; }
            set { _NUMER = value; }
        }
        /// <summary>
        /// 转换为基本计量单位的分母__否
        /// </summary>
        private string _DENOM = "";
        public string DENOM
        {
            get { return _DENOM; }
            set { _DENOM = value; }
        }
        /// <summary>
        /// 国际文件号(EAN/UPC)__否
        /// </summary>
        private string _EAN_UPC = "";
        public string EAN_UPC
        {
            get { return _EAN_UPC; }
            set { _EAN_UPC = value; }
        }
        /// <summary>
        /// 业务量__否
        /// </summary>
        private string _VOLUM = "";
        public string VOLUM
        {
            get { return _VOLUM; }
            set { _VOLUM = value; }
        }
        /// <summary>
        /// 体积单位__否
        /// </summary>
        private string _VOLEH = "";
        public string VOLEH
        {
            get { return _VOLEH; }
            set { _VOLEH = value; }
        }


        public string CC_CODE { get; set; }
        public string CN_UNIT { get; set; }
        public string CC_CLASS1 { get; set; }
        public string CC_CLASS2 { get; set; }
        public string CC_CLASS3 { get; set; }
        public string PRODUCT_GRADE { get; set; }
        public string TAX_PERCENT { get; set; }
        public int IS_FANGYI { get; set; }
    }