using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoOnline.Utility
{
    public class GenerateCards
    {
        public List<int> ReturnCardsArray()
        {
            List<int> UtilizedNumbers = new List<int>();
            List<int> ReturnList = new List<int>();
            int temp = 0;
            Random random = new Random();

            try
            {

                while (ReturnList.Count != 15)
                {
                    temp = random.Next(1, 101);

                    if (UtilizedNumbers.Contains(temp))
                        continue;

                    UtilizedNumbers.Add(temp);
                    ReturnList.Add(temp);
                }

                ReturnList = ReturnList.OrderBy(x => x).ToList();
                return ReturnList;
            }
            finally
            {
                if (ReturnList != null)
                    ReturnList = null;

                if (UtilizedNumbers != null)
                    UtilizedNumbers = null;

                if (random != null)
                    random = null;
            }
        }
    }
}