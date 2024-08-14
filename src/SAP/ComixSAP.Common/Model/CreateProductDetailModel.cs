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
  //���Ϻ� 
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
  //����������λ
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
  //�ɹ������ļ�����λ 
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
  //��������
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
  //�ĵ������(���ĵ�����ϵͳ)
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
  //���ι�������ı�ʶ
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
  //���кŵ������ļ��� 
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
  //�����������ļ�����Ŀ����� 
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
  //�����õ�����
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
  //������ 
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
  //�����Ϻ�
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
  //�ⲿ������ 
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
  //��Ʒ�� 
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
  //ʵ����/����� 
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
  //��������¼��ҳ��ʽ 
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
  //����/���鱸��¼
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
  //�洢����
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
  //������ 
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
  //��ҵ��׼���������� ANSI �� ISO�� 
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
  //��Ʒ���
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
  //��Ʒ����ȷ������
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
  //ë��
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
  //������λ
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
  //���� 
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
  //��С/����
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
  //��������
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
  //����
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
  //�ɹ��� 
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
  //��������ƻ����� 
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
  //MRP �����ߣ����ϼƻ��ˣ�
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
  //�ƻ��������ڽ���
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
  //����Ƶ��ջ�����ʱ��
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
  //�ڼ��ʶ
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
  //��ʶ��ɢװ���� 
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
  //����ģʽ 
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
  //�����ڼ�:����
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
  //����ʱ��-��ǰ
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
  //�滻����
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
  //��װ�����й������ƻ��Ļ�׼���� 
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
  //����ʱ��: װ��
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
  //װ�˽���ʱ��
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
  //���кŲ����ļ� 
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
  //���� (���ϼƻ�)
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
  //�ɹ�����
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
  //����ɹ�����
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
  //��ȫ���
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
  //��С���� 
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
  //���������С 
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
  //�̶�������С
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
  //�ɹ���������������ֵ 
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
  //���ڶ����ͼ����������������ʶ 
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
  //������Ʒ�ٷ��� 
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
  //ѡ����滻���ϵ��ķ��� 
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
  //�ۺ�MRP��ʶ
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
  //�����ļƻ��߼���
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
  //��ʶ������ 
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
  //��������Ա 
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
  //��������ʱ��
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
  //�ܼƲ�����ǰʱ��(��������)
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
  //�������
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
  //װ���� 
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
  //������ʹ��
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
  //�����Լ��ļ����
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
  //��������
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
  //�ƻ�����
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
  //�������ص�
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
  //��������ƻ���
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
  //������ 
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
  //�ƻ������� 
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
  //�ⲿ�ɹ���ȱʡ�ִ�λ�� 
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
  //��������˳����
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
  //�����ض�������״̬ 
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
  //�����ƻ������ļ�
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
  //�޳ɱ����� 
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
  //��ʶ: "�����Զ��ɹ�����"
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
  //��ʶ: Դ�嵥Ҫ�� 
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
  //�ƻ���ʱ�� 
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
  //��ȫʱ�䣨�������ռ��㣩
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
  //װ�䱨�ϰٷֱ� 
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
  //��־���ؼ����� 
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
  //��ȫʱ���ʶ�����򲻺���ȫʱ�䣩
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
  //�������������
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
  //���������� 
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
  //����/���������� 
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
  //��ó����Ʒ����ͽ��ڴ���
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
  //����ԭ���ع��� 
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
  //����ԭ���أ����ػݻ�Դ��
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
  //�۸����ָʾ�� 
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
  //�۸�λ
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
  //��׼�۸�
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
  //������ 
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
  //�ƶ�ƽ���۸�/���ڵ���
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
  //��Ϊ�ɱ�Ҫ�������ԭʼ��
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
  //�ɱ������ӷ����� 
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
  //������ص�Դ
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
  //���ϸ��������ṹ���гɱ�����
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
  //���ϼ۸�ȷ��: ����
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
  //ͳ���� 
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
  //���϶����� 
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
  //�����ϵĿ�Ŀ������ 
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
  //��������
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
  //������֯ 
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
  //��������
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
  //�����������ļ�����Ŀ����� 
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
  //���ص�
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
  //�������������ı��� 
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
  //���ϵ�˰����
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
         //˰�������
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
  //�����浥λ�Ŀ�ѡ������λ 
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
  //����������λת������
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
  //ת��Ϊ����������λ�ķ�ĸ
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
  //ҵ���� 
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
  //�����λ
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


