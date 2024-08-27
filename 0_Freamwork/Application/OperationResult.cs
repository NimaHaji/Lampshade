using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Freamwork.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public OperationResult()
        {
            IsSuccedded = false;
        }
        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            Message = message;
            IsSuccedded = true;
            return this;
        }
        public OperationResult Failed(string message)
        {
            Message = message;
            IsSuccedded = false;
            return this;
        }
    }
}
