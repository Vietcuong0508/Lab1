using System.Collections.Generic;

namespace HiTrader
{
    public interface ITradeAction
    {
        List<Coin> GetTickers();
    }
}