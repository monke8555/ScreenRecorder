using System;
using Captura;
using System.IO;

namespace ConsoleApp {
    class Program {
        static int Main() {
            try {
                int fps;
                Console.Write("FPS (30 by default): ");
                if (!int.TryParse(Console.ReadLine(), out fps)) {
                    fps = 30;
                }
                int quality;
                Console.Write("Quality (50 by default) (1 (low quality, small size) to 100 (high quality, large size)): ");
                if (!int.TryParse(Console.ReadLine(), out quality)) {
                    quality = 50;
                }
                var user = Environment.GetEnvironmentVariable("USERPROFILE"); ;
                var file = $@"{user}\Desktop\recording.avi";
                Console.Write($@"File ({user}\Desktop\recording.avi by default): ");
                var line = Console.ReadLine();
                if (line.Contains(@":\")) {
                    file = line;
                }
                var rec = new Recorder(new RecorderParams(file, fps, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, quality));
                Console.WriteLine("Press any key to stop recording...");
                Console.ReadKey();
                // Finish Writing
                rec.Dispose();

            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return -1;
            }
            return 0;
        }
    }
}