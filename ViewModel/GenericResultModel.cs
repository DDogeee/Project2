using System.Collections.Generic;

namespace Project2.ViewModel
{
    public class GenericResultModel<T> where T : class 
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T ResultItem { get; set; }
        public List<T> Results { get; set; }

        public static GenericResultModel<T> Success(T item)
        {
            return new GenericResultModel<T>
            {
                IsSuccess = true,
                ResultItem = item
            };
        }

        public static GenericResultModel<T> Success(List<T> data)
        {
            return new GenericResultModel<T>
            {
                IsSuccess = true,
                Results = data
            };
        }

        public static GenericResultModel<T> Success()
        {
            return new GenericResultModel<T>
            {
                IsSuccess = true,
            };
        }

        //public static GenericResultModel<T> Success(string message)
        //{
        //    return new GenericResultModel<T>
        //    {
        //        IsSuccess = true,
        //        Message = message
        //    };
        //}

        public static GenericResultModel<T> Failed()
        {
            return new GenericResultModel<T>
            {
                IsSuccess = false
            };
        }

        public static GenericResultModel<T> Failed(string message)
        {
            return new GenericResultModel<T>
            {
                IsSuccess = false,
                Message = message
            };
        }

    }

}