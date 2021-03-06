using System;

namespace Level_B
{
    class Program
    {
        static int res = 0;
        static int res2 = 0;
        static int minCoins(int[] coins, int length, int targetNumber)
        {
            if (targetNumber == 0) return 0;
            
            for (int i = 0; i < length; i++)
            {
                if (coins[i] <= targetNumber)
                {                    
                    minCoins(coins, length, targetNumber - coins[i]);
                    return res++;
                }
                else if(coins[i] - targetNumber < coins[i+1])
                {
                    // salesman returning the change here...
                    minCoins(coins, length, coins[i] - targetNumber);
                    return res++;
                }
            }
            return res;
        }


        static int minCoins2(int[] coins, int length, int targetNumber)
        {
            if (targetNumber == 0) return 0;

            for (int i = 0; i < length; i++)
            {
                if (coins[i] <= targetNumber)
                {
                    minCoins2(coins, length, targetNumber - coins[i]);
                    return res2++;
                }
                //suppose intput is 368 , then i will give 500 and then ask for the change...| i will not giving 100 3 times and the 50,10,5,1,1,1 
                // it will take much more transection than the first one
                else if ((coins[i] - targetNumber ) +10 < (coins[i]/2))
                {
                     // salesman returning the change here...
                    minCoins2(coins, length, coins[i] - targetNumber);
                    return res2++;
                }
            }
            return res2;
        }

         
        public static void Main()
        {
            int[] coins = {500,100,50,10,5,1};
            int coinsLength = coins.Length;
            int V = Convert.ToInt32(Console.ReadLine());
            int result1 = (minCoins(coins, coinsLength, V));
            int result2 = (minCoins2(coins, coinsLength, V));
            Console.Write("Minimum coins required is " + ((result1 < result2 ? result1 : result2)+1));
            Console.ReadKey();
        }
    }
}
