using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class MoneyBox
    {
        decimal money;
        public MoneyBox()
        {
            money = 300;
        }
        public void AddMoney(decimal cash)
        {
            money = money + cash;
        }
    }
}
