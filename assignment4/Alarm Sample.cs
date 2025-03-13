namespace _3_13C__2
{
    internal class AlarmSample
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            //set the begin time
            int startMinute = 0;
            int startSecond = 0;

            //set the alarm time
            int alarmMinute = 0;
            int alarmSecond = 5;

            // start the clock
            clock.Start(startMinute, startSecond, alarmMinute, alarmSecond);
        }
    }
    public delegate void AlarmSystem(object sender, AlarmEventArgs args);
    public class AlarmEventArgs { 
        public int Second {  get; set; }
        public int Minute { get; set; }
        public int SetSecond { get; set; }
        public int SetMinute {  get; set; }
    }
    public class Alarm
    {
        public event AlarmSystem OnTick;
        public event AlarmSystem OnAlarm;
        public void Tick(int x,int y)
        {
            Console.WriteLine($"the clock begins at {x}:{y}");
            AlarmEventArgs args = new AlarmEventArgs()
            {
                Second = y,
                Minute = x
            };
            OnTick(this, args);
        }
        public void MyAlarm(int x, int y)
        {
            Console.WriteLine($"the alarm time is {x}:{y}");
            AlarmEventArgs args = new AlarmEventArgs()
            {
                SetSecond = y,
                SetMinute = x
            };
            OnAlarm(this, args);
        }

    }
    public class Clock
    {
        public Alarm alarm=new Alarm();
        public Clock() {
            alarm.OnTick += new AlarmSystem(My_OnTick);
            alarm.OnAlarm += My_OnAlarm;
        }
        void My_OnTick(object sender,AlarmEventArgs args)
        {
            Console.WriteLine($"Tick... Current Time: {args.Minute:00}:{args.Second:00}");
        }
        void My_OnAlarm(object sender, AlarmEventArgs args)
        {
            Console.WriteLine($"Alarm! Time's up! Current Time: {args.SetMinute:00}:{args.SetSecond:00}");
        }
        public void Start(int startMinute, int startSecond, int alarmMinute, int alarmSecond)
        {
            int currentMinute = startMinute;
            int currentSecond = startSecond;

            Console.WriteLine($"start..  Current Time: {currentMinute:00}:{currentSecond:00}");
            Console.WriteLine($"The alarm time : {alarmMinute:00}:{alarmSecond:00}");

            while (true)
            {
                
                if (currentMinute == alarmMinute && currentSecond == alarmSecond)
                {
                    alarm.MyAlarm(currentMinute, currentSecond);
                    break; 
                }

                
                alarm.Tick(currentMinute, currentSecond);

                
                Thread.Sleep(1000); 
                currentSecond++;

                
                if (currentSecond >= 60)
                {
                    currentSecond = 0;
                    currentMinute++;
                }
            }
        }
    }
}
