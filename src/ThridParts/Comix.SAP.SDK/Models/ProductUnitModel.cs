using System.Runtime.Serialization;

namespace Comix.SAP.SDK.Models;

[DataContract]
public class ProductUnitModel
{
    /// <summary>
    /// 帐面库存单位的可选计量单位_PCS_是
    /// </summary>
    private string _ALT_UNIT = "";

    public string ALT_UNIT
    {
        get { return _ALT_UNIT; }
        set { _ALT_UNIT = value; }
    }

    /// <summary>
    /// ISO代码中存储保持的可选度量单位__否
    /// </summary>
    private string _ALT_UNIT_ISO = "";

    public string ALT_UNIT_ISO
    {
        get { return _ALT_UNIT_ISO; }
        set { _ALT_UNIT_ISO = value; }
    }

    /// <summary>
    /// 基本计量单位转换分子_1_是
    /// </summary>
    private string _NUMERATOR = "";

    public string NUMERATOR
    {
        get { return _NUMERATOR; }
        set { _NUMERATOR = value; }
    }

    /// <summary>
    /// 转换为基本计量单位的分母_1_是
    /// </summary>
    private string _DENOMINATR = "";

    public string DENOMINATR
    {
        get { return _DENOMINATR; }
        set { _DENOMINATR = value; }
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
    /// 国际商品编码的类别 (EAN)__否
    /// </summary>
    private string _EAN_CAT = "";

    public string EAN_CAT
    {
        get { return _EAN_CAT; }
        set { _EAN_CAT = value; }
    }

    /// <summary>
    /// 长度__否
    /// </summary>
    private string _LENGTH = "";

    public string LENGTH
    {
        get { return _LENGTH; }
        set { _LENGTH = value; }
    }

    /// <summary>
    /// 宽度__否
    /// </summary>
    private string _WIDTH = "";

    public string WIDTH
    {
        get { return _WIDTH; }
        set { _WIDTH = value; }
    }

    /// <summary>
    /// 高度__否
    /// </summary>
    private string _HEIGHT = "";

    public string HEIGHT
    {
        get { return _HEIGHT; }
        set { _HEIGHT = value; }
    }

    /// <summary>
    /// 长度/宽度/高度的尺寸单位__否
    /// </summary>
    private string _UNIT_DIM = "";

    public string UNIT_DIM
    {
        get { return _UNIT_DIM; }
        set { _UNIT_DIM = value; }
    }

    /// <summary>
    /// 在ISO代码中关于长度/宽度/高度的单位__否
    /// </summary>
    private string _UNIT_DIM_ISO = "";

    public string UNIT_DIM_ISO
    {
        get { return _UNIT_DIM_ISO; }
        set { _UNIT_DIM_ISO = value; }
    }

    /// <summary>
    /// 业务量__否
    /// </summary>
    private string _VOLUME = "";

    public string VOLUME
    {
        get { return _VOLUME; }
        set { _VOLUME = value; }
    }

    /// <summary>
    /// 体积单位__否
    /// </summary>
    private string _VOLUMEUNIT = "";

    public string VOLUMEUNIT
    {
        get { return _VOLUMEUNIT; }
        set { _VOLUMEUNIT = value; }
    }

    /// <summary>
    /// 在ISO代码中的体积单位__否
    /// </summary>
    private string _VOLUMEUNIT_ISO = "";

    public string VOLUMEUNIT_ISO
    {
        get { return _VOLUMEUNIT_ISO; }
        set { _VOLUMEUNIT_ISO = value; }
    }

    /// <summary>
    /// 毛重__否
    /// </summary>
    private string _GROSS_WT = "";

    public string GROSS_WT
    {
        get { return _GROSS_WT; }
        set { _GROSS_WT = value; }
    }

    /// <summary>
    /// 重量单位__否
    /// </summary>
    private string _UNIT_OF_WT = "";

    public string UNIT_OF_WT
    {
        get { return _UNIT_OF_WT; }
        set { _UNIT_OF_WT = value; }
    }

    /// <summary>
    /// 在ISO代码中的加权单位__否
    /// </summary>
    private string _UNIT_OF_WT_ISO = "";

    public string UNIT_OF_WT_ISO
    {
        get { return _UNIT_OF_WT_ISO; }
        set { _UNIT_OF_WT_ISO = value; }
    }

    /// <summary>
    /// 删除数据计量(在重复表中)__否
    /// </summary>
    private string _DEL_FLAG = "";

    public string DEL_FLAG
    {
        get { return _DEL_FLAG; }
        set { _DEL_FLAG = value; }
    }

    /// <summary>
    /// 包装层次中的低层计量单位__否
    /// </summary>
    private string _SUB_UOM = "";

    public string SUB_UOM
    {
        get { return _SUB_UOM; }
        set { _SUB_UOM = value; }
    }

    /// <summary>
    /// ISO 代码中的低级计量单位__否
    /// </summary>
    private string _SUB_UOM_ISO = "";

    public string SUB_UOM_ISO
    {
        get { return _SUB_UOM_ISO; }
        set { _SUB_UOM_ISO = value; }
    }

    /// <summary>
    /// 全球贸易项目编号变式__否
    /// </summary>
    private string _GTIN_VARIANT = "";

    public string GTIN_VARIANT
    {
        get { return _GTIN_VARIANT; }
        set { _GTIN_VARIANT = value; }
    }

    /// <summary>
    /// 套装后的剩余体积(百分比)__否
    /// </summary>
    private string _NESTING_FACTOR = "";

    public string NESTING_FACTOR
    {
        get { return _NESTING_FACTOR; }
        set { _NESTING_FACTOR = value; }
    }

    /// <summary>
    /// 最大占空系数__否
    /// </summary>
    private string _MAXIMUM_STACKING = "";

    public string MAXIMUM_STACKING
    {
        get { return _MAXIMUM_STACKING; }
        set { _MAXIMUM_STACKING = value; }
    }

    /// <summary>
    /// 能力使用__否
    /// </summary>
    private string _CAPACITY_USAGE = "";

    public string CAPACITY_USAGE
    {
        get { return _CAPACITY_USAGE; }
        set { _CAPACITY_USAGE = value; }
    }

    /// <summary>
    /// EWM-CW：计量单位的类别__否
    /// </summary>
    private string _EWM_CW_UOM_TYPE = "";

    public string EWM_CW_UOM_TYPE
    {
        get { return _EWM_CW_UOM_TYPE; }
        set { _EWM_CW_UOM_TYPE = value; }
    }
}