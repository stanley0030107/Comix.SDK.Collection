using System.Collections.Generic;

namespace Comix.COS.Model.RespModels
{
    public class CosBranchPageDto
    {
        /// <summary>
        /// 齐心品牌编码
        /// </summary>
        public string brandCode { get; set; }

        /// <summary>
        /// 齐心品牌名称
        /// </summary>
        public string brandName { get; set; }

        /// <summary>
        /// 品牌媒体
        /// </summary>
        public List<MediaResDto> mediaList { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the brand.
        /// </summary>
        public int createUserId { get; set; }

        /// <summary>
        /// Gets or sets the brand ID.
        /// </summary>
        public string brandId { get; set; }

        /// <summary>
        /// Gets or sets the brand name in Chinese.
        /// </summary>
        public string brandNameZh { get; set; }

        /// <summary>
        /// Gets or sets the brand name in English.
        /// </summary>
        public string brandNameEn { get; set; }

        /// <summary>
        /// Gets or sets the SAP code for the brand.
        /// </summary>
        public string sapCode { get; set; }

        /// <summary>
        /// Gets or sets the status of the brand.
        /// </summary>
        public int brandStatus { get; set; }

        /// <summary>
        /// Gets or sets the type of control for the brand.
        /// </summary>
        public int controlType { get; set; }

        /// <summary>
        /// Gets or sets the order sequence for the brand.
        /// </summary>
        public int orderSequence { get; set; }

        /// <summary>
        /// Gets or sets whether the operation was successful.
        /// </summary>
        public bool successStatus { get; set; }

        /// <summary>
        /// Gets or sets the types of qualifications for the brand.
        /// </summary>
        public List<string> qualificationTypes { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who created the brand.
        /// </summary>
        public string createUsername { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who updated the brand.
        /// </summary>
        public int updateUserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who updated the brand.
        /// </summary>
        public string updateUsername { get; set; }

        /// <summary>
        /// Gets or sets the creation time of the brand.
        /// </summary>
        public int createTime { get; set; }

        /// <summary>
        /// Gets or sets the update time of the brand.
        /// </summary>
        public int updateTime { get; set; }
    }

    /// <summary>
    /// 品牌媒体
    /// </summary>
    public class MediaResDto
    {
        /// <summary>
        /// Gets or sets the media ID.
        /// </summary>
        public int mediaId { get; set; }

        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        public int entityId { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        public int serialNum { get; set; }

        /// <summary>
        /// Gets or sets the media URL.
        /// </summary>
        public string mediaUrl { get; set; }

        /// <summary>
        /// Gets or sets the entity type code.
        /// </summary>
        public string entityTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the media type code.
        /// </summary>
        public string mediaTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the qualification type.
        /// </summary>
        public string qualificationType { get; set; }
    }
}