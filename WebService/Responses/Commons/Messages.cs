using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Responses.Commons
{
    public static class Messages
    {
        public static string SuccessOperation = "Uğurlu əməliyyat";
        public static string FailedOperation = "Uğursuz əməliyyat";
        public static string CarExists = "Bu maşın artıq qeydiyyatdan keçmişdir";
        public static string CarBusy = "Bu maşın hal-hazırda başqa yerdə park edilmişdir";
        public static string LoginFailed = "E-mail və ya şifrə yanlışdır";
        public static string OrderFailed = "Parkinq slotları doludur";
    }
}