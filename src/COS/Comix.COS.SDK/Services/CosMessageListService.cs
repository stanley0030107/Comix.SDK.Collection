using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comix.COS.SDK.Services
{
    public class CosMessageListService: ICosMessageListService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CosMessageListService> _logger;

        public CosMessageListService(IHttpClientFactory httpClientFactory, ILogger<CosMessageListService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        /// <summary>
        /// Cos服务化接口
        /// 根据事件数据查询集合数据
        /// </summary>
        /// <param name="packetListCos">事件类</param>
        /// <returns></returns>
        public async Task<string> GetCosMessagePacketAsync(PacketListCosRoot packetListCos)
        {
            var resp = await _httpClientFactory.ExecuteReturnStringAsync(_logger,
                COSRoute.ApiCosMessagePacketList, packetListCos);
            return resp;
        }

        /// <summary>
        /// Cos服务化接口
        /// 根据事件数据查询集合数据
        /// </summary>
        /// <param name="packetListCos">事件类</param>
        /// <returns></returns>
        public async Task<List<Rootobject>> GetCosMessagePacketModelListAsync(PacketListCosRoot packetListCos)
        {
            var resp = await _httpClientFactory.ExecuteAsync<List<Rootobject>>(_logger,
                COSRoute.ApiCosMessagePacketList, packetListCos);
            return resp;
        }
    }
}
