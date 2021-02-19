using CritterController;
using System;
using System.IO;


namespace b100455312
{
    public class Bladee : ICritterController
    {
        public string Name { get; set; }

        public Send Responder { get; set; }

        public Send Logger { get; set; }

        public int eatSpeed { get; set; } = 10;

        public int HeadForExitSpeed { get; set; } = 10;

        public string Filepath { get; set; }

        private void Log(string message)
        {
            if (Logger == null)
            {
                Console.WriteLine(message);
            }
            else
            {
                Logger(message);
            }
        }

        public void SaveSettings()
        {
            string fileName = "Bladee.cfg";
            string fileSpec = Filepath + "/" + fileName;
            try
            {
                using (StreamWriter writer = new StreamWriter(fileSpec, false))
                {
                    writer.WriteLine("EatSpeed=" + EatSpeed);
                    writer.WriteLine("HeadForExitSpeed=" + HeadForExitSpeed);
                }
            }
            catch (Exception e)
            {
                Log("Writing configuration " + fileSpec + " failed due to " + e);
            }
        }

        public Bladee(string name)
        {
            Name = name;
        }

        public void LaunchUI()
        {
            BladeeSettings settings = new BladeeSettings(this);
            settings.Show();
            settings.Focus();
        }

        public void Receive(string message)
        {
            Log("Message from body for " + Name + ": " + message);
            string[] msgParts = message.Split(':');
            string notification = msgParts[0];
            switch (notification)
            {
                case "LAUNCH":
                case "REACHED_DESTINATION":
                case "FIGHT":
                case "BUMP":
                    Responder("RANDOM_DESTINATION");
                    break;
                case "ERROR":
                    Log(message);
                    break;
            }
        }
    }
}
