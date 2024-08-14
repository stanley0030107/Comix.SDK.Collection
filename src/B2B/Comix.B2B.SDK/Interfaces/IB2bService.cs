using Comix.B2B.SDK.Entities;

namespace Comix.B2B.SDK.Interfaces
{
    public interface IB2bService
    {
        Task<MsEnterprise> GetByCodeAsync(string code);

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderCode"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        Task<int> UpdateOrderStatusAsync(List<string> orderCode, int orderStatus);

        /// <summary>
        /// 审批订单通过
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        Task<string> ApproveOrder(string orderCode);
    }
}