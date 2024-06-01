namespace Application.Abstrsction.Messaging
{

    //marker interfaces

    //command which don't return the value
    public interface ICommand : IBaseCommand
    {
    }

    //command which return the value(TResponse)
    public interface ICommand<TResponse> : IBaseCommand
    {
    }


    //generic constraint that can target both implementations
    //good for mediatr pipline behaviour (execute logic before and after Command or Query Handlers)
    //(useful for validation or logging logic)
    public interface IBaseCommand
    {
    }
}
