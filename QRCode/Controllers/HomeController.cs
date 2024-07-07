using QRCode.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static QRCoder.PayloadGenerator;
using System.Web.Mvc;

namespace QRCode.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult CreateQRCode()
        {
            return View(new QRCodeModel());
        }
        [HttpPost]
        public ActionResult CreateQRCode(QRCodeModel qRCodeModel)
        {
            Payload payload = new Url(qRCodeModel.QRCodeText);
            QRCodeGenerator codeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = codeGenerator.CreateQrCode(payload);
            QRCoder.PngByteQRCode pngByte = new PngByteQRCode(qRCodeData);
            var QrByte = pngByte.GetGraphic(20);
            string base64Url = Convert.ToBase64String(QrByte);
            qRCodeModel.QRImageUrl = "data:image/png;base64," + base64Url;
            return View("CreateQRCode",qRCodeModel);

        }
    }
}