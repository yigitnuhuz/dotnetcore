using System.Device.Gpio;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_onlineled.Controllers
{
    public class LedController : Controller
    {
        //led'i bağladığımız pin numarasını veriyoruz. 
        private const int LedPin = 17;
        private readonly GpioController _gpioController;

        //constructor tanımlayıp burada pin yöneticimizi ve kullanacağımız pini tanımlıyoruz
        public LedController()
        {
            _gpioController = new GpioController();
            //verilen pini çıktı verecek şekilde tanımlıyoruz.
            _gpioController.OpenPin(LedPin, PinMode.Output);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LedAc()
        {
            //verilmiş olan pini voltaj verecek şekilde değiştiriyoruz
            _gpioController.Write(LedPin, PinValue.High);
            //kullanıcıya bilgi vermek için bir mesaj yazıyoruz.
            ViewBag.LedDurumu = "Led Açık!";

            return View("Index");
        }

        public IActionResult LedKapat()
        {
            //verilmiş olan pini voltajı kesecek şekilde değiştiriyoruz
            _gpioController.Write(LedPin, PinValue.Low);
            //kullanıcıya bilgi vermek için bir mesaj yazıyoruz.
            ViewBag.LedDurumu = "Led Kapalı!";

            return View("Index");
        }
    }
}