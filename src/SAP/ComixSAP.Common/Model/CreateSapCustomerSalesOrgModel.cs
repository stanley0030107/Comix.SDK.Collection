using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ComixSAP.Common;
using ComixSAP.Common.SAP;

namespace ComixSAP.Common.Model
{
    [DataContract]
    public class CreateSapCustomerSalesOrgModel : SapModelBase
    {
        public override void SetFieldNames()
        {
            this.PropertyNames = new List<string> { 
           "MESSAGEID","KUNNR_001","BUKRS_002","VKORG_003","VTWEG_004","KTOKD_006","SPART_005","REF_KUNNR_007","REF_BUKRS_008","REF_VKORG_009","REF_VTWEG_010","REF_SPART_011","ZTERM_013","BZIRK_014","VKBUR_016","VKGRP_017","KDGRP_018","WAERS_019","VWERK_026"};
        }

        [DataMember]
        //��ˮ��
        public string Messageid
        {
            get
            {
                return base.GetProperty<string>("MESSAGEID");
            }
            set
            {
                base.SetProperty("MESSAGEID", value);
            }
        }

        [DataMember]
        //�ͻ����1
        public string Kunnr001
        {
            get
            {
                return base.GetProperty<string>("KUNNR_001");
            }
            set
            {
                base.SetProperty("KUNNR_001", value);
            }
        }

        [DataMember]
        //��˾����
        public string Bukrs002
        {
            get
            {
                return base.GetProperty<string>("BUKRS_002");
            }
            set
            {
                base.SetProperty("BUKRS_002", value);
            }
        }

        [DataMember]
        //������֯
        public string Vkorg003
        {
            get
            {
                return base.GetProperty<string>("VKORG_003");
            }
            set
            {
                base.SetProperty("VKORG_003", value);
            }
        }

        [DataMember]
        //��������
        public string Vtweg004
        {
            get
            {
                return base.GetProperty<string>("VTWEG_004");
            }
            set
            {
                base.SetProperty("VTWEG_004", value);
            }
        }

        [DataMember]
        //�ͻ��ʻ���
        public string Ktokd006
        {
            get
            {
                return base.GetProperty<string>("KTOKD_006");
            }
            set
            {
                base.SetProperty("KTOKD_006", value);
            }
        }

        [DataMember]
        //��Ʒ��
        public string Spart005
        {
            get
            {
                return base.GetProperty<string>("SPART_005");
            }
            set
            {
                base.SetProperty("SPART_005", value);
            }
        }

        [DataMember]
        //�ͻ����1
        public string RefKunnr007
        {
            get
            {
                return base.GetProperty<string>("REF_KUNNR_007");
            }
            set
            {
                base.SetProperty("REF_KUNNR_007", value);
            }
        }

        [DataMember]
        //��˾����
        public string RefBukrs008
        {
            get
            {
                return base.GetProperty<string>("REF_BUKRS_008");
            }
            set
            {
                base.SetProperty("REF_BUKRS_008", value);
            }
        }

        [DataMember]
        //������֯
        public string RefVkorg009
        {
            get
            {
                return base.GetProperty<string>("REF_VKORG_009");
            }
            set
            {
                base.SetProperty("REF_VKORG_009", value);
            }
        }

        [DataMember]
        //��������
        public string RefVtweg010
        {
            get
            {
                return base.GetProperty<string>("REF_VTWEG_010");
            }
            set
            {
                base.SetProperty("REF_VTWEG_010", value);
            }
        }

        [DataMember]
        //��Ʒ��
        public string RefSpart011
        {
            get
            {
                return base.GetProperty<string>("REF_SPART_011");
            }
            set
            {
                base.SetProperty("REF_SPART_011", value);
            }
        }

        [DataMember]
        //������������
        public string Zterm013
        {
            get
            {
                return base.GetProperty<string>("ZTERM_013");
            }
            set
            {
                base.SetProperty("ZTERM_013", value);
            }
        }

        [DataMember]
        //���۵���
        public string Bzirk014
        {
            get
            {
                return base.GetProperty<string>("BZIRK_014");
            }
            set
            {
                base.SetProperty("BZIRK_014", value);
            }
        }

        [DataMember]
        //���۲���
        public string Vkbur016
        {
            get
            {
                return base.GetProperty<string>("VKBUR_016");
            }
            set
            {
                base.SetProperty("VKBUR_016", value);
            }
        }

        [DataMember]
        //������
        public string Vkgrp017
        {
            get
            {
                return base.GetProperty<string>("VKGRP_017");
            }
            set
            {
                base.SetProperty("VKGRP_017", value);
            }
        }

        [DataMember]
        //�ͻ���
        public string Kdgrp018
        {
            get
            {
                return base.GetProperty<string>("KDGRP_018");
            }
            set
            {
                base.SetProperty("KDGRP_018", value);
            }
        }

        [DataMember]
        //������
        public string Waers019
        {
            get
            {
                return base.GetProperty<string>("WAERS_019");
            }
            set
            {
                base.SetProperty("WAERS_019", value);
            }
        }

        [DataMember]
        //����
        public string Vwerk026
        {
            get
            {
                return base.GetProperty<string>("VWERK_026");
            }
            set
            {
                base.SetProperty("VWERK_026", value);
            }
        }

    }
}


