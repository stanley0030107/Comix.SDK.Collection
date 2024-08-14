using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.COS.SDK.Interfaces
{
    public interface ICosMessageListService
    {
        Task<string> GetCosMessagePacketAsync(PacketListCosRoot packetListCos);

        Task<List<Rootobject>> GetCosMessagePacketModelListAsync(PacketListCosRoot packetListCos);
    }
}
