using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurigmaTestProject
{
    using Aurigma.GraphicsMill;
    using Aurigma.GraphicsMill.Codecs;
    using Aurigma.GraphicsMill.Transforms;

    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = args[0];

            using (var reader = ImageReader.Create(sourceFilePath))
            {
                var tempFileName = "file.tmp";

                using (var writer = ImageWriter.Create(reader.FileFormat, tempFileName))
                using (var frame = reader.Frames.First())
                {
                    var pipeline = new Pipeline(frame);

                    pipeline.Add(new Resize(100,100));
                    pipeline.Add(writer);
                    pipeline.Run();
                    pipeline.DisposeAllElements();
                }
            }
        }
    }
}
