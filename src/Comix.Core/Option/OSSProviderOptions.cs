using OnceMi.AspNetCore.OSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Option
{
    /// <summary>
    /// 对象存储配置选项
    /// </summary>
    public sealed class OSSProviderOptions : OSSOptions, IConfigurableOptions
    {
        /// <summary>
        /// 自定义桶名称 不能直接使用Provider来替代桶名称
        /// 例：阿里云 1.只能包括小写字母，数字，短横线（-）2.必须以小写字母或者数字开头 3.长度必须在3-63字节之间
        /// </summary>
        public string Bucket { get; set; }
        /// <summary>
        /// 根目录：生产和测试用同一个OSS时，测试加dev/开始标识
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// 获取OSS访问地址
        /// </summary>
        /// <returns></returns>
        public string GetHostUrl()
        {
            var Url = "";
            switch (Provider)
            {
                case OSSProvider.Aliyun:
                    Url = $"{(IsEnableHttps ? "https" : "http")}://{Bucket}.{Endpoint}/";
                    break;

                case OSSProvider.Minio:
                    // 获取Minio文件的下载或者预览地址
                    // newFile.Url = await GetMinioPreviewFileUrl(newFile.BucketName, filePath);// 这种方法生成的Url是有7天有效期的，不能这样使用
                    // 需要在MinIO中的Buckets开通对 Anonymous 的readonly权限
                    Url = $"{(IsEnableHttps ? "https" : "http")}://{Endpoint}/{Bucket}/";
                    break;
            }

            return Url;
        }
    }
}
