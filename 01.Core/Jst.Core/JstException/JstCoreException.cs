using System;

namespace Jst.Core.JstException
{
    [Serializable]
    public class JstCoreException : Exception
    {
        /// <summary>
        /// ErrorCode
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ErrorMessage { get; set; }

        public JstCoreException() { }

        public JstCoreException(int code, string errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }

        public JstCoreException(string errorMessage)
        {
            Code = 500;
            ErrorMessage = errorMessage;
        }

        public JstCoreException(int code, string errorMessage, Exception innerException) 
            : base(errorMessage, innerException)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }

    }
}
