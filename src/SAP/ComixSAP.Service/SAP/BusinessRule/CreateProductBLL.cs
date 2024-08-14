using System.Collections.Generic;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class CreateProductBLL 
    {
        public virtual bool CreateProduct(ProductHeadModel headModel,ProductDetailModel detailModel1,ProductUnitModel unitModel1, out string errorMessage)
        {
            errorMessage = "";
            string emailContent = "";
            // try
            // {
                CreateProductEntity entity = new CreateProductEntity();
                CreateProductHeadModel model = new CreateProductHeadModel();
                model.Messageid = headModel.MESSAGEID;  // 流水号__是
                model.Material = headModel.ProductCode;  // 物料号_500000052_是
                model.IndSector = headModel.IND_SECTOR;  // 行业领域_Z_是
                model.MatlType = headModel.MATL_TYPE;  // 物料类型_Z005_是
                model.BasicView = headModel.BASIC_VIEW;  // 基本数据视图_X_是
                model.SalesView = headModel.SALES_VIEW;  // 销售视图_X_是
                model.PurchaseView = headModel.PURCHASE_VIEW;  // 采购视图_X_是
                model.MrpView = headModel.MRP_VIEW;  // 物料需求计划(MRP)视图_X_是
                model.ForecastView = headModel.FORECAST_VIEW;  // 预测视图__否
                model.WorkSchedView = headModel.WORK_SCHED_VIEW;  // 工作计划视图__否
                model.PrtView = headModel.PRT_VIEW;  // 生产资源/工具(PRT)视图__否
                model.StorageView = headModel.STORAGE_VIEW;  // 存储视图_X_是
                model.WarehouseView = headModel.WAREHOUSE_VIEW;  // 仓库管理视图_X_是
                model.QualityView = headModel.QUALITY_VIEW;  // 质量管理视图__否
                model.AccountView = headModel.ACCOUNT_VIEW;  // 会计视图_X_是
                model.CostView = headModel.COST_VIEW;  // 成本视图_X_是
                model.InpFldCheck = headModel.INP_FLD_CHECK;  // 字段未激活的响应__否
                model.MaterialExternal = headModel.MATERIAL_EXTERNAL;  // MATERIAL 字段的长物料号__否
                model.MaterialGuid = headModel.MATERIAL_GUID;  // MATERIAL 字段的外部 GUID__否
                model.MaterialVersion = headModel.MATERIAL_VERSION;  // MATERIAL 字段的版本编号__否

                List<CreateProductDetailModel> listDetailModel = new List<CreateProductDetailModel>();
                CreateProductDetailModel detailModel = new CreateProductDetailModel();
                detailModel.Matnr = detailModel1.MATNR;  // 物料号_500000052_是
                detailModel.Meins = detailModel1.MEINS;  // 基本计量单位_PCS_是
                detailModel.Bstme = detailModel1.BSTME;  // 采购订单的计量单位__否
                detailModel.Wrkst = detailModel1.WRKST;  // 基本物料__否
                detailModel.Aeszn = detailModel1.AESZN;  // 文档变更号(无文档管理系统)__否
                detailModel.Xchpf = detailModel1.XCHPF;  // 批次管理需求的标识__否
                detailModel.Serlv = detailModel1.SERLV;  // 序列号的清晰的级别__否
                detailModel.Mtpos = detailModel1.MTPOS;  // 来自物料主文件的项目类别组_NORM_是
                detailModel.Kzkfg = detailModel1.KZKFG;  // 可配置的物料__否
                detailModel.Matkl = detailModel1.MATKL;  // 物料组_10001_是
                detailModel.Bismt = detailModel1.BISMT;  // 旧物料号__否
                detailModel.EXTWG = detailModel1.EXTWG;  // 外部物料组_1001_是
                detailModel.Spart = detailModel1.SPART;  // 产品组_21_是
                detailModel.Labor = detailModel1.LABOR;  // 实验室/设计室__否
                detailModel.Formt = detailModel1.FORMT;  // 生产备忘录的页格式__否
                detailModel.Ferth = detailModel1.FERTH;  // 生产/检验备忘录__否
                detailModel.Raube = detailModel1.RAUBE;  // 存储条件__否
                detailModel.Tragr = detailModel1.TRAGR;  // 运输组_0001_是
                detailModel.Normt = detailModel1.NORMT;  // 行业标准描述（例如 ANSI 或 ISO）__否
                detailModel.Prodh = detailModel1.PRODH;  // 产品层次_21_是
                detailModel.Kosch = detailModel1.KOSCH;  // 产品分配确定程序__否
                detailModel.Brgew = detailModel1.BRGEW;  // 毛重__否
                detailModel.Gewei = detailModel1.GEWEI;  // 重量单位_G_是
                detailModel.Ntgew = detailModel1.NTGEW;  // 净重__否
                detailModel.Groes = detailModel1.GROES;  // 大小/量纲__否
                detailModel.ProcCls = detailModel1.PROC_CLS;  // 基本物料__否
                detailModel.Werks = detailModel1.WERKS;  // 工厂_1905_是
                detailModel.Ekgrp = detailModel1.EKGRP;  // 采购组_21_是
                detailModel.Dismm = detailModel1.DISMM;  // 物料需求计划类型_PD_是
                detailModel.Dispo = detailModel1.DISPO;  // MRP 控制者（物料计划人）_21_是
                detailModel.Plifz = detailModel1.PLIFZ;  // 计划的天数内交货__否
                //detailModel.Webaz = "";  // 以天计的收货处理时间__否
                detailModel.Perkz = detailModel1.PERKZ;  // 期间标识__否
                detailModel.Schgt = detailModel1.SCHGT;  // 标识：散装物料__否
                detailModel.Vrmod = detailModel1.VRMOD;  // 消耗模式__否
                //detailModel.Vint1 = "";  // 消耗期间:逆向__否
                //detailModel.Vint2 = "";  // 消耗时期-向前__否
                detailModel.Atpkz = detailModel1.ATPKZ;  // 替换部件__否
                //detailModel.Vbamg = "";  // 在装运中有关能力计划的基准数量__否
                //detailModel.Vbeaz = "";  // 处理时间: 装运__否
                //detailModel.Vrvez = "";  // 装运建立时间__否
                detailModel.Sernp = detailModel1.SERNP;  // 序列号参数文件__否
                detailModel.Disls = detailModel1.DISLS;  // 批量 (物料计划)_WB_是
                detailModel.Beskz = detailModel1.BESKZ;  // 采购类型_F_是
                detailModel.Sobsl = detailModel1.SOBSL;  // 特殊采购类型__否
                //detailModel.Eisbe = "";  // 安全库存__否
                //detailModel.Bstmi = "";  // 最小批量__否
                //detailModel.Bstma = "";  // 最大批量大小__否
                //detailModel.Bstfe = "";  // 固定批量大小__否
                //detailModel.Bstrf = "";  // 采购订单数量的舍入值__否
                detailModel.Sbdkz = detailModel1.SBDKZ;  // 对于独立和集中需求的相关需求标识__否
                //detailModel.Kausf = "";  // 部件废品百分数__否
                detailModel.Altsl = detailModel1.ALTSL;  // 选择可替换物料单的方法__否
                detailModel.Miskz = detailModel1.MISKZ;  // 综合MRP标识__否
                detailModel.Fhori = detailModel1.FHORI;  // 浮动的计划边际码_000_是
                detailModel.Rgekm = detailModel1.RGEKM;  // 标识：反冲__否
                detailModel.Fevor = detailModel1.FEVOR;  // 生产管理员__否
                //detailModel.Dzeit = "";  // 厂内生产时间__否
                //detailModel.Wzeit = "";  // 总计补货提前时间(按工作日)__否
                detailModel.Insmk = detailModel1.INSMK;  // 库存类型__否
                detailModel.Ladgr = detailModel1.LADGR;  // 装载组_0001_是
                detailModel.Usequ = detailModel1.USEQU;  // 配额分配使用__否
                detailModel.Mtvfp = detailModel1.MTVFP;  // 可用性检查的检查组_02_是
                detailModel.Prctr = detailModel1.PRCTR;  // 利润中心_P110000004_否
                detailModel.Losgr = detailModel1.LOSGR;  // 计划批量_1_是
                detailModel.Lgpro = detailModel1.LGPRO;  // 发货库存地点__否
                detailModel.Disgr = detailModel1.DISGR;  // 物料需求计划组__否
                detailModel.Awsls = detailModel1.AWSLS;  // 差异码__否
                detailModel.Strgr = detailModel1.STRGR;  // 计划策略组__否
                detailModel.Lgfsb = detailModel1.LGFSB;  // 外部采购的缺省仓储位置__否
                detailModel.Eprio = detailModel1.EPRIO;  // 库存的领料顺序组__否
                detailModel.Mmsta = detailModel1.MMSTA;  // 工厂特定的物料状态__否
                detailModel.Sfcpf = detailModel1.SFCPF;  // 生产计划参数文件__否
                detailModel.Ncost = detailModel1.NCOST;  // 无成本核算__否
                detailModel.Kautb = detailModel1.KAUTB;  // 标识: "允许自动采购订单"__否
                detailModel.Kordb = detailModel1.KORDB;  // 标识: 源清单要求__否
                //detailModel.Fxhor = "";  // 计划的时界__否
                //detailModel.Shzet = "";  // 安全时间（按工作日计算）__否
                //detailModel.Ausss = "";  // 装配报废百分比__否
                detailModel.Kzkri = detailModel1.KZKRI;  // 标志：关键部件__否
                detailModel.Shflg = detailModel1.SHFLG;  // 安全时间标识（含或不含安全时间）__否
                detailModel.Xmcng = detailModel1.XMCNG;  // 工厂中允许负库存__否
                detailModel.Mfrgr = detailModel1.MFRGR;  // 物料运输组__否
                detailModel.Mtver = detailModel1.MTVER;  // 出口/进口物料组__否
                detailModel.Stawn = detailModel1.STAWN;  // 外贸的商品代码和进口代码__否
                detailModel.Herkl = detailModel1.HERKL;  // 物料原产地国家__否
                detailModel.Herkr = detailModel1.HERKR;  // 物料原产地（非特惠货源）__否
                detailModel.Vprsv = detailModel1.VPRSV;  // 价格控制指示符_V_是
                detailModel.Peinh = detailModel1.PEINH;  // 价格单位_1_是
                //detailModel.Stprs = "";  // 标准价格__否
                detailModel.Bklas = detailModel1.BKLAS;  // 评估类_1405_是
                //detailModel.Verpr = "";  // 移动平均价格/周期单价__否
                detailModel.Hrkft = detailModel1.HRKFT;  // 作为成本要素子组的原始组__否
                detailModel.Kosgr = detailModel1.KOSGR;  // 成本核算间接费用组__否
                detailModel.Hkmat = detailModel1.HKMAT;  // 物料相关的源__否
                detailModel.Ekalr = detailModel1.EKALR;  // 物料根据数量结构进行成本核算__否
                detailModel.Mlast = detailModel1.MLAST;  // 物料价格确定: 控制__否
                detailModel.Versg = detailModel1.VERSG;  // 统计组__否
                detailModel.Kondm = detailModel1.KONDM;  // 物料定价组_01_是
                detailModel.Ktgrm = detailModel1.KTGRM;  // 该物料的科目设置组_03_是
                detailModel.Dwerk = detailModel1.DWERK;  // 交货工厂_1905_是
                detailModel.Vkorg = detailModel1.VKORG;  // 销售组织_1100_是
                detailModel.Vtweg = detailModel1.VTWEG;  // 分销渠道_30_是
                detailModel.MvMtpos = detailModel1.MV_MTPOS;  // 来自物料主文件的项目类别组_BANS_是
                detailModel.Lgort = detailModel1.LGORT;  // 库存地点_1001_是
                detailModel.Maktx = detailModel1.MAKTX;  // 物料描述（短文本）_测试物料描述_是
                detailModel.Taxkm = detailModel1.TAXKM;  // 物料的税分类_1_否
                detailModel.TAX_CLASSIFY = detailModel1.TAX_CLASSIFY;//税分类编码 必填
                //detailModel.AltUnit = "";  // 帐面库存单位的可选计量单位__否
                //detailModel.Numer = "";  // 基本计量单位转换分子__否
                //detailModel.Denom = "";  // 转换为基本计量单位的分母__否
                //detailModel.EanUpc = "";  // 国际文件号(EAN/UPC)__否
                //detailModel.Volum = "";  // 业务量__否
                //detailModel.Voleh = "";  // 体积单位__否
                listDetailModel.Add(detailModel);

                List<CreateProductUnitModel> listUnitModel = new List<CreateProductUnitModel>();
                CreateProductUnitModel unitModel = new CreateProductUnitModel();
                unitModel.AltUnit = "PCS";  // 帐面库存单位的可选计量单位_PCS_是
                //unitModel.AltUnitIso = "";  // ISO代码中存储保持的可选度量单位__否
                unitModel.Numerator = 1;  // 基本计量单位转换分子_1_是
                unitModel.Denominatr = 1;  // 转换为基本计量单位的分母_1_是
                //unitModel.EanUpc = "";  // 国际文件号(EAN/UPC)__否
                //unitModel.EanCat = "";  // 国际商品编码的类别 (EAN)__否
                //unitModel.Length = "";  // 长度__否
                //unitModel.Width = "";  // 宽度__否
                //unitModel.Height = "";  // 高度__否
                //unitModel.UnitDim = "";  // 长度/宽度/高度的尺寸单位__否
                //unitModel.UnitDimIso = "";  // 在ISO代码中关于长度/宽度/高度的单位__否
                //unitModel.Volume = "";  // 业务量__否
                //unitModel.Volumeunit = "";  // 体积单位__否
                //unitModel.VolumeunitIso = "";  // 在ISO代码中的体积单位__否
                //unitModel.GrossWt = "";  // 毛重__否
                //unitModel.UnitOfWt = "";  // 重量单位__否
                //unitModel.UnitOfWtIso = "";  // 在ISO代码中的加权单位__否
                //unitModel.DelFlag = "";  // 删除数据计量(在重复表中)__否
                //unitModel.SubUom = "";  // 包装层次中的低层计量单位__否
                //unitModel.SubUomIso = "";  // ISO 代码中的低级计量单位__否
                //unitModel.GtinVariant = "";  // 全球贸易项目编号变式__否
                //unitModel.NestingFactor = "";  // 套装后的剩余体积(百分比)__否
                unitModel.MaximumStacking = 6;  // 最大占空系数__否
                //unitModel.CapacityUsage = "";  // 能力使用__否
                //unitModel.EwmCwUomType = "";  // EWM-CW：计量单位的类别__否

                listUnitModel.Add(unitModel);

                List<CreateProductReturnModel> listReturn = new List<CreateProductReturnModel>();

                entity.ProductHead = model;
                entity.ProductDetailList = listDetailModel;
                entity.ProductUnitList = listUnitModel;
                entity.ReturnList = listReturn;

                entity.Validate();
                SapStructureService<CreateProductEntity>.GetSAPRFCEntity(entity);

                bool IsSuccess=false;
                
                foreach (CreateProductReturnModel item in entity.ReturnList)
                {
                    if (item.Type == "S")
                    {
                        IsSuccess = true;
                        break;
                    }
                    else
                    {
                        errorMessage += item.Message;
                    }
                }

                return IsSuccess;
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常CreateProduct!"+ex.Message+ex.StackTrace;
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     //mailEntity.EMAIL_TITLE = "创建SAP客户["+customer.NAME1+"]错误";
            //     mailEntity.EMAIL_TOUSER = "jungui.sun@qx.com";
            //     mailEntity.EMAIL_CCUSER = "";
            //     mailEntity.EMAIL_CONTENT = "错误:" + errorMessage;
            //     mailEntity.ATTACHMENTS_PATH = "";
            //     mailEntity.EMAIL_DATE = DateTime.Now;
            //     mailEntity.EMAIL_SENDER = "";
            //     mailEntity.SEND_TIMES = 0;
            //     mailEntity.SEND_STATUS = 0;
            //     mailEntity.REMARK = "";
            //     mailEntity.LAST_MODIFIED_BY = "EDI";
            //     mailEntity.LAST_MODIFIED_TIME = DateTime.Now;
            //     DataAccess.Insert(mailEntity);
            //     return false;
            // }
        }
    }
}
