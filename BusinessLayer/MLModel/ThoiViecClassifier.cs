using System;
using System.IO;
using Microsoft.ML;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer.MLModel
{
    public class ThoiViecClassifier
    {
        private readonly PredictionEngine<InputData, LyDoPrediction> _predEngine;

        public ThoiViecClassifier()
        {
            var ml = new MLContext();

            // Đường dẫn tuyệt đối đến mô hình trong thư mục output
            //string modelPath = Path.Combine(
            //    AppDomain.CurrentDomain.BaseDirectory,   // bin\Debug\net8.0\
            //    "MLModels",                              // thư mục chứa model
            //    "model_training.zip");                   // tên file

            string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "model.zip");


            FileStream stream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var model = ml.Model.Load(stream, out _);
            stream.Dispose();  // Đóng stream thủ công
            _predEngine = ml.Model.CreatePredictionEngine<InputData, LyDoPrediction>(model);

        }
        public string Predict(string lyDo)
        {
            var input = new InputData { Text = lyDo, Label = "" }; // gán rỗng hoặc null cho Label

            return _predEngine.Predict(input).PredictedLabel;   // “CaNhan”, “CongViec”, “MauThuan”
        }

        // Khai báo class phụ trợ
        public class InputData { 
            public string Text { get; set; }
            public string Label { get; set; }
        }
        public class LyDoPrediction { public string PredictedLabel { get; set; } }
    }
}
