using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
     [DataContract]
     public class CreateProductUnitModel : SapModelBase
     {
          public override void SetFieldNames()
          {
             this.PropertyNames = new List<string> { 
           "ALT_UNIT","ALT_UNIT_ISO","NUMERATOR","DENOMINATR","EAN_UPC","EAN_CAT","LENGTH","WIDTH","HEIGHT","UNIT_DIM","UNIT_DIM_ISO","VOLUME","VOLUMEUNIT","VOLUMEUNIT_ISO","GROSS_WT","UNIT_OF_WT","UNIT_OF_WT_ISO","DEL_FLAG","SUB_UOM","SUB_UOM_ISO","GTIN_VARIANT","NESTING_FACTOR","MAXIMUM_STACKING","CAPACITY_USAGE","EWM_CW_UOM_TYPE"};
           }

  [DataMember]
  //帐面库存单位的可选计量单位 
  public string AltUnit
  {
      get
      {
          return base.GetProperty<string>("ALT_UNIT");
       }
       set
       {
          base.SetProperty("ALT_UNIT", value);
       }
   }
 
  [DataMember]
  //ISO代码中存储保持的可选度量单位 
  public string AltUnitIso
  {
      get
      {
          return base.GetProperty<string>("ALT_UNIT_ISO");
       }
       set
       {
          base.SetProperty("ALT_UNIT_ISO", value);
       }
   }
 
  [DataMember]
  //基本计量单位转换分子
  public decimal Numerator
  {
      get
      {
          return base.GetProperty<decimal>("NUMERATOR");
       }
       set
       {
          base.SetProperty("NUMERATOR", value);
       }
   }
 
  [DataMember]
  //转换为基本计量单位的分母
  public decimal Denominatr
  {
      get
      {
          return base.GetProperty<decimal>("DENOMINATR");
       }
       set
       {
          base.SetProperty("DENOMINATR", value);
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
  //国际商品编码的类别 (EAN)
  public string EanCat
  {
      get
      {
          return base.GetProperty<string>("EAN_CAT");
       }
       set
       {
          base.SetProperty("EAN_CAT", value);
       }
   }
 
  [DataMember]
  //长度
  public decimal Length
  {
      get
      {
          return base.GetProperty<decimal>("LENGTH");
       }
       set
       {
          base.SetProperty("LENGTH", value);
       }
   }
 
  [DataMember]
  //宽度
  public decimal Width
  {
      get
      {
          return base.GetProperty<decimal>("WIDTH");
       }
       set
       {
          base.SetProperty("WIDTH", value);
       }
   }
 
  [DataMember]
  //高度
  public decimal Height
  {
      get
      {
          return base.GetProperty<decimal>("HEIGHT");
       }
       set
       {
          base.SetProperty("HEIGHT", value);
       }
   }
 
  [DataMember]
  //长度/宽度/高度的尺寸单位 
  public decimal UnitDim
  {
      get
      {
          return base.GetProperty<decimal>("UNIT_DIM");
       }
       set
       {
          base.SetProperty("UNIT_DIM", value);
       }
   }
 
  [DataMember]
  //在ISO代码中关于长度/宽度/高度的单位 
  public string UnitDimIso
  {
      get
      {
          return base.GetProperty<string>("UNIT_DIM_ISO");
       }
       set
       {
          base.SetProperty("UNIT_DIM_ISO", value);
       }
   }
 
  [DataMember]
  //业务量 
  public decimal Volume
  {
      get
      {
          return base.GetProperty<decimal>("VOLUME");
       }
       set
       {
          base.SetProperty("VOLUME", value);
       }
   }
 
  [DataMember]
  //体积单位
  public decimal Volumeunit
  {
      get
      {
          return base.GetProperty<decimal>("VOLUMEUNIT");
       }
       set
       {
          base.SetProperty("VOLUMEUNIT", value);
       }
   }
 
  [DataMember]
  //在ISO代码中的体积单位
  public string VolumeunitIso
  {
      get
      {
          return base.GetProperty<string>("VOLUMEUNIT_ISO");
       }
       set
       {
          base.SetProperty("VOLUMEUNIT_ISO", value);
       }
   }
 
  [DataMember]
  //毛重
  public decimal GrossWt
  {
      get
      {
          return base.GetProperty<decimal>("GROSS_WT");
       }
       set
       {
          base.SetProperty("GROSS_WT", value);
       }
   }
 
  [DataMember]
  //重量单位
  public decimal UnitOfWt
  {
      get
      {
          return base.GetProperty<decimal>("UNIT_OF_WT");
       }
       set
       {
          base.SetProperty("UNIT_OF_WT", value);
       }
   }
 
  [DataMember]
  //在ISO代码中的加权单位
  public string UnitOfWtIso
  {
      get
      {
          return base.GetProperty<string>("UNIT_OF_WT_ISO");
       }
       set
       {
          base.SetProperty("UNIT_OF_WT_ISO", value);
       }
   }
 
  [DataMember]
  //删除数据计量(在重复表中)
  public string DelFlag
  {
      get
      {
          return base.GetProperty<string>("DEL_FLAG");
       }
       set
       {
          base.SetProperty("DEL_FLAG", value);
       }
   }
 
  [DataMember]
  //包装层次中的低层计量单位
  public decimal SubUom
  {
      get
      {
          return base.GetProperty<decimal>("SUB_UOM");
       }
       set
       {
          base.SetProperty("SUB_UOM", value);
       }
   }
 
  [DataMember]
  //ISO 代码中的低级计量单位
  public string SubUomIso
  {
      get
      {
          return base.GetProperty<string>("SUB_UOM_ISO");
       }
       set
       {
          base.SetProperty("SUB_UOM_ISO", value);
       }
   }
 
  [DataMember]
  //全球贸易项目编号变式
  public string GtinVariant
  {
      get
      {
          return base.GetProperty<string>("GTIN_VARIANT");
       }
       set
       {
          base.SetProperty("GTIN_VARIANT", value);
       }
   }
 
  [DataMember]
  //套装后的剩余体积(百分比)
  public decimal NestingFactor
  {
      get
      {
          return base.GetProperty<decimal>("NESTING_FACTOR");
       }
       set
       {
          base.SetProperty("NESTING_FACTOR", value);
       }
   }
 
  [DataMember]
  //最大占空系数 
  public int MaximumStacking
  {
      get
      {
          return base.GetProperty<int>("MAXIMUM_STACKING");
       }
       set
       {
          base.SetProperty("MAXIMUM_STACKING", value);
       }
   }
 
  [DataMember]
  //能力使用
  public decimal CapacityUsage
  {
      get
      {
          return base.GetProperty<decimal>("CAPACITY_USAGE");
       }
       set
       {
          base.SetProperty("CAPACITY_USAGE", value);
       }
   }
 
  [DataMember]
  //EWM-CW：计量单位的类别
  public string EwmCwUomType
  {
      get
      {
          return base.GetProperty<string>("EWM_CW_UOM_TYPE");
       }
       set
       {
          base.SetProperty("EWM_CW_UOM_TYPE", value);
       }
   }
 
   }
}


