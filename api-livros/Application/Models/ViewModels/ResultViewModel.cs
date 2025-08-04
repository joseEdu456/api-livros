using Microsoft.VisualBasic;

namespace api_livros.Application.Models.ViewModels
{
    public class ResultViewModel
    {
        public ResultViewModel(string message = "", bool isSucess = true)
        {
            Message = message;
            IsSucess = isSucess;
        }

        public string Message { get; private set; }
        public bool IsSucess { get;  private set; }

        public static ResultViewModel Sucess()
        {
            return new();
        }

        public static ResultViewModel Error(string msg)
        {
            return new(msg, false);
        }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, string message = "", bool isSucess = true) : base(message, isSucess)
        {
            Data = data;
        }

        public T? Data { get; private set; }

        public static ResultViewModel<T> Sucess(T data)
        {
            return new(data);
        }

        public static ResultViewModel<T> Error(string msg)
        {
            return new(default, msg, false);
        }
    }
}
