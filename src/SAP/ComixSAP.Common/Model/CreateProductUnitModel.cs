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
  //�����浥λ�Ŀ�ѡ������λ 
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
  //ISO�����д洢���ֵĿ�ѡ������λ 
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
  //����������λת������
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
  //ת��Ϊ����������λ�ķ�ĸ
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
  //�����ļ���(EAN/UPC)
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
  //������Ʒ�������� (EAN)
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
  //����
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
  //���
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
  //�߶�
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
  //����/���/�߶ȵĳߴ絥λ 
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
  //��ISO�����й��ڳ���/���/�߶ȵĵ�λ 
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
  //ҵ���� 
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
  //�����λ
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
  //��ISO�����е������λ
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
  //ë��
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
  //������λ
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
  //��ISO�����еļ�Ȩ��λ
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
  //ɾ�����ݼ���(���ظ�����)
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
  //��װ����еĵͲ������λ
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
  //ISO �����еĵͼ�������λ
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
  //ȫ��ó����Ŀ��ű�ʽ
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
  //��װ���ʣ�����(�ٷֱ�)
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
  //���ռ��ϵ�� 
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
  //����ʹ��
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
  //EWM-CW��������λ�����
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


