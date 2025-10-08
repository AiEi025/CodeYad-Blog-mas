using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Utilities
{
    public class OperationResult
    {
        public string Messsage { get; set; }
        public OperationResultStatus Status { get; set; }
        public static OperationResult Error()
        {
            return new OperationResult
            {
                Messsage = "عملیات ناموفق",
                Status = OperationResultStatus.Error
            };
        }
        public static OperationResult Success()
        {
            return new OperationResult
            {
                Messsage = "عملیات موفق",
                Status = OperationResultStatus.Success
            };
        }
        public static OperationResult NotFound()
        {
            return new OperationResult
            {
                Messsage = "مورد پیدا نشد",
                Status = OperationResultStatus.NotFound
            };
        }
        public static OperationResult Error(string message)
        {
            return new OperationResult
            {
                Messsage = message,
                Status = OperationResultStatus.Error
            };
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult
            {
                Messsage = message,
                Status = OperationResultStatus.Success
            };
        }
        public static OperationResult NotFound(string message)
        {
            return new OperationResult
            {
                Messsage = message,
                Status = OperationResultStatus.NotFound
            };
        }

    }
    public enum OperationResultStatus
    {
        Error = 10,
        Success = 200,
        NotFound = 404
    }
}
