using System;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace model_training
{
    public class InputData
    {
        [LoadColumn(0)]
        public string Text { get; set; }

        [LoadColumn(1)]
        public string Label { get; set; }
    }
    public class LyDoPrediction
    {
        [ColumnName("PredictedLabel")] public string PredictedLabel;
        public float[] Score;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Khởi tạo MLContext
            var context = new MLContext();

            // 2. Đọc dữ liệu
            var data = context.Data.LoadFromTextFile<InputData>(path: "data.tsv", hasHeader: true, separatorChar: '\t');

            // 3. Tiền xử lý và pipeline
            var pipeline = context.Transforms.Conversion.MapValueToKey("Label")
                .Append(context.Transforms.Text.FeaturizeText("Features", "Text"))
                .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label"))
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // 4. Train mô hình
            var model = pipeline.Fit(data);

            // 5. Lưu model
            context.Model.Save(model, data.Schema, "model.zip");

            Console.WriteLine("Đã huấn luyện và lưu mô hình vào model.zip");
            Console.WriteLine("Working directory: " + Environment.CurrentDirectory);

        }
    }
}
