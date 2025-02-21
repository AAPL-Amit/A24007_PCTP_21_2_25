using System;
using System.Threading;

namespace SCADATrends
{
    public class TrendTime
    {
        private int day = 0;
        private int hour = 0;
        private int minute = 0;
        private int second = 0;
        private int millisecond = 0;

        private readonly Timer timer;

        public TrendTime()
        {
            // Create a timer that triggers every 1 millisecond
            timer = new Timer(UpdateTime, null, 0, 1); // 1 ms interval
        }

        // Method to update time values every millisecond
        private void UpdateTime(object state)
        {
            millisecond++;

            if (millisecond >= 1000)
            {
                millisecond = 0;
                second++;

                if (second >= 60)
                {
                    second = 0;
                    minute++;

                    if (minute >= 60)
                    {
                        minute = 0;
                        hour++;

                        if (hour >= 24)
                        {
                            hour = 0;
                            day++;
                        }
                    }
                }
            }
        }

        // Method to get the current time in the format Day:Hour:Minute:Second:Millisecond
        public string GetFormattedTime()
        {
            // Correctly format the time string
            return string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}:{4:D3}", day, hour, minute, second, millisecond);
        }

        // Stop the timer when you're done
        public void Stop()
        {
            timer.Dispose();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TrendTime trendTime = new TrendTime();

            // To simulate and display the time trend for 5 seconds
            for (int i = 0; i < 5000; i++)
            {
                // Get the formatted time
                Console.Clear();
                Console.WriteLine(trendTime.GetFormattedTime());
                Thread.Sleep(1); // Delay for 1ms
            }

            // Stop the trend time tracking
            trendTime.Stop();
            Console.WriteLine("Trend tracking stopped.");
        }
    }
}
